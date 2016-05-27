using System;

using Server.Items;
using Server.Mobiles;

namespace Custom
{
    public class LootPack
    {
        #region [Loot Tables]
        public static List<LootPackEntry> PoorEntries = new List<LootPackEntry>();
        public static List<LootPackEntry> MeagerEntries = new List<LootPackEntry>();
        public static List<LootPackEntry> AverageEntries = new List<LootPackEntry>();
        public static List<LootPackEntry> RichEntries = new List<LootPackEntry>();
        public static List<LootPackEntry> FilthyRichEntries = new List<LootPackEntry>();
        public static List<LootPackEntry> UltraRichEntries = new List<LootPackEntry>();
        public static List<LootPackEntry> BossEntries = new List<LootPackEntry>();
        public static List<LootPackEntry> UltraBossEntries = new List<LootPackEntry>();
        public static List<LootPackEntry> UberBossEntries = new List<LootPackEntry>();

        public static List<LootPackEntry> ScrollEntries = new List<LootPackEntry>();
        public static List<LootPackEntry> GemEntries = new List<LootPackEntry>();
        public static List<LootPackEntry> PotionEntries = new List<LootPackEntry>();
        public static List<LootPackEntry> MagicalEntries = new List<LootPackEntry>();

        public static void Initialize()
        {
            PoorEntries.Add(new LootPackEntry(true, Money, 100.00, Utility.RandomMinMax(20, 50)));
            PoorEntries.Add(new LootPackEntry(false, ItemPack, 4.00, 1, 25, 2));
            PoorEntries.Add(new LootPackEntry(false, LowRares, 2.0, 1, 0, 0));
            PoorEntries.Add(new LootPackEntry(false, LowHealPotions, 45.00, 2));
            // GenOnSpawn PackType, DropChance, DropAmount, RareAttributeChance, RareAttributeAmount

            MeagerEntries.Add(new LootPackEntry(true, Money, 100.00, Utility.RandomMinMax(100, 200)));
            MeagerEntries.Add(new LootPackEntry(false, ItemPack, 30.00, 3, 50, 2));
            MeagerEntries.Add(new LootPackEntry(false, ItemPack, 15.00, 1, 25, 4));
            MeagerEntries.Add(new LootPackEntry(false, LowRares, 3.00, 1, 0, 0));
            MeagerEntries.Add(new LootPackEntry(false, Instruments, 5.00, 1, 30, 1));
            MeagerEntries.Add(new LootPackEntry(false, MediumHealPotions, 20.00, 2));

            AverageEntries.Add(new LootPackEntry(true, Money, 100.00, Utility.RandomMinMax(250, 500)));
            AverageEntries.Add(new LootPackEntry(false, ItemPack, 45.00, 4, 75, 2));
            AverageEntries.Add(new LootPackEntry(false, ItemPack, 30.00, 2, 50, 4));
            AverageEntries.Add(new LootPackEntry(false, ItemPack, 15.00, 1, 25, 6));
            AverageEntries.Add(new LootPackEntry(false, LowRares, 6.00, 1, 0, 0));
            AverageEntries.Add(new LootPackEntry(false, MedRares, 2.00, 1, 0, 0));
            AverageEntries.Add(new LootPackEntry(false, Instruments, 10.00, 1, 30, 1));
            AverageEntries.Add(new LootPackEntry(false, MediumHealPotions, 45.00, 2));

            RichEntries.Add(new LootPackEntry(true, Money, 100.00, Utility.RandomMinMax(1000, 2000)));
            RichEntries.Add(new LootPackEntry(false, ItemPack, 60.00, 5, 100, 2));
            RichEntries.Add(new LootPackEntry(false, ItemPack, 45.00, 3, 75, 4));
            RichEntries.Add(new LootPackEntry(false, ItemPack, 30.00, 2, 50, 6));
            RichEntries.Add(new LootPackEntry(false, ItemPack, 15.00, 1, 25, 8));
            RichEntries.Add(new LootPackEntry(false, MedRares, 6.00, 1, 0, 0));
            RichEntries.Add(new LootPackEntry(false, HighRares, 2.00, 1, 0, 0));
            RichEntries.Add(new LootPackEntry(false, MediumHealPotions, 60.00, 2));
            RichEntries.Add(new LootPackEntry(false, HighHealPotions, 10.00, 2));

            FilthyRichEntries.Add(new LootPackEntry(true, Money, 100.00, Utility.RandomMinMax(2500, 5000)));
            FilthyRichEntries.Add(new LootPackEntry(false, ItemPack, 75.00, 4, 100, 2));
            FilthyRichEntries.Add(new LootPackEntry(false, ItemPack, 60.00, 3, 100, 4));
            FilthyRichEntries.Add(new LootPackEntry(false, ItemPack, 45.00, 2, 75, 6));
            FilthyRichEntries.Add(new LootPackEntry(false, ItemPack, 30.00, 2, 50, 8));
            FilthyRichEntries.Add(new LootPackEntry(false, ItemPack, 15.00, 1, 25, 10));
            FilthyRichEntries.Add(new LootPackEntry(false, MedRares, 12.00, 1, 0, 0));
            FilthyRichEntries.Add(new LootPackEntry(false, HighRares, 6.00, 1, 0, 0));
            FilthyRichEntries.Add(new LootPackEntry(false, Instruments, 30.00, 3, 30, 1));
            FilthyRichEntries.Add(new LootPackEntry(false, MediumHealPotions, 60.00, 2));
            FilthyRichEntries.Add(new LootPackEntry(false, HighHealPotions, 45.00, 2));

            UltraRichEntries.Add(new LootPackEntry(true, Money, 100.00, Utility.Random(6000, 10000)));
            UltraRichEntries.Add(new LootPackEntry(false, ItemPack, 90.00, 3, 100, 2));
            UltraRichEntries.Add(new LootPackEntry(false, ItemPack, 75.00, 3, 100, 4));
            UltraRichEntries.Add(new LootPackEntry(false, ItemPack, 60.00, 3, 100, 6));
            UltraRichEntries.Add(new LootPackEntry(false, ItemPack, 45.00, 3, 75, 8));
            UltraRichEntries.Add(new LootPackEntry(false, ItemPack, 30.00, 2, 50, 10));
            UltraRichEntries.Add(new LootPackEntry(false, MedRares, 14.00, 1, 0, 0));
            UltraRichEntries.Add(new LootPackEntry(false, HighRares, 10.00, 1, 0, 0));
            UltraRichEntries.Add(new LootPackEntry(false, UltraRares, 1.00, 1, 0, 0));
            UltraRichEntries.Add(new LootPackEntry(false, Instruments, 45.00, 3, 30, 2));
            UltraRichEntries.Add(new LootPackEntry(false, MediumHealPotions, 80.00, 2));
            UltraRichEntries.Add(new LootPackEntry(false, HighHealPotions, 60.00, 2));

            BossEntries.Add(new LootPackEntry(true, Money, 100.00, Utility.Random(15000, 30000)));
            BossEntries.Add(new LootPackEntry(false, ItemPack, 95, 2, 100, 4));
            BossEntries.Add(new LootPackEntry(false, ItemPack, 95, 2, 75, 8));
            BossEntries.Add(new LootPackEntry(false, ItemPack, 95, 2, 50, 10));
            BossEntries.Add(new LootPackEntry(false, HighRares, 20, 2, 0, 0));
            BossEntries.Add(new LootPackEntry(false, UltraRares, 10, 1, 0, 0));

            UltraBossEntries.Add(new LootPackEntry(true, Money, 100.00, Utility.Random(25000, 45000)));
            UltraBossEntries.Add(new LootPackEntry(false, ItemPack, 90, 3, 100, 5));
            UltraBossEntries.Add(new LootPackEntry(false, ItemPack, 90, 3, 80, 8));
            UltraBossEntries.Add(new LootPackEntry(false, ItemPack, 90, 3, 55, 10));
            UltraBossEntries.Add(new LootPackEntry(false, HighRares, 30, 2, 0, 0));
            UltraBossEntries.Add(new LootPackEntry(false, UltraRares, 15, 1, 0, 0));

            UberBossEntries.Add(new LootPackEntry(true, Money, 100.00, Utility.Random(40000, 60000)));
            UberBossEntries.Add(new LootPackEntry(false, ItemPack, 85, 4, 100, 5));
            UberBossEntries.Add(new LootPackEntry(false, ItemPack, 85, 4, 82, 8));
            UberBossEntries.Add(new LootPackEntry(false, ItemPack, 85, 4, 57, 10));
            UberBossEntries.Add(new LootPackEntry(false, HighRares, 50, 3, 0, 0));
            UberBossEntries.Add(new LootPackEntry(false, UltraRares, 20, 2, 0, 0));

            ScrollEntries.Add(new LootPackEntry(false, Scroll, 50.0, 3));

            GemEntries.Add(new LootPackEntry(false, Gem, 50.0, 3));

            PotionEntries.Add(new LootPackEntry(false, Potion, 50.0, 4, 0, 0));

            MagicalEntries.Add(new LootPackEntry(false, Scroll, 100.0, 3, 0, 0));
            MagicalEntries.Add(new LootPackEntry(false, MageBooks, 2.0, 1, 0, 0));
        }

