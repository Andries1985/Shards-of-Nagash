using System;
using Server;
using Server.ACC;
using Server.ACC.CM;
using Server.Mobiles;

namespace Server.Customs.LS
{
    public enum LevelTypes
    {
        None,
        Stat,
        Skill,
        Rank,
    }

    public class LevelableModule : Module
    {
        public override string Name() { return "Levelable"; }

        private int m_Level;
        private int m_RLevel;
        private bool m_ReverseLevel;

        private int m_Cap;
        private bool m_PastStartingCap;
        private int m_StartingCap;
        private int m_EndingCap;

        private long m_Exp;
        private long m_TotalExp;

        private int m_LevelsAtBase;
        private int[] m_LevelsAt;

        private LevelTypes m_LevelType;

        public virtual int Level
        {
            get
            {
                if (!m_ReverseLevel)
                    return m_Level;
                else
                    return m_RLevel;
            }
            set
            {
                m_Level = value;
                m_RLevel = m_Level - m_Cap;
            }
        }
        public virtual bool ReverseLevel { get { return m_ReverseLevel; } set { m_ReverseLevel = value; } }

        public int Cap { get { return m_Cap; } set { m_Cap = value; } }
        public bool PastStartingCap { get { return m_PastStartingCap; } set { m_PastStartingCap = value; } }
        public virtual int StartingCap { get { return m_StartingCap; } set { m_StartingCap = value; } }
        public virtual int EndingCap
        { get { return m_EndingCap; } set { m_EndingCap = value; } }

        public long Exp { get { return m_Exp; } set { m_Exp = value; } }
        public long TotalExp { get { return m_TotalExp; } set { m_TotalExp = value; } }

        public virtual int LevelsAtBase
        {
            get { return m_LevelsAtBase; }
            set
            {
                m_LevelsAtBase = value;
                m_LevelsAt = GenerateLevelsAt(m_LevelsAtBase, m_EndingCap);
            }
        }
        public int[] LevelsAt { get { return m_LevelsAt; } }

        public virtual LevelTypes LevelType { get { return m_LevelType; } set { m_LevelType = value; } }

        public LevelableModule(Serial serial)
            : base(serial)
        {
            m_RLevel = m_Cap - m_Level;

            Level = 1;
            ReverseLevel = false;
            StartingCap = 99;//doing this will it force Cap to be 99 aswell?
            EndingCap = 100;
            m_Exp = m_TotalExp = 0;
            LevelsAtBase = 83;
            LevelType = LevelTypes.None;
        }

        public override void Append(Module mod, bool negativly)
        {
        }

        public virtual void AddExp(long amount)
        {
            if (amount < 0)
                amount = 0;

            /// Over-Exp-At-Cap Filter
            if (m_Exp + amount > m_LevelsAt[m_Level] && m_Level >= m_Cap)
                amount = amount - ((m_Exp + amount) - m_LevelsAt[m_Level]);

            if (Owner.IsMobile && amount > 0)
                World.FindMobile(Owner).SendMessage("You gained {0} exp.", amount);

            m_Exp += amount;
            m_TotalExp += amount;

            /// Figure Times To Level
            if (m_Exp >= m_LevelsAt[m_Level] && m_Level < m_Cap)
            {
                int times = 0;
                for (int i = 0; m_Exp >= m_LevelsAt[m_Level + i]; i++)
                {
                    m_Exp = m_Exp - m_LevelsAt[m_Level + i];
                    //times++;
                    LevelUp(1);

                    //if there is no next levelat
                    //if (!(m_LevelsAt.Contains(m_Level + i + 1)))
                    if ((m_Level + i + 1) > m_LevelsAt.Length)
                    {
                        //cap exp at this levelat
                        m_Exp = m_LevelsAt[m_Level + i];
                        break;//exit loop
                    }
                }
                //LevelUp(times);
            }
        }

        public virtual void LevelUp(int times)
        {
            m_Level += times;
            AddLevelUpBonus();
        }

        public virtual void AddLevelUpBonus()
        {

        }

        public virtual void SetCap(int start, int end)
        {
            m_StartingCap = start;
            m_EndingCap = end;

            if (m_Cap < m_StartingCap)
                m_Cap = m_StartingCap;

            if (m_Cap > m_StartingCap)
            {
                if (!m_PastStartingCap)
                    m_Cap = m_StartingCap;
            }

            if (m_Cap > m_EndingCap)
                m_Cap = m_EndingCap;

            m_LevelsAt = GenerateLevelsAt(m_LevelsAtBase, end);
        }

        public virtual void Reset(Mobile m)
        {

        }

        public virtual int[] GenerateLevelsAt(int labase, int endcap)
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

                    temp[i] = (int)(Math.Round((temp[i - 1] + LastDiff), 0));
                }
            }

            return temp;
            */

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
                simpleList[i] = complexList[i] - complexList[(i - 1)];

            return simpleList;
        }

        public override void Serialize(GenericWriter writer)
        {
            writer.Write((int)0); //version

            writer.Write((int)m_Level);

            writer.Write((int)m_Cap);
            writer.Write((bool)m_PastStartingCap);
            writer.Write((int)m_StartingCap);
            writer.Write((int)m_EndingCap);

            writer.Write((int)m_Exp);
            writer.Write((int)m_TotalExp);

            writer.Write((int)m_LevelsAtBase);
        }

        public override void Deserialize(GenericReader reader)
        {
            int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                        m_Level = reader.ReadInt();
                        m_Cap = reader.ReadInt();
                        m_PastStartingCap = reader.ReadBool();
                        m_StartingCap = reader.ReadInt();
                        m_EndingCap = reader.ReadInt();
                        m_Exp = reader.ReadInt();
                        m_TotalExp = reader.ReadInt();
                        m_LevelsAtBase = reader.ReadInt();
                        break;
                    }
            }
        }
    }
}