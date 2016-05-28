using System;

using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Harvest;
using Server.Engines.PartySystem;
using Server.Customs.LS;
using Server.Customs.Gumps;
using Server.ACC;
using Server.ACC.CM;


namespace Server.Customs.LS.Levelables
{
    public class CombatLevel : LevelableModule
    {
        public override string Name() { return "Combat Level"; }

        public static void Configure()
        {
            LSGovernor.RegisterLevelable(typeof(Mobile), typeof(CombatLevel));
        }

        public virtual bool CreaturesLevel { get { return true; } }

        /// Level Difference Exp Mod
        private int m_LevelDifference;
        private int m_LevelDifferenceMod;
        private bool m_HighLevelReverse;

        private bool m_PartyShareExp;
        private bool m_PartyShareEvenly;
        private int m_PartyShareRange;
        private int m_PowerLevelRange;

        public virtual int LevelDifference { get { return m_LevelDifference; } set { m_LevelDifference = value; } }
        public virtual int LevelDifferenceMod { get { return m_LevelDifferenceMod; } set { m_LevelDifferenceMod = value; } }
        public virtual bool HighLevelReverse { get { return m_HighLevelReverse; } set { m_HighLevelReverse = value; } }

        public virtual bool PartyShareExp { get { return m_PartyShareExp; } set { m_PartyShareExp = value; } }
        public virtual bool PartyShareEvenly { get { return m_PartyShareEvenly; } set { m_PartyShareEvenly = value; } }
        public virtual int PartyShareRange { get { return m_PartyShareRange; } set { m_PartyShareRange = value; } }
        public virtual int PowerLevelRange { get { return m_PowerLevelRange; } set { m_PowerLevelRange = value; } }

        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler(Login_Event);
            EventSink.CharacterCreated += new CharacterCreatedEventHandler(CharacterCreated_Event);
        }

        public static void Login_Event(LoginEventArgs e)
        {
            LSGovernor.AttachLevelables(e.Mobile.Serial);

            int totalexp  = 0;
            CombatLevel combat = (CombatLevel)LSGovernor.GetAttached(e.Mobile.Serial, typeof(CombatLevel));

            for (int i = 0; i < combat.Level; i++)
                totalexp += combat.LevelsAt[i];

            if (combat.TotalExp < totalexp)
                combat.TotalExp = totalexp;
        }

        public static void CharacterCreated_Event(CharacterCreatedEventArgs e)
        {
            if (e.Mobile != null && e.Mobile.Serial != null)
                LSGovernor.AttachLevelables(e.Mobile.Serial);
        }

        public CombatLevel(Serial serial)
            : base(serial)
        {
            Level = 1;
            SetCap(100, 120);
            ReverseLevel = false;
            LevelsAtBase = 65;
            LevelType = LevelTypes.Rank;

            m_LevelDifference = 15;
            m_LevelDifferenceMod = 25;
            m_HighLevelReverse = false;

            m_PartyShareExp = true;
            m_PartyShareEvenly = true;
            m_PartyShareRange = 14;
            m_PowerLevelRange = 20;
        }
        
        public override void Append(Module mod, bool negativly)
        {
        }
        
        public virtual void AddExp(Mobile killer, Mobile killed)
        {
            if (killer == null | killed == null)
                return;

            if (killer is PlayerMobile && killed is PlayerMobile)
                return;

            if (killed is BaseCreature && (((BaseCreature)killed).Summoned | ((BaseCreature)killed).IsAnimatedDead))
                return;

            bool frompet = false;
            if (killer is BaseCreature && (((BaseCreature)killer).Controlled || ((BaseCreature)killer).BardProvoked || ((BaseCreature)killer).Summoned || ((BaseCreature)killer).IsAnimatedDead || ((BaseCreature)killer).IsNecroFamiliar))
            {
                //Pet Exp
                frompet = true;
                if (((BaseCreature)killer).Controlled)
                {
                    AddExp(killer, killed, GetExp(killer, killed));
                    killer = ((BaseCreature)killer).GetMaster();
                }
                else if (((BaseCreature)killer).BardProvoked && ((BaseCreature)killer).BardMaster != null)
                    killer = ((BaseCreature)killer).BardMaster;
                else if (((BaseCreature)killer).Summoned && ((BaseCreature)killer).SummonMaster != null)
                    killer = ((BaseCreature)killer).SummonMaster;
                else if (((BaseCreature)killer).ControlMaster != null)
                    killer = ((BaseCreature)killer).ControlMaster;
                else
                    return;
            }

            if (killer != null)
            {
                if (!frompet)
                    AddExp(killer, killed, GetExp(killer, killed));
                else
                {
                    CombatLevel level = (CombatLevel)LSGovernor.GetAttached(killer.Serial, typeof(CombatLevel));
                    level.AddExp(killer, killed);
                }
            }
        }