        public static readonly LootPack Poor = new LootPack(PoorEntries);
        public static readonly LootPack Meager = new LootPack(MeagerEntries);
        public static readonly LootPack Average = new LootPack(AverageEntries);
        public static readonly LootPack Rich = new LootPack(RichEntries);
        public static readonly LootPack FilthyRich = new LootPack(FilthyRichEntries);
        public static readonly LootPack UltraRich = new LootPack(UltraRichEntries);
        public static readonly LootPack Boss = new LootPack(BossEntries);
        public static readonly LootPack UltraBoss = new LootPack(UltraBossEntries);
        public static readonly LootPack UberBoss = new LootPack(UberBossEntries);

        public static readonly LootPack Scrolls = new LootPack(ScrollEntries);
        public static readonly LootPack Gems = new LootPack(GemEntries);
        public static readonly LootPack Potions = new LootPack(PotionEntries);
        public static readonly LootPack Magical = new LootPack(MagicalEntries);
        #endregion

        private List<LootPackEntry> m_Entries;

        public LootPack(List<LootPackEntry> entries)
        {
            m_Entries = entries;
        }

        public void Generate(Mobile m, Container cont, bool spawning, int luck)
        {
            int index = 0;
            foreach (LootPackEntry entry in m_Entries)
            {
                if (!entry.AtSpawnTime && spawning)
                {
                    index++;
                    continue;
                }

                int itemIndex = Utility.Random(entry.Types.Count);

                bool drop = false;
                if (entry.DropChance >= 100)
                    drop = true;
                else
                {
                    if (entry.DropChance >= Utility.Random(100))
                    {
                        //Console.WriteLine("Create: DropChance >= Creation Chance... ");
                        drop = true;
                    }
                }

                if (!drop)
                {
                    index++;
                    continue;
                }

                //Console.WriteLine("Create: Drop Test Passed");
                /*
                Item check = (Item)Activator.CreateInstance(entry.Types[itemIndex]);

                int loop = 1;
                if (!check.Stackable)
                    loop = entry.DropAmount;
                */

                for (int a = 0; a < ((entry.Types[itemIndex] == typeof(Gold)) ? 1 : entry.DropAmount); a++)
                {
                    Item looted = null;
                    if (entry.Types[itemIndex] == typeof(BasePotion))
                    {
                        int t = Utility.Random(LootPack.LowPotions.Count);
                        Server.LootPackItem lpi = new Server.LootPackItem(Custom.LootPack.LowPotions[t], 1);
                        looted = lpi.Construct(false);
                    }
                    else if (entry.Types[itemIndex] == typeof(TreasureMap))
                    {
                        looted = new TreasureMap(Utility.Random(5), Map.Felucca);
                        ((TreasureMap)looted).Decoder = m;
                    }
                    else if (entry.Types[itemIndex] == typeof(BaseRunicTool))
                    {
                        switch (Utility.Random(4))
                        {
                            case 0: looted = new RunicSewingKit(GetRandomLeather()); break;
                            case 1: looted = new RunicHammer(GetRandomMetal()); break;
                            case 2: looted = new RunicSaw(GetRandomWood()); break;
                            case 3: looted = new RunicFletcherTools(GetRandomWood()); break;
                            case 4: looted = new RunicSewingKit(GetRandomLeather()); break;//J.I.C
                        }
                    }
                    else
                    {
                        Server.LootPackItem lpi = new Server.LootPackItem(entry.Types[itemIndex], 1);
                        looted = lpi.Construct(false);
                    }

                    if (looted == null)
                    {
                        index++;
                        continue;
                    }

                    //Console.WriteLine("Create: Construct Test Passed");
                    //Console.WriteLine("Mutate: # of Possible Attributes = " + entry.AttributeAmount);

                    int chance = 0;
                    for (int b = 0; b < entry.AttributeAmount; b++)
                    {
                        chance = Utility.Random(100);
                        //Console.WriteLine("Mutate: Attach Chance " + chance);
                        int propCount = ItemProps.BonusCount(looted);
                        if (propCount < entry.AttributeAmount && entry.AttributeChance >= chance)
                        {
                            //Console.WriteLine("Mutate: Prop Chance >= Attach Chance");
                            looted = Mutate(m, luck, looted, index, itemIndex);
                        }
                    }

                    if (looted == null)
                    {
                        index++;
                        continue;
                    }

                    if (looted is BaseRanged/*.GetType().IsSubclassOf(typeof(BaseRanged))*/ && 1 >= Utility.Random(200))
                    {
                        ((BaseRanged)looted).EnergyBow = true;
                        ((BaseRanged)looted).EnergyCost = Utility.RandomMinMax(3, 10);
                    }

                    //if (looted.GetType() == typeof(ScrollofCombatSecrets) || 1 >= Utility.Random(1000))
                        //looted.LootType = LootType.Blessed;

                    if (looted.Stackable)
                        looted.Amount = entry.DropAmount;

                    //Skill Bonus Bug Fix
                    Custom.ItemProps.FixSkillBonuses(looted);

                    if (!cont.TryDropItem(m, looted, false))
                        cont.DropItem(looted);

                    if (entry.Types.Count > 1)
                        itemIndex = Utility.Random(entry.Types.Count);

                    if (looted.Stackable)
                        break;
                }

                index++;
            }
        }

