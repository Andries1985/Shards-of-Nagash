using System;

using Server;
using Server.Mobiles;
using Server.Customs.LS;

namespace Server.Customs.LS.Levelables
{
    public class CreatureLevel : LevelableModule
    {
        public static void Configure()
        {
            LSGovernor.RegisterLevelable(typeof(BaseCreature), typeof(CreatureLevel));
        }

        public static bool StaticTable { get { return true; } }

        public CreatureLevel(Serial serial)
            : base(serial)
        {
            LevelsAtBase = 70;
            LevelType = LevelTypes.Rank;

            foreach (Mobile m in World.Mobiles.Values)
            {
                if (m.Serial == Owner && m is BaseCreature)
                {
                    Reset(m);
                }
            }
        }

        public override void Reset(Mobile m)
        {
            //Level = 1;
            Exp = TotalExp = 0;
            SetCap(999, 1000);
            if (CreatureLevel.StaticTable && Custom.StaticLevel.Table.ContainsKey(m.GetType()))
            {
                Level = Custom.StaticLevel.Table[m.GetType()];
            }
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