        public virtual void AddExp(Mobile killer, Mobile killed, int amount)
        {
            if (killer is BaseCreature)
            {
                if (!CreaturesLevel | !((BaseCreature)killer).Controlled)
                    return;

                if (((BaseCreature)killer).BardProvoked || ((BaseCreature)killer).Summoned)
                    return;
            }

            Party p = Party.Get(killer);

            if (p == null || p.Members.Count <= 1 || !m_PartyShareExp)
            {
                //Give Exp
                CombatLevel combat = (CombatLevel)LSGovernor.GetAttached(killer.Serial, typeof(CombatLevel));
                combat.AddExp((int)Filter(killer, killed, amount));
            }
            else
            {
                int killerLevel = 0, inRange = 0;
                {
                    //Get Killer Level
                    CombatLevel combat = (CombatLevel)LSGovernor.GetAttached(killer.Serial, typeof(CombatLevel));
                    killerLevel = combat.Level;

                    //Get People In Range
                    foreach (PartyMemberInfo mi in p.Members)
                    {
                        PlayerMobile pm = (PlayerMobile)mi.Mobile;
                        if (pm.Alive && pm.InRange(killed, m_PartyShareRange))
                            inRange++;
                    }
                }

                //Split Exp
                if (m_PartyShareEvenly && amount > 0)
                    amount = (int)((amount + (amount * (.3 * inRange))) / inRange);

                //Give Each Exp
                foreach (PartyMemberInfo mi in p.Members)
                {
                    PlayerMobile pm = (PlayerMobile)mi.Mobile;

                    //Skip If Not Qualified
                    if (pm.Class == Class.Crafter || !pm.Alive || !pm.InRange(killed, m_PartyShareRange))
                        continue;

                    //Give Exp If Not 'Power Leveler'
                    CombatLevel combat = (CombatLevel)LSGovernor.GetAttached(pm.Serial, typeof(CombatLevel));
                    if (combat.Level >= (killerLevel - m_PowerLevelRange))
                        combat.AddExp((int)Filter(pm, killed, amount));
                }
            }
        }