        public Item Mutate(Mobile m, int luckChance, Item item, int index, int itemIndex)
        {
            if (item != null)
            {
                //Console.WriteLine("Mutate: Existance Check Passed");
                if (item is BaseWeapon && 1 > Utility.Random(100))
                {
                    //Console.WriteLine("Mutate: Created Fire Horn");
                    item.Delete();
                    item = new FireHorn();
                    return item;
                }

                if (item is BaseWeapon || item is BaseArmor || item is BaseJewel || item is BaseHat)
                {
                    int m_MinIntensity = m_Entries[index].AttributeAmount;
                    int m_MaxIntensity = (int)m_Entries[index].AttributeChance + (int)m_Entries[index].AttributeAmount;
                    //Console.WriteLine("Mutate: Intensity ({0},{1})", m_MinIntensity, m_MaxIntensity);

                    if (Core.AOS)
                    {
                        //Console.WriteLine("Mutate: -(AOS)-");
                        int bonusProps = Custom.ItemProps.BonusCount(item); //GetBonusProperties();
                        //int min = m_MinIntensity;
                        //int max = m_MaxIntensity;
                        int m_MaxProps = m_Entries[index].AttributeAmount;
                        //Console.WriteLine("Mutate: Current Props {0} :: Max Props {1}", bonusProps, m_MaxProps);

                        if (bonusProps < m_MaxProps)// && LootPack.CheckLuck(luckChance))
                            ++bonusProps;


                        int props = 1 + bonusProps;

                        // Make sure we're not spawning items with to many properties.
                        if (props > m_MaxProps)
                            props = m_MaxProps;

                        //Console.WriteLine("Mutate: Prop Check Passed");

                        if (item is BaseWeapon)
                            BaseRunicTool.ApplyAttributesTo((BaseWeapon)item, false, luckChance, props, m_MinIntensity, m_MaxIntensity);
                        else if (item is BaseArmor)
                            BaseRunicTool.ApplyAttributesTo((BaseArmor)item, false, luckChance, props, m_MinIntensity, m_MaxIntensity);
                        else if (item is BaseJewel)
                            BaseRunicTool.ApplyAttributesTo((BaseJewel)item, false, luckChance, props, m_MinIntensity, m_MaxIntensity);
                        else if (item is BaseHat)
                            BaseRunicTool.ApplyAttributesTo((BaseHat)item, false, luckChance, props, m_MinIntensity, m_MaxIntensity);
                    }
                    else // not aos
                    {
                        if (item is BaseWeapon)
                        {
                            BaseWeapon weapon = (BaseWeapon)item;

                            if (80 > Utility.Random(100))
                                weapon.AccuracyLevel = (WeaponAccuracyLevel)GetRandomOldBonus(m_MinIntensity, m_MaxIntensity);

                            if (60 > Utility.Random(100))
                                weapon.DamageLevel = (WeaponDamageLevel)GetRandomOldBonus(m_MinIntensity, m_MaxIntensity);

                            if (40 > Utility.Random(100))
                                weapon.DurabilityLevel = (WeaponDurabilityLevel)GetRandomOldBonus(m_MinIntensity, m_MaxIntensity);

                            if (5 > Utility.Random(100))
                                weapon.Slayer = SlayerName.Silver;

                            if (m != null && weapon.AccuracyLevel == 0 && weapon.DamageLevel == 0 && weapon.DurabilityLevel == 0 && weapon.Slayer == SlayerName.None && 5 > Utility.Random(100))
                                weapon.Slayer = SlayerGroup.GetLootSlayerType(m.GetType());
                        }
                        else if (item is BaseArmor)
                        {
                            BaseArmor armor = (BaseArmor)item;

                            if (80 > Utility.Random(100))
                                armor.ProtectionLevel = (ArmorProtectionLevel)GetRandomOldBonus(m_MinIntensity, m_MaxIntensity);

                            if (40 > Utility.Random(100))
                                armor.Durability = (ArmorDurabilityLevel)GetRandomOldBonus(m_MinIntensity, m_MaxIntensity);
                        }
                    }
                }
                else if (item is BaseInstrument)
                {
                    SlayerName slayer = SlayerName.None;

                    if (Core.AOS)
                        slayer = BaseRunicTool.GetRandomSlayer();
                    else
                        slayer = SlayerGroup.GetLootSlayerType(m.GetType());

                    if (slayer == SlayerName.None)
                    {
                        item.Delete();
                        return null;
                    }

                    BaseInstrument instr = (BaseInstrument)item;

                    instr.Quality = InstrumentQuality.Regular;
                    instr.Slayer = slayer;
                }

                if (item.Stackable)
                    item.Amount = m_Entries[index].DropAmount; //m_Quantity.Roll();
            }

            return item;
        }

