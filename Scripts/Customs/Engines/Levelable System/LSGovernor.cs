using System;
using System.Collections.Generic;

using Server;
using Server.Gumps;
using Server.Network;
using Server.ACC;
using Server.ACC.CM;

namespace Server.Customs.LS
{
    public class LSGovernor
    {
        private static Dictionary<Type, List<Type>> m_Register = new Dictionary<Type, List<Type>>();
        public static Dictionary<Type, List<Type>> Register { get { return m_Register; } set { m_Register = value; } }

        public static void Initialize()
        {
            EventSink.ServerStarted += new ServerStartedEventHandler(ServerStarted_Event);
        }

        public static void ServerStarted_Event()
        {
            Console.Write("Levelables: Attaching... ");

            if (ContainsItems())
            {
                Console.Write("[Items] ");
                foreach (Item i in World.Items.Values)
                    AttachLevelables(i.Serial);
            }

            if (ContainsMobiles())
            {
                Console.Write("[Mobiles] ");
                foreach (Mobile m in World.Mobiles.Values)
                    AttachLevelables(m.Serial);
            }

            Console.WriteLine("done.");
        }

        public static bool ContainsItems()
        {
            foreach (KeyValuePair<Type, List<Type>> listed in m_Register)
            {
                if (listed.Key == typeof(Item) || listed.Key.IsSubclassOf(typeof(Item)))
                    return true;
            }

            return false;
        }

        public static bool ContainsMobiles()
        {
            foreach (KeyValuePair<Type, List<Type>> listed in m_Register)
            {
                if (listed.Key == typeof(Mobile) || listed.Key.IsSubclassOf(typeof(Mobile)))
                    return true;
            }

            return false;
        }

        public static Type SerialType(Serial s)
        {
            if (s == null)
                return null;

            if (s.IsItem)
            {
                foreach (Item i in World.Items.Values)
                {
                    if (i.Serial == s)
                        return i.GetType();
                }
            }

            if (s.IsMobile)
            {
                foreach (Mobile m in World.Mobiles.Values)
                {
                    if (m.Serial == s)
                        return m.GetType();
                }
            }

            return null;
        }

        public static LevelableModule GetAttached(Serial serial, Type levelable)
        {
            if (!CentralMemory.Contains(serial))
                AttachLevelables(serial);

            return CentralMemory.GetModule(serial, levelable) as LevelableModule;
        }

        public static void RegisterLevelable(Type attach, Type levelable)
        {
            if (m_Register.ContainsKey(attach))
                if (m_Register[attach].Contains(levelable))
                    return;
                else
                    m_Register[attach].Add(levelable);
            else
            {
                List<Type> l = new List<Type>();
                l.Add(levelable);
                m_Register.Add(attach, l);
            }
        }

        public static void AttachLevelables(Serial s)
        {
            Type on = SerialType(s);

            if (on == null)
                return;

            foreach (KeyValuePair<Type, List<Type>> listed in m_Register)
            {
                if (listed.Key == on || on.IsSubclassOf(listed.Key))
                {
                    for (int i = 0; i < listed.Value.Count; i++)
                        CentralMemory.AddModule(s, listed.Value[i]);
                }
            }
        }
    }
}