        public virtual void AddExp(Mobile m, Item i, int quality, double success, double exceptional)
        {
            PlayerMobile pm = (PlayerMobile)m;
            double exp = 5.0;
            exp += (i.Weight + success);

            if (i is BaseWeapon)
            {
                #region Weapon Resource Settings
                BaseWeapon bw = i as BaseWeapon;

                if (bw.Resource == CraftResource.Iron)
                    exp += 0.25;
                else if (bw.Resource == CraftResource.DullCopper)
                    exp += 0.50;
                else if (bw.Resource == CraftResource.ShadowIron)
                    exp += 1.0;
                else if (bw.Resource == CraftResource.Copper)
                    exp += 1.75;
                else if (bw.Resource == CraftResource.Bronze)
                    exp += 2.75;
                else if (bw.Resource == CraftResource.Gold)
                    exp += 4.0;
                else if (bw.Resource == CraftResource.Agapite)
                    exp += 5.50;
                else if (bw.Resource == CraftResource.Verite)
                    exp += 7.25;
                else if (bw.Resource == CraftResource.Valorite)
                    exp += 9.0;

                #endregion
            }
            else if (i is BaseArmor)
            {
                #region Armour Resource Settings
                BaseArmor ba = i as BaseArmor;

                foreach (Type t in armors.Ringmail)
                {
                    if (t == ba.GetType())
                        exp += 9.75;
                }

                foreach (Type t in armors.Chainmail)
                {
                    if (t == ba.GetType())
                        exp += 12.5;
                }

                foreach (Type t in armors.Platemail)
                {
                    if (t == ba.GetType())
                        exp += 15.0;
                }


                if (ba.Resource == CraftResource.Iron)
                    exp += 0.2;
                else if (ba.Resource == CraftResource.DullCopper)
                    exp += 0.4;
                else if (ba.Resource == CraftResource.ShadowIron)
                    exp += 0.8;
                else if (ba.Resource == CraftResource.Copper)
                    exp += 1.6;
                else if (ba.Resource == CraftResource.Bronze)
                    exp += 1.8;
                else if (ba.Resource == CraftResource.Gold)
                    exp += 2.2;
                else if (ba.Resource == CraftResource.Agapite)
                    exp += 3.0;
                else if (ba.Resource == CraftResource.Verite)
                    exp += 4.6;
                else if (ba.Resource == CraftResource.Valorite)
                    exp += 4.8;

                else if (ba.Resource == CraftResource.RegularLeather)
                    exp += 0.8;
                else if (ba.Resource == CraftResource.SpinedLeather)
                    exp += 1.6;
                else if (ba.Resource == CraftResource.HornedLeather)
                    exp += 2.6;
                else if (ba.Resource == CraftResource.BarbedLeather)
                    exp += 3.8;

                #endregion
            }

            success = (success * 100);
            if (success > 0 && success < 20)
                exp += 10.0;
            else if (success > 20 && success < 40)
                exp += 8.0;
            else if (success > 40 && success < 60)
                exp += 6.0;
            else if (success > 60 && success < 80)
                exp += 4.0;
            else
                exp += 2.0;

            if (quality > 1)
                exp += 10;

            AddExp((int)Math.Round(exp));
        }

        public virtual void IncreaseStats(Mobile mob)
        {
            if (Level < 100)
                mob.StatPoints += (int)(2 + (Level * .0129));

            if (Level == 1)
                mob.SkillPoints += 3;
            else
                mob.SkillPoints += (int)(4 + (Level * .087));
        }

        public override void LevelUp(int times)
        {
            if (Owner.IsMobile)
            {
                Mobile mob = (Mobile)World.FindMobile(Owner);

                if (mob.Hits < mob.HitsMax)
                    mob.Hits = mob.HitsMax;

                if (mob.Mana < mob.ManaMax)
                    mob.Mana = mob.ManaMax;

                if (mob.Stam < mob.StamMax)
                    mob.Stam = mob.StamMax;

                if (mob is BaseCreature)
                {
                    BaseCreature bc = (BaseCreature)mob;

                    if (bc.Controlled)
                    {
                        PlayerMobile pm = (PlayerMobile)bc.GetMaster();
                        pm.SendGump(new NoticeGump(pm, bc));
                    }
                }

                if (mob is PlayerMobile)
                {
                    PlayerMobile pm = (PlayerMobile)mob;
                    pm.SendGump(new NoticeGump(pm, pm));

                    pm.PlaySound(0x20F);
                    pm.FixedParticles(0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Waist);
                    pm.FixedParticles(0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist);
                    pm.SendMessage("Congratulations, your level has increased by {0}", times);
                }
            }

            base.LevelUp(times);
        }

        public override void AddLevelUpBonus()
        {
            if (Owner.IsMobile)
            {
                Mobile mob = (Mobile)World.FindMobile(Owner);
                IncreaseStats(mob);
            }

            base.AddLevelUpBonus();
        }