        private int GetRandomOldBonus(int m_MinIntensity, int m_MaxIntensity)
        {
            int rnd = Utility.RandomMinMax(m_MinIntensity, m_MaxIntensity);

            if (50 > rnd)
                return 1;
            else
                rnd -= 50;

            if (25 > rnd)
                return 2;
            else
                rnd -= 25;

            if (14 > rnd)
                return 3;
            else
                rnd -= 14;

            if (8 > rnd)
                return 4;

            return 5;
        }

        public CraftResource GetRandomLeather()
        {
            switch (Utility.Random(3))
            {
                case 0: return CraftResource.SpinedLeather;
                case 1: return CraftResource.HornedLeather;
                case 2: return CraftResource.BarbedLeather;
                case 3: return CraftResource.SpinedLeather;
            }

            return CraftResource.SpinedLeather;
        }

        public CraftResource GetRandomMetal()
        {
            switch (Utility.Random(8))
            {
                case 0: return CraftResource.DullCopper;
                case 1: return CraftResource.ShadowIron;
                case 2: return CraftResource.Copper;
                case 3: return CraftResource.Bronze;
                case 4: return CraftResource.Gold;
                case 5: return CraftResource.Agapite;
                case 6: return CraftResource.Verite;
                case 7: return CraftResource.Valorite;
                case 8: return CraftResource.DullCopper;
            }

            return CraftResource.DullCopper;
        }

