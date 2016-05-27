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
    public class ExpRewardTicket : Item
    {
        Mobile m_Owner;
        int m_Increase;

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Owner { get { return m_Owner; } set { m_Owner = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Increase { get { return m_Increase; } set { m_Increase = value; } }

        [Constructable]
        public ExpRewardTicket()
            : this(Utility.Random(5000))
        {
        }

        [Constructable]
        public ExpRewardTicket(int award)
            : this(award, 0x14F0)
        {
        }

        [Constructable]
        public ExpRewardTicket(int award, int id)
            : base(id)
        {
            Name = "Certificate of Exp";
            Hue = 2956;
            LootType = LootType.Blessed;
            Weight = 1.0;
            m_Increase = award;
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add("+ " + m_Increase.ToString("#,0")); // value: ~1_val~
        }

        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            if (m_Owner == null)
                m_Owner = from;

            return base.OnDragDrop(from, dropped);
        }

        public override void OnDoubleClick(Mobile from)
        {
            PlayerMobile pm = from as PlayerMobile;
            CombatLevel combat = (CombatLevel)LSGovernor.GetAttached(from.Serial, typeof(CombatLevel));

            if (IsChildOf(pm.Backpack))
            {
                if (Owner != null && !(Owner == from))
                {
                    from.SendMessage("You are not the rightful owner of this certificate!");
                    return;
                }

                int add = 100;
                int t = 0;
                while ((t + add) <= m_Increase)
                {
                    combat.AddExp(add);

                    if (add <= 0)
                        break;

                    if ((t + add) > m_Increase)
                        add = (t + add) - m_Increase;
                    else
                        t += add;
                }

                //combat.AddExp(m_Increase);
                this.Delete();
            }
            else
                pm.SendMessage("This must be in your pack!");
        }

        public ExpRewardTicket(Serial serial)
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
                        break;
                    }
                case 0:
                    {
                        if (version < 1)
                            m_Increase = Utility.Random(5000);
                        else
                            m_Increase = reader.ReadInt();

                        break;
                    }
            }
        }
    }
}