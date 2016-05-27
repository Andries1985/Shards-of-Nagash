using System;
using System.Collections.Generic;

using Server;
using Server.Mobiles;

using Server.Customs.LS;
using Server.Customs.LS.Levelables;

namespace Custom
{
    public class StaticLevel
    {
        private static Dictionary<Type, int> m_List = new Dictionary<Type, int>();

        public static Dictionary<Type, int> Table { get { return m_List; } }

        public static void Add(Mobile m, int minLevel, int maxLevel) { Add(m, Utility.RandomMinMax(minLevel, maxLevel)); }
        public static void Add(Type t, int minLevel, int maxLevel) { Add(t, Utility.RandomMinMax(minLevel, maxLevel)); }
        public static void Add(Mobile m, int level) { Add(m.GetType(), level); }
        public static void Add(Type t, int level)
        {
            if (!(m_List.ContainsKey(t)))
                m_List.Add(t, level);
            else
                m_List[t] = level;
        }
    }
}