        public CraftResource GetRandomWood()
        {
            switch (Utility.Random(5))
            {
                case 0: return CraftResource.AshWood;
                case 1: return CraftResource.OakWood;
                case 2: return CraftResource.CherryWood;
                case 3: return CraftResource.MahoganyWood;
                case 4: return CraftResource.WalnutWood;
                case 5: return CraftResource.AshWood;
            }

            return CraftResource.AshWood;
        }

        #region [Item List]
        public static List<Type> Money = new List<Type>();
        public static List<Type> Weapons = new List<Type>();
        public static List<Type> Armor = new List<Type>();
        public static List<Type> Jewlery = new List<Type>();
        public static List<Type> Instruments = new List<Type>();
        public static List<Type> Scroll = new List<Type>();
        public static List<Type> MageBooks = new List<Type>();
        public static List<Type> Gem = new List<Type>();
        public static List<Type> LowPotions = new List<Type>();
        public static List<Type> MediumPotions = new List<Type>();
        public static List<Type> HighPotions = new List<Type>();
        public static List<Type> LowHealPotions = new List<Type>();
        public static List<Type> MediumHealPotions = new List<Type>();
        public static List<Type> HighHealPotions = new List<Type>();
        public static List<Type> LowRares = new List<Type>();
        public static List<Type> MedRares = new List<Type>();
        public static List<Type> HighRares = new List<Type>();
        public static List<Type> UltraRares = new List<Type>();
        public static List<List<Type>> Potion = new List<List<Type>>();
        public static List<List<Type>> ItemPack = new List<List<Type>>();

