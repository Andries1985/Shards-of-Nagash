using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Commands;
using Server.Targeting;
using Server.Customs.LS;
using Server.Customs.LS.Levelables;

namespace Server.Customs.Gumps
{
    public class PointDistributionGump : Gump
    {
        public static void Initialize()
        {
            CommandSystem.Register("CS", AccessLevel.Player, new CommandEventHandler(CombatStats_Command));
            CommandSystem.Register("CombatStats", AccessLevel.Player, new CommandEventHandler(CombatStats_Command));
        }

        [Usage("CombatStats")]
        [Aliases("CS")]
        [Description("Gets the Combat Level Stats of the targeted mobile.")]
        public static void CombatStats_Command(CommandEventArgs e)
        {
            if (e.Mobile.HasGump(typeof(PointDistributionGump)))
                e.Mobile.CloseGump(typeof(PointDistributionGump));

            e.Mobile.Target = new InternalTarget();
        }

        public Mobile to = null, of = null;
        public Skill Skill1 = null, Skill2 = null, Skill3 = null, Skill4 = null;
        public Skill Skill5 = null, Skill6 = null, Skill7 = null, Skill8 = null;
        public int CurrentPage = 1;

        public PointDistributionGump(Mobile t, Mobile o, int page)
            : base(0, 0)
        {
            to = t; of = o;
            CurrentPage = (page < 1) ? 1 : page;

            /*
            if (of is PlayerMobile && to.AccessLevel < AccessLevel.GameMaster && of != to)
            {
                of = to;
                to.SendMessage("You are currently only allowed to look at your own stats!");
                ReloadGump(to);
                return;
            }*/

            #region [Set Player Skills]
            if (of is PlayerMobile)
            {
                Skills s = ((PlayerMobile)of).Skills;
                switch (((PlayerMobile)of).Class)
                {
                    case Class.None: break;
                    case Class.Mage:
                        {
                            Skill1 = s[(SkillName.Alchemy)]; Skill2 = s[(SkillName.EvalInt)];
                            Skill3 = s[(SkillName.Inscribe)]; Skill4 = s[(SkillName.ItemID)];
                            Skill5 = s[(SkillName.Magery)]; Skill6 = s[(SkillName.Meditation)];
                            Skill7 = s[(SkillName.MagicResist)]; Skill8 = s[(SkillName.SpiritSpeak)];
                            break;
                        }
                    case Class.Warrior:
                        {
                            Skill1 = s[(SkillName.Anatomy)]; Skill2 = s[(SkillName.Fencing)];
                            Skill3 = s[(SkillName.Healing)]; Skill4 = s[(SkillName.Macing)];
                            Skill5 = s[(SkillName.Parry)]; Skill6 = s[(SkillName.Swords)];
                            Skill7 = s[(SkillName.Tactics)]; Skill8 = s[(SkillName.Wrestling)];
                            break;
                        }
                    case Class.Ranger:
                        {
                            Skill1 = s[(SkillName.AnimalLore)]; Skill2 = s[(SkillName.AnimalTaming)];
                            Skill3 = s[(SkillName.Archery)]; Skill4 = s[(SkillName.Camping)];
                            Skill5 = s[(SkillName.Cooking)]; Skill6 = s[(SkillName.Fishing)];
                            Skill7 = s[(SkillName.Tracking)]; Skill8 = s[(SkillName.Veterinary)];
                            break;
                        }
                    case Class.Thief:
                        {
                            Skill1 = s[(SkillName.DetectHidden)]; Skill2 = s[(SkillName.Fencing)];
                            Skill3 = s[(SkillName.Hiding)]; Skill4 = s[(SkillName.Lockpicking)];
                            Skill5 = s[(SkillName.Poisoning)]; Skill6 = s[(SkillName.Snooping)];
                            Skill7 = s[(SkillName.Stealing)]; Skill8 = s[(SkillName.Stealth)];
                            break;
                        }
                    case Class.Bard:
                        {
                            Skill1 = s[(SkillName.Herding)]; Skill2 = s[(SkillName.Cartography)];
                            Skill3 = s[(SkillName.Discordance)]; Skill4 = s[(SkillName.Macing)];
                            Skill5 = s[(SkillName.Musicianship)]; Skill6 = s[(SkillName.Peacemaking)];
                            Skill7 = s[(SkillName.Provocation)]; Skill8 = s[(SkillName.TasteID)];
                            break;
                        }
                    case Class.Crafter:
                        {
                            Skill1 = s[(SkillName.ArmsLore)]; Skill2 = s[(SkillName.Blacksmith)];
                            Skill3 = s[(SkillName.Fletching)]; Skill4 = s[(SkillName.Carpentry)];
                            Skill5 = s[(SkillName.Lumberjacking)]; Skill6 = s[(SkillName.Mining)];
                            Skill7 = s[(SkillName.Tailoring)]; Skill8 = s[(SkillName.Tinkering)];
                            break;
                        }
                }
            }
            #endregion

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            #region [Background]
            AddPage(0);
            AddBackground(109, 61, 569, 434, 83);
            AddBackground(113, 103, 562, 355, 9260);
            AddBackground(131, 392, 525, 25, 9200);
            AddBackground(393, 240, 264, 149, 9500);
            AddBackground(130, 240, 247, 149, 9500);
            AddBackground(321, 112, 336, 87, 9500);
            AddBackground(481, 213, 175, 25, 9500);
            AddBackground(306, 213, 175, 25, 9500);
            AddBackground(130, 213, 175, 25, 9500);
            AddImageTiled(384, 240, 9, 149, 97);
            AddBackground(130, 112, 173, 87, 9500);
            AddImageTiled(127, 198, 536, 18, 10301);
            AddImageTiled(123, 239, 539, 4, 96);
            AddImageTiled(303, 115, 18, 95, 10150);
            AddImageTiled(113, 440, 561, 18, 10301);
            AddImageTiled(167, 97, 457, 18, 10301);
            AddBackground(306, 415, 175, 25, 9500);
            AddBackground(130, 415, 175, 25, 9500);
            AddBackground(481, 415, 175, 25, 9500);
            AddImageTiled(131, 413, 524, 4, 96);
            AddImage(79, 104, 10421);
            AddImage(107, 86, 10420);
            AddImage(92, 238, 10422);
            AddImage(654, 104, 10431);
            AddImage(621, 86, 10430);
            AddImage(648, 238, 10432);
            AddImage(63, 397, 10402);
            AddImage(643, 397, 10412);
            AddImageTiled(377, 240, 9, 151, 95);
            AddImageTiled(131, 389, 524, 4, 96);
            #endregion

            #region [Mobile Stats]
            AddLabel(157, 129, 1953, @"Strength:"); AddLabel(252, 129, 1953, @"" + of.Str);
            AddLabel(157, 149, 1953, @"Dexterity:"); AddLabel(252, 149, 1953, @"" + of.Dex);
            AddLabel(157, 169, 1953, @"Intelligence:"); AddLabel(252, 169, 1953, @"" + of.Int);

            #region [Stat Buttons]
            if (of.StatPoints > 0 && ((of is BaseCreature && ((BaseCreature)of).GetMaster() == to) || (of == to && of.RawStatTotal < of.StatCap)))
            {
                if (of is BaseCreature || of is PlayerMobile && of.RawStr < 150)
                    AddButton(139, 133, 2435, 2436, (int)Buttons.Increase_Str, GumpButtonType.Reply, 0);

                if (of is BaseCreature || of is PlayerMobile && of.RawDex < 150)
                    AddButton(139, 153, 2435, 2436, (int)Buttons.Increase_Dex, GumpButtonType.Reply, 0);

                if (of is BaseCreature || of is PlayerMobile && of.RawInt < 150)
                    AddButton(139, 173, 2435, 2436, (int)Buttons.Increase_Int, GumpButtonType.Reply, 0);
            }

            if (!(of is BaseCreature))
            {
                AddButton(285, 180, 1209, 1210, (int)Buttons.StatGump, GumpButtonType.Reply, 0);
            }
            #endregion

            #endregion

            #region [Combat Stats]
            CombatLevel combat = (CombatLevel)LSGovernor.GetAttached(of.Serial, typeof(CombatLevel));
            AddLabel(327, 129, 1953, @"Level:"); AddLabel(392, 129, 1953, @"" + combat.Level);
            AddLabel(327, 149, 1953, @"Exp:"); AddLabel(392, 149, 1953, @"" + combat.Exp.ToString("#,#"));
            AddLabel(327, 169, 1953, @"Level At:"); AddLabel(392, 169, 1953, @"" + combat.LevelsAt[combat.Level].ToString("#,#"));
            AddLabel(492, 129, 1953, @"Cap:"); AddLabel(563, 129, 1953, @"" + combat.Cap);
            AddLabel(492, 149, 1953, @"Total Exp:"); AddLabel(563, 149, 1953, @"" + combat.TotalExp.ToString("#,#"));
            #endregion

            AddLabel(157, 218, 1953, @"" + of.Name);
            AddLabel(330, 218, 1953, @"Class:"); AddLabel(376, 218, 1953, @"" + ((of is BaseCreature) ? "Creature" : @"" + ((PlayerMobile)of).Class));
            AddLabel(502, 218, 1953, @"Rank:"); AddLabel(545, 218, 1953, @"" + ((of is BaseCreature) ? "--" : @"" + ((PlayerMobile)of).Rank));

            #region [Pet Skills]
            if (of is BaseCreature)
            {
                #region [Page Background]
                AddPage(1);
                AddBackground(131, 392, 525, 25, 9200);
                AddBackground(393, 240, 264, 149, 9500);
                AddBackground(130, 240, 247, 149, 9500);
                AddImageTiled(384, 240, 9, 149, 97);
                AddImageTiled(123, 239, 539, 4, 96);
                AddImageTiled(131, 413, 524, 4, 96);
                AddImage(79, 104, 10421);
                AddImage(107, 86, 10420);
                AddImage(92, 238, 10422);
                AddImage(654, 104, 10431);
                AddImage(621, 86, 10430);
                AddImage(648, 238, 10432);
                AddImageTiled(377, 240, 9, 151, 95);
                AddImageTiled(131, 389, 524, 4, 96);
                #endregion

                //int CurrentPage = (page < 1) ? 1 : page;
                int SkillCount = ((BaseCreature)of).Skills.Length;
                int TotalPages = 7; // (int)(SkillCount / 8);

                #region [Skills On Page]
                if ((SkillID(1) - 1) < SkillCount)
                {
                    AddLabel(175, 274, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(1) - 1)].Name + ":");
                    AddLabel(308, 274, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(1) - 1)].Base);
                }

                if ((SkillID(2) - 1) < SkillCount)
                {
                    AddLabel(175, 299, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(2) - 1)].Name + ":");
                    AddLabel(308, 299, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(2) - 1)].Base);
                }

                if ((SkillID(3) - 1) < SkillCount)
                {
                    AddLabel(175, 324, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(3) - 1)].Name + ":");
                    AddLabel(308, 324, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(3) - 1)].Base);
                }

                if ((SkillID(4) - 1) < SkillCount)
                {
                    AddLabel(175, 349, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(4) - 1)].Name + ":");
                    AddLabel(308, 349, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(4) - 1)].Base);
                }

                if ((SkillID(5) - 1) < SkillCount)
                {
                    AddLabel(446, 274, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(5) - 1)].Name + ":");
                    AddLabel(579, 274, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(5) - 1)].Base);
                }

                if ((SkillID(6) - 1) < SkillCount)
                {
                    AddLabel(446, 299, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(6) - 1)].Name + ":");
                    AddLabel(579, 299, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(6) - 1)].Base);
                }

                if ((SkillID(7) - 1) < SkillCount)
                {
                    AddLabel(446, 324, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(7) - 1)].Name + ":");
                    AddLabel(579, 324, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(7) - 1)].Base);
                }

                if ((SkillID(8) - 1) < SkillCount)
                {
                    AddLabel(446, 349, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(8) - 1)].Name + ":");
                    AddLabel(579, 349, 1953, @"" + ((BaseCreature)of).Skills[(SkillID(8) - 1)].Base);
                }

                #region [Skill Increase Buttons]
                if (of.SkillPoints > 0)
                {
                    if ((SkillID(1) - 1) <= SkillCount)
                        AddButton(160, 278, 2435, 2436, ((SkillID(1) - 1) * 100), GumpButtonType.Reply, 0);

                    if ((SkillID(2) - 1) <= SkillCount)
                        AddButton(160, 303, 2435, 2436, ((SkillID(2) - 1) * 100), GumpButtonType.Reply, 0);

                    if ((SkillID(3) - 1) <= SkillCount)
                        AddButton(160, 328, 2435, 2436, ((SkillID(3) - 1) * 100), GumpButtonType.Reply, 0);

                    if ((SkillID(4) - 1) <= SkillCount)
                        AddButton(160, 353, 2435, 2436, ((SkillID(4) - 1) * 100), GumpButtonType.Reply, 0);

                    if ((SkillID(5) - 1) <= SkillCount)
                        AddButton(428, 278, 2435, 2436, ((SkillID(5) - 1) * 100), GumpButtonType.Reply, 0);

                    if ((SkillID(6) - 1) <= SkillCount)
                        AddButton(428, 303, 2435, 2436, ((SkillID(6) - 1) * 100), GumpButtonType.Reply, 0);

                    if ((SkillID(7) - 1) <= SkillCount)
                        AddButton(428, 328, 2435, 2436, ((SkillID(7) - 1) * 100), GumpButtonType.Reply, 0);

                    if ((SkillID(8) - 1) <= SkillCount)
                        AddButton(428, 353, 2435, 2436, ((SkillID(8) - 1) * 100), GumpButtonType.Reply, 0);
                }
                #endregion

                #endregion

                #region [Page Buttons]
                if (CurrentPage > 1)
                    AddButton(134, 395, 57, 58, (int)Buttons.Previous_SkillsPage, GumpButtonType.Reply, 0);

                AddLabel(367, 394, 2594, @"Page " + CurrentPage);

                if (CurrentPage < TotalPages)
                    AddButton(622, 395, 59, 58, (int)Buttons.Next_SkillsPage, GumpButtonType.Reply, 0);
                #endregion
            }
            #endregion

            #region [Player Skills]
            if (of is PlayerMobile && Skill1 != null)
            {
                AddLabel(175, 274, 1953, @"" + Skill1.Name + ":"); AddLabel(308, 274, 1953, @"" + Skill1.Base);
                AddLabel(175, 299, 1953, @"" + Skill2.Name + ":"); AddLabel(308, 299, 1953, @"" + Skill2.Base);
                AddLabel(175, 324, 1953, @"" + Skill3.Name + ":"); AddLabel(308, 324, 1953, @"" + Skill3.Base);
                AddLabel(175, 349, 1953, @"" + Skill4.Name + ":"); AddLabel(308, 349, 1953, @"" + Skill4.Base);
                AddLabel(446, 274, 1953, @"" + Skill5.Name + ":"); AddLabel(579, 274, 1953, @"" + Skill5.Base);
                AddLabel(446, 299, 1953, @"" + Skill6.Name + ":"); AddLabel(579, 299, 1953, @"" + Skill6.Base);
                AddLabel(446, 324, 1953, @"" + Skill7.Name + ":"); AddLabel(579, 324, 1953, @"" + Skill7.Base);
                AddLabel(446, 349, 1953, @"" + Skill8.Name + ":"); AddLabel(579, 349, 1953, @"" + Skill8.Base);

                if (of == to && of.SkillPoints > 0)
                {
                    if (Skill1.Base < 140)
                        AddButton(160, 278, 2435, 2436, (int)Buttons.Increase_Skill1, GumpButtonType.Reply, 0);

                    if (Skill2.Base < 140)
                        AddButton(160, 303, 2435, 2436, (int)Buttons.Increase_Skill2, GumpButtonType.Reply, 0);

                    if (Skill3.Base < 140)
                        AddButton(160, 328, 2435, 2436, (int)Buttons.Increase_Skill3, GumpButtonType.Reply, 0);

                    if (Skill4.Base < 140)
                        AddButton(160, 353, 2435, 2436, (int)Buttons.Increase_Skill4, GumpButtonType.Reply, 0);

                    if (Skill5.Base < 140)
                        AddButton(428, 278, 2435, 2436, (int)Buttons.Increase_Skill5, GumpButtonType.Reply, 0);

                    if (Skill6.Base < 140)
                        AddButton(428, 304, 2435, 2436, (int)Buttons.Increase_Skill6, GumpButtonType.Reply, 0);

                    if (Skill7.Base < 140)
                        AddButton(428, 328, 2435, 2436, (int)Buttons.Increase_Skill7, GumpButtonType.Reply, 0);

                    if (Skill8.Base < 140)
                        AddButton(428, 353, 2435, 2436, (int)Buttons.Increase_Skill8, GumpButtonType.Reply, 0);
                }
            }
            #endregion

            AddLabel(157, 420, 1953, @"Stat Points:"); AddLabel(252, 420, 1953, @"" + of.StatPoints);
            AddLabel(330, 420, 1953, @"Skill Points:"); AddLabel(415, 420, 1953, @"" + of.SkillPoints);
            AddLabel(501, 420, 1953, @"Skill Total:"); AddLabel(609, 420, 1953, @"" + Convert.ToString(of.Skills.Total / 10));

            AddButton(633, 461, 1150, 1151, (int)Buttons.Exit, GumpButtonType.Reply, 0);
        }

        public void ReloadGump(Mobile m)
        {
            m.CloseGump(typeof(PointDistributionGump));
            m.SendGump(new PointDistributionGump(m, of, CurrentPage));
        }

        #region [Get SkillID]
        public int SkillID(int SkillSlot)
        {
            switch (SkillSlot)
            {
                case 1:
                    {
                        switch (CurrentPage)
                        {
                            case 1: return 1;
                            case 2: return 9;
                            case 3: return 17;
                            case 4: return 25;
                            case 5: return 33;
                            case 6: return 41;
                            case 7: return 49;
                        }
                        break;
                    }
                case 2:
                    {
                        switch (CurrentPage)
                        {
                            case 1: return 2;
                            case 2: return 10;
                            case 3: return 18;
                            case 4: return 26;
                            case 5: return 34;
                            case 6: return 42;
                            case 7: return 51;
                        }
                        break;
                    }
                case 3:
                    {
                        switch (CurrentPage)
                        {
                            case 1: return 3;
                            case 2: return 11;
                            case 3: return 19;
                            case 4: return 27;
                            case 5: return 35;
                            case 6: return 43;
                            case 7: return 60;
                        }
                        break;
                    }
                case 4:
                    {
                        switch (CurrentPage)
                        {
                            case 1: return 4;
                            case 2: return 12;
                            case 3: return 20;
                            case 4: return 28;
                            case 5: return 36;
                            case 6: return 44;
                            case 7: return 60;
                        }
                        break;
                    }
                case 5:
                    {
                        switch (CurrentPage)
                        {
                            case 1: return 5;
                            case 2: return 13;
                            case 3: return 21;
                            case 4: return 29;
                            case 5: return 37;
                            case 6: return 45;
                            case 7: return 60;
                        }
                        break;
                    }
                case 6:
                    {
                        switch (CurrentPage)
                        {
                            case 1: return 6;
                            case 2: return 14;
                            case 3: return 22;
                            case 4: return 30;
                            case 5: return 38;
                            case 6: return 46;
                            case 7: return 60;
                        }
                        break;
                    }
                case 7:
                    {
                        switch (CurrentPage)
                        {
                            case 1: return 7;
                            case 2: return 15;
                            case 3: return 23;
                            case 4: return 31;
                            case 5: return 39;
                            case 6: return 47;
                            case 7: return 60;
                        }
                        break;
                    }
                case 8:
                    {
                        switch (CurrentPage)
                        {
                            case 1: return 8;
                            case 2: return 16;
                            case 3: return 24;
                            case 4: return 32;
                            case 5: return 40;
                            case 6: return 48;
                            case 7: return 60;
                        }
                        break;
                    }
            }

            return 1;
        }
        #endregion

        #region [Page Buttons Enum]
        public enum Buttons
        {
            Exit,
            Increase_Str,
            Increase_Dex,
            Increase_Int,
            Increase_Skill1,
            Increase_Skill2,
            Increase_Skill3,
            Increase_Skill4,
            Increase_Skill5,
            Increase_Skill6,
            Increase_Skill7,
            Increase_Skill8,
            Previous_SkillsPage,
            Next_SkillsPage,
            StatGump
        }
        #endregion

        #region [On Response]
        public override void OnResponse(NetState state, RelayInfo info)
        {
            if (to != state.Mobile)
                to = state.Mobile;

            if (of is BaseCreature && info.ButtonID >= 100 && of.SkillPoints > 0)
            {
                ((BaseCreature)of).Skills[(info.ButtonID / 100)].Base += 1;
                of.SkillPoints -= 1;
                ReloadGump(to);
                return;
            }

            #region [Enum Buttons]
            switch (info.ButtonID)
            {
                case (int)Buttons.StatGump:
                    {
                        to.SendGump(new StatsGump(to)); break;
                    }
                case (int)Buttons.Previous_SkillsPage:
                    {
                        if (CurrentPage > 1)
                        {
                            CurrentPage -= 1;
                            ReloadGump(to);
                        }

                        break;
                    }
                case (int)Buttons.Next_SkillsPage:
                    {
                        if (CurrentPage < 7)
                        {
                            CurrentPage += 1;
                            ReloadGump(to);
                        }
                        break;
                    }
                case (int)Buttons.Increase_Str:
                    {
                        if (of.StatPoints > 0 && of.RawStr < 150)
                        {
                            of.RawStr += 1;
                            of.StatPoints -= 1;
                        }

                        ReloadGump(to);
                        break;
                    }
                case (int)Buttons.Increase_Dex:
                    {
                        if (of.StatPoints > 0 && of.RawDex < 150)
                        {
                            of.RawDex += 1;
                            of.StatPoints -= 1;
                        }

                        ReloadGump(to);
                        break;
                    }
                case (int)Buttons.Increase_Int:
                    {
                        if (of.StatPoints > 0 && of.RawInt < 150)
                        {
                            of.RawInt += 1;
                            of.StatPoints -= 1;
                        }

                        ReloadGump(to);
                        break;
                    }
                case (int)Buttons.Increase_Skill1:
                    {
                        if (of.SkillPoints > 0 && Skill1.Base < 140)
                        {
                            Skill1.Base += 1;
                            of.SkillPoints -= 1;

                            if (of is PlayerMobile && ((PlayerMobile)of).Class == Class.Ranger)
                            {
                                ((PlayerMobile)of).FollowersMax = ((int)(Skill1.Base / 23)) + 4;
                            }
                        }

                        ReloadGump(to);
                        break;
                    }
                case (int)Buttons.Increase_Skill2:
                    {
                        if (of.SkillPoints > 0 && Skill2.Base < 140)
                        {
                            Skill2.Base += 1;
                            of.SkillPoints -= 1;
                        }

                        ReloadGump(to);
                        break;
                    }
                case (int)Buttons.Increase_Skill3:
                    {
                        if (of.SkillPoints > 0 && Skill3.Base < 140)
                        {
                            Skill3.Base += 1;
                            of.SkillPoints -= 1;
                        }

                        ReloadGump(to);
                        break;
                    }
                case (int)Buttons.Increase_Skill4:
                    {
                        if (of.SkillPoints > 0 && Skill4.Base < 140)
                        {
                            Skill4.Base += 1;
                            of.SkillPoints -= 1;
                        }

                        ReloadGump(to);
                        break;
                    }
                case (int)Buttons.Increase_Skill5:
                    {
                        if (of.SkillPoints > 0 && Skill5.Base < 140)
                        {
                            Skill5.Base += 1;
                            of.SkillPoints -= 1;
                        }

                        ReloadGump(to);
                        break;
                    }
                case (int)Buttons.Increase_Skill6:
                    {
                        if (of.SkillPoints > 0 && Skill6.Base < 140)
                        {
                            Skill6.Base += 1;
                            of.SkillPoints -= 1;
                        }

                        ReloadGump(to);
                        break;
                    }
                case (int)Buttons.Increase_Skill7:
                    {
                        if (of.SkillPoints > 0 && Skill7.Base < 140)
                        {
                            Skill7.Base += 1;
                            of.SkillPoints -= 1;
                        }

                        ReloadGump(to);
                        break;
                    }
                case (int)Buttons.Increase_Skill8:
                    {
                        if (of.SkillPoints > 0 && Skill8.Base < 140)
                        {
                            Skill8.Base += 1;
                            of.SkillPoints -= 1;
                        }

                        ReloadGump(to);
                        break;
                    }
                case (int)Buttons.Exit:
                    {
                        to.CloseGump(typeof(PointDistributionGump));
                        if (of.StatPoints > 0 || of.SkillPoints > 0)
                        {
                            to.CloseGump(typeof(NoticeGump));
                            to.SendGump(new NoticeGump(to, of));
                        }

                        break;
                    }
            }
            #endregion
        }
        #endregion

        #region Target
        private class InternalTarget : Target
        {
            public InternalTarget()
                : base(5, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (!(targeted is Mobile))
                {
                    from.SendMessage("That does not have a Combat Level!");
                    return;
                }

                if (targeted is BaseCreature && !(((BaseCreature)targeted).Controlled))
                {
                    from.SendMessage("Only pets and other players have a Combat Level.");
                    return;
                }

                from.SendGump(new PointDistributionGump(from, ((Mobile)targeted), 0));
            }
        }
        #endregion
    }
}