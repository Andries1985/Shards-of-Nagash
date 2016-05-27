using System;
using System.Collections.Generic;
using System.Text;

using Server.Network;
using Server.Mobiles;
using Server.Customs.Gumps;

namespace Server
{
    public class CustomSkillWindow
    {
        public static void Initialize()
        {
            PacketHandlers.Register(0x34, 10, true, new OnPacketReceive(RequestSkillsAndStatsGump));
            PacketHandlers.Register6017(0x34, 10, true, new OnPacketReceive(RequestSkillsAndStatsGump));
        }

        public static void RequestSkillsAndStatsGump(NetState state, PacketReader pvSrc)
        {
            pvSrc.ReadInt32();
            int selectionByte = pvSrc.ReadByte();
            Mobile from = World.FindMobile(pvSrc.ReadInt32());
            if (from == null)
                return;

            switch (selectionByte)
            {
                case 4:

                    from.OnStatsQuery(state.Mobile);
                    break;
                case 5:
                    if (!(from is PlayerMobile))
                        return;

                    OpenSkillWindow(from as PlayerMobile);
                    break;
                default:
                    Console.Write("Error:  recieved invalid packet type 0x34");
                    break;
            }
        }


        public static void OpenSkillWindow(PlayerMobile player)
        {
            //This is where you add a call to the gump you want to open when the player clicks the skill button
            //new CustomSkillGump( player );
            //player.SendMessage("I am a custom skill window!");

            if (player.HasGump(typeof(PointDistributionGump)))
                player.CloseGump(typeof(PointDistributionGump));

            player.SendGump(new PointDistributionGump(player, player, 0));
        }
    }
}