        public static void Configure()
        {
            Money.Add(typeof(Gold));

            Weapons.Add(typeof(BaseWeapon));
            Weapons.Add(typeof(BaseRanged));

            Armor.Add(typeof(BaseArmor));
            Armor.Add(typeof(BaseShield));

            Jewlery.Add(typeof(BaseJewel));

            Instruments.Add(typeof(BaseInstrument));

            Scroll.Add(typeof(SpellScroll));

            MageBooks.Add(typeof(Spellbook));
            MageBooks.Add(typeof(NecromancerSpellbook));
            MageBooks.Add(typeof(BookOfChivalry));
           // MageBooks.Add(typeof(ScrollofCombatSecrets));

            Gem.Add(typeof(Amber));

            LowPotions.Add(typeof(AgilityPotion));
            LowPotions.Add(typeof(LesserCurePotion));
            LowPotions.Add(typeof(LesserExplosionPotion));
            LowPotions.Add(typeof(LesserHealPotion));
            LowPotions.Add(typeof(LesserPoisonPotion));
            LowPotions.Add(typeof(RefreshPotion));
            LowPotions.Add(typeof(StrengthPotion));

            MediumPotions.Add(typeof(CurePotion));
            MediumPotions.Add(typeof(ExplosionPotion));
            MediumPotions.Add(typeof(HealPotion));
            MediumPotions.Add(typeof(PoisonPotion));

            HighPotions.Add(typeof(GreaterAgilityPotion));
            HighPotions.Add(typeof(GreaterCurePotion));
            HighPotions.Add(typeof(GreaterExplosionPotion));
            HighPotions.Add(typeof(GreaterHealPotion));
            HighPotions.Add(typeof(TotalRefreshPotion));
            HighPotions.Add(typeof(GreaterStrengthPotion));
            HighPotions.Add(typeof(GreaterPoisonPotion));
            HighPotions.Add(typeof(DeadlyPoisonPotion));

            LowHealPotions.Add(typeof(LesserCurePotion));
            LowHealPotions.Add(typeof(LesserHealPotion));

            MediumHealPotions.Add(typeof(CurePotion));
            MediumHealPotions.Add(typeof(HealPotion));

            HighHealPotions.Add(typeof(GreaterCurePotion));
            HighHealPotions.Add(typeof(GreaterHealPotion));

            LowRares.Add(typeof(IDWand));
            LowRares.Add(typeof(WeaversSpool));

            MedRares.Add(typeof(BasicShipKit));
            MedRares.Add(typeof(batleth));
            MedRares.Add(typeof(bonebreaker));
            MedRares.Add(typeof(Chaos));
            MedRares.Add(typeof(clubofthegiants));
            MedRares.Add(typeof(crimsondeath));
            MedRares.Add(typeof(crocodile));
            MedRares.Add(typeof(daggerofathousandplagues));
            MedRares.Add(typeof(daggeroftheelements));
            MedRares.Add(typeof(deathswind));
            MedRares.Add(typeof(DevourerofSouls));
            MedRares.Add(typeof(diamondclaws));
            MedRares.Add(typeof(dragonsmadness));
            MedRares.Add(typeof(Headhunter));
            MedRares.Add(typeof(hellsfire));
            MedRares.Add(typeof(katanaofrainewater));
            MedRares.Add(typeof(longbowoflight));
            MedRares.Add(typeof(maulofradioactivedecay));
            MedRares.Add(typeof(Raid));
            MedRares.Add(typeof(searingbladeofrainefire));
            MedRares.Add(typeof(staffofnagash));
            MedRares.Add(typeof(TheFifthElement));
            MedRares.Add(typeof(thevanquisher));
            MedRares.Add(typeof(twocobras));
            MedRares.Add(typeof(war));
            MedRares.Add(typeof(wrathofki));
            MedRares.Add(typeof(TreasureMap));
            MedRares.Add(typeof(ElvenQuiver));

            HighRares.Add(typeof(SpellChannelingDeed));
            HighRares.Add(typeof(EnhancementDeed));
            HighRares.Add(typeof(ArmorEnhancementDeed));
            HighRares.Add(typeof(WeaponEnhancementDeed));
            HighRares.Add(typeof(ElementEnhancementDeed));
            HighRares.Add(typeof(AosEnhancementDeed));
            HighRares.Add(typeof(BaseRunicTool));

            UltraRares.Add(typeof(SkillEnhancementDeed));
            UltraRares.Add(typeof(ScrollofCombatSecrets));

            Potion.Add(LowPotions);
            Potion.Add(MediumPotions);
            Potion.Add(HighPotions);

            ItemPack.Add(Weapons);
            ItemPack.Add(Armor);
            ItemPack.Add(Jewlery);
        }
        #endregion
    }