        public override int[] GenerateLevelsAt(int labase, int endcap)
        {
            /*
    double LastDiffDiff = 0, LastDiff = 0;

    int[] temp = new int[endcap];
    for (int i = 0; i < temp.Length; i++)
    {
        if (i <= 0)
        {
            temp[i] = labase;
            LastDiff = labase;
        }
        else
        {

            LastDiffDiff += (i * 2) + (i + 1) * 1.125;
            LastDiff += LastDiffDiff;

            if (i > 10)
                temp[i] = (int)(Math.Round((temp[i - 1] + LastDiff), 0) / (.125 * i));
            else
                temp[i] = (int)(Math.Round((temp[i - 1] + LastDiff), 0));
        }
    }

    return temp;
             * */

            double LastDiff = 0, LastDiffDiff = 0;

            int[] complexList = new int[(endcap + 1)];
            for (int i = 0; i < complexList.Length; i++)
            {
                if (i == 0) { LastDiff = complexList[i] = labase; }
                else
                {
                    LastDiffDiff += (i * 2) + (i + 1) * 1.125;
                    LastDiff += LastDiffDiff;

                    complexList[i] = (int)(Math.Round((complexList[i - 1] + LastDiff), 0));
                }
            }

            int[] simpleList = new int[endcap + 1];
            simpleList[0] = 0;//Just in case called.
            for (int i = 1; i < simpleList.Length; i++)
            {
                if (i < 10)
                    simpleList[i] = complexList[i] - complexList[(i - 1)];
                else
                    simpleList[i] = (int)((complexList[i] - complexList[(i - 1)]) / (i * .1));
            }

            return simpleList;
        }

        static int GetExp(Mobile m, Mobile k)
        {
            if (m is PlayerMobile && k is PlayerMobile)
                return 0;//Shards of Nagash doesnt give pk exp;

            CreatureLevel creature = (CreatureLevel)LSGovernor.GetAttached(k.Serial, typeof(CreatureLevel));
            //CombatLevel combat = (CombatLevel)LSGovernor.GetAttached(m.Serial, typeof(CombatLevel));

            if (creature == null)
                return 0;

            int exp = 0;
            if (creature.Level <= 10)
                exp += (int)((creature.Level * 2) + ((creature.Level * 1.25) * 10));
            else if (creature.Level <= 50)
                exp += (int)((creature.Level * 2) + ((creature.Level * 1.5) * 10));
            else
                exp += (int)((creature.Level * 2.5) + ((creature.Level * 1.75) * 10));

            if (exp <= 0)
                exp = 0;

            if (k is BaseCreature && ((BaseCreature)k).IsParagon)
                exp += 150;

            return exp; //(int)(exp / 1.25);
        }

        public virtual int Filter(Mobile killer, Mobile killed, int exp)
        {
            LevelableModule kcl = (LevelableModule)LSGovernor.GetAttached(killed.Serial, ((killed is BaseCreature) ? typeof(CreatureLevel) : typeof(CombatLevel)));

            Console.WriteLine("{0}: <Filtering> My Level {1} : Killed Level: {2} Base Exp: {3}",
                ((killer is BaseCreature) ? "Pet" : "Player"), Level, kcl.Level, exp);

            if (kcl == null)
                return 0;

            int filteredexp = 0;
            if (kcl.Level < Level)
            {
                if (Level - kcl.Level > LevelDifference)
                    filteredexp = (exp - (((Level - kcl.Level) - LevelDifference) * LevelDifferenceMod));
                else
                    filteredexp = exp;
            }
            else
            {
                if (kcl.Level - Level > LevelDifference)
                {
                    if (HighLevelReverse)
                        filteredexp = (exp + (((kcl.Level - Level) - LevelDifference) * LevelDifferenceMod));
                    else
                        filteredexp = (exp - (((kcl.Level - Level) - LevelDifference) * LevelDifferenceMod));
                }
                else
                    filteredexp = exp;
            }

            //Console.WriteLine("<FILTER>: " + filteredexp);
            return filteredexp;
        }

        public override void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); //version

            base.Serialize(writer);
        }

        public override void Deserialize(GenericReader reader)
        {
            int version = reader.ReadInt();

            base.Deserialize(reader);
        }
    }
}