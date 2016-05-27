using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Customs;
using Server.Customs.LS;
using Server.Customs.LS.Levelables;

namespace Server.Items
{
    public class ScrollofCombatSecrets : Item
    {
        int m_Increase;

        [CommandProperty(AccessLevel.GameMaster)]
        public int Increase { get { return m_Increase; } set { m_Increase = value; } }

        [Constructable]
        public ScrollofCombatSecrets()
            : this(Utility.RandomMinMax(1,2))
        {
        }

        [Constructable]
        public ScrollofCombatSecrets(int award)
            : this(award, 0x1F3D)
        {
        }

        [Constructable]
        public ScrollofCombatSecrets(int award, int id)
            : base(id) //: base(0x1F3D) //0x14F0)
        {
            Name = "Scroll of Combat Secrets";
            Hue = 2956;
            //LootType = LootType.Blessed;
            Weight = 1.0;
            m_Increase = award;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add("+ " + m_Increase.ToString("#,0")); // value: ~1_val~
        }

        public override void OnDoubleClick(Mobile from)
        {
            PlayerMobile pm = from as PlayerMobile;
            CombatLevel combat = (CombatLevel)LSGovernor.GetAttached(from.Serial, typeof(CombatLevel));

            if (IsChildOf(pm.Backpack))
            {
                if (combat.Cap >= combat.EndingCap)
                {
                    from.SendMessage("You cannot use this as you have already reached your full potintial.");
                    return;
                }

                if (combat.Cap < combat.EndingCap)
                {
                    combat.Cap += Increase;
                    this.Delete();
                    if (combat.Cap >= combat.EndingCap)
                    {
                        combat.Cap = combat.EndingCap;
                        from.SendMessage("Using all of its available knowledge you have reached your full potintial");
                    }
                }
            }
            else
                pm.SendMessage("This must be in your pack!");
        }

        public ScrollofCombatSecrets(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            writer.Write((int)m_Increase);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        m_Increase = reader.ReadInt();
                        goto case 0;
                    }
                case 0:
                    {
                        break;
                    }
            }
        }
    }
}