    public class LootPackEntry
    {
        bool m_AtSpawnTime;
        List<Type> m_Types = new List<Type>();
        int m_DropAmount, m_AttributeAmount;
        double m_DropChance, m_AttributeChance;

        public bool AtSpawnTime { get { return m_AtSpawnTime; } }

        public List<Type> Types { get { return m_Types; } }
        public int DropAmount { get { return m_DropAmount; } }
        public int AttributeAmount { get { return m_AttributeAmount; } }
        public double DropChance { get { return m_DropChance; } }
        public double AttributeChance { get { return m_AttributeChance; } }


        public LootPackEntry(bool spawnTime, List<Type> types, double chance, int amount) :
            this(spawnTime, types, chance, amount, 0, 0)
        {
        }

        public LootPackEntry(bool spawnTime, List<List<Type>> pack, double chance, int amount, double atrChance, int atrAmount)
        {
            ////Console.WriteLine("<ITEM PACK>");
            List<Type> newList = new List<Type>();
            foreach (List<Type> typeList in pack)
            {
                ////Console.WriteLine("    |Pack List|");
                foreach (Type type in typeList)
                {
                    ////Console.WriteLine("        [List Item] {" + type.ToString() + "}");
                    newList.Add(type);
                }
            }

            m_AtSpawnTime = spawnTime;
            m_Types = newList;
            m_DropChance = chance;
            m_DropAmount = amount;
            m_AttributeChance = atrChance;
            m_AttributeAmount = atrAmount;
        }

        public LootPackEntry(bool spawnTime, List<Type> types, double chance, int amount, double atrChance, int atrAmount)
        {
            m_AtSpawnTime = spawnTime;
            m_Types = types;
            m_DropChance = chance;
            m_DropAmount = amount;
            m_AttributeChance = atrChance;
            m_AttributeAmount = atrAmount;
        }
    }
}