using System;
using System.Collections.Generic;

using Server;
using Server.Mobiles;

using Server.Customs.LS;
using Server.Customs.LS.Levelables;

namespace Server.QuickFix
{
    public class RunMe
    {
        public static void Initialize()
        {
            foreach (Mobile m in World.Mobiles.Values)
            {
                if (m is PlayerMobile)
                {
                    if (((PlayerMobile)m).FollowersMax > 4 && ((PlayerMobile)m).Class != Class.Ranger)
                        ((PlayerMobile)m).FollowersMax = 4;

                    CombatLevel combat = (CombatLevel)LSGovernor.GetAttached(m.Serial, typeof(CombatLevel));

                    int totalexp = 0;
                    for (int i = 0; i < combat.Level; i++)
                    {
                        totalexp += combat.LevelsAt[i];
                    }

                    if (combat.TotalExp < totalexp)
                        combat.TotalExp = totalexp;
                }
            }
        }
    }
}