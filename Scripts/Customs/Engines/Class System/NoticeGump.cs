using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Customs.Gumps
{
    public class NoticeGump : Gump
    {
        Mobile to;
        Mobile of;

        public NoticeGump(Mobile t, Mobile o)
            : base(0, 0)
        {
            to = t;
            of = o;

            Closable = false;
            Disposable = false;
            Dragable = true;
            Resizable = false;
            AddPage(0);
            AddBackground(610, 517, 182, 75, 5150);
            AddButton(742, 543, 4005, 4005, 1, GumpButtonType.Reply, 0);
            AddLabel(632, 544, 1154, @"Points Available");
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            PlayerMobile pm = (PlayerMobile)state.Mobile;

            switch (info.ButtonID)
            {
                case 0://Exit
                    {
                        pm.CloseGump(typeof(NoticeGump));
                        if (of == pm || (of is BaseCreature && ((BaseCreature)of).GetMaster() == pm))
                            pm.SendGump(new NoticeGump(to, of));

                        break;
                    }
                case 1://Distribute Points
                    {
                        pm.CloseGump(typeof(NoticeGump));
                        if (!(of is BaseCreature) && (of == pm && (pm.StatPoints > 0 || pm.SkillPoints > 0)))
                            pm.SendGump(new PointDistributionGump(pm, pm, 0));
                        else
                        {
                            if (of is BaseCreature && ((BaseCreature)of).GetMaster() == pm)
                                pm.SendGump(new PointDistributionGump(pm, of, 0));
                        }

                        break;
                    }
            }
        }
    }
}