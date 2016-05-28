using System;

using Server;
using Server.Mobiles;

namespace Custom
{
    public class LevelTable
    {
        public static void Configure()
        {
            StaticLevel.Add(typeof(Chicken), 1, 3);
            StaticLevel.Add(typeof(Bird), 1, 3);
            StaticLevel.Add(typeof(Sewerrat), 1, 3);
           // StaticLevel.Add(typeof(Turkey), 1, 3);
            StaticLevel.Add(typeof(Rat), 1, 3);
            StaticLevel.Add(typeof(Rabbit), 1, 3);
            StaticLevel.Add(typeof(Scorpion), 1, 3);
           // StaticLevel.Add(typeof(Spider), 1, 3);
           // StaticLevel.Add(typeof(Frog), 1, 3);
            StaticLevel.Add(typeof(Crane), 2, 4);
            StaticLevel.Add(typeof(Cat), 2, 4);
            StaticLevel.Add(typeof(Dog), 2, 4);
            StaticLevel.Add(typeof(Pig), 4, 6);
            StaticLevel.Add(typeof(Cow), 4, 6);
            StaticLevel.Add(typeof(Sheep), 4, 6);
            StaticLevel.Add(typeof(Eagle), 4, 6);
            StaticLevel.Add(typeof(Goat), 4, 6);
            StaticLevel.Add(typeof(Hind), 4, 6);
            StaticLevel.Add(typeof(RidableLlama), 4, 6);
            StaticLevel.Add(typeof(Llama), 4, 6);
            StaticLevel.Add(typeof(Horse), 4, 6);
            StaticLevel.Add(typeof(PackHorse), 4, 6);
            StaticLevel.Add(typeof(PackLlama), 4, 6);
            StaticLevel.Add(typeof(MountainGoat), 4, 6);
            StaticLevel.Add(typeof(Walrus), 5, 7);
            StaticLevel.Add(typeof(Gorilla), 5, 7);
            StaticLevel.Add(typeof(GreatHart), 5, 7);
            StaticLevel.Add(typeof(Dolphin), 5, 7);
            StaticLevel.Add(typeof(BullFrog), 5, 7);
            StaticLevel.Add(typeof(Slime), 5, 7);
            StaticLevel.Add(typeof(CorrosiveSlime), 5, 7);
            StaticLevel.Add(typeof(Snake), 5, 7);
            StaticLevel.Add(typeof(Mongbat), 5, 7);
            StaticLevel.Add(typeof(GreaterMongbat), 5, 7);
            StaticLevel.Add(typeof(FrostOoze), 5, 7);
            StaticLevel.Add(typeof(GiantRat), 5, 7);
            StaticLevel.Add(typeof(JackRabbit), 5, 7);
            StaticLevel.Add(typeof(GiantBlackWidow), 5, 7);
            StaticLevel.Add(typeof(BlackBear), 6, 8);
            StaticLevel.Add(typeof(Boar), 6, 8);
            StaticLevel.Add(typeof(BrownBear), 6, 8);
            StaticLevel.Add(typeof(GrizzlyBear), 6, 8);
            StaticLevel.Add(typeof(PolarBear), 6, 8);
            StaticLevel.Add(typeof(DireWolf), 6, 8);
            StaticLevel.Add(typeof(GreyWolf), 6, 8);
            StaticLevel.Add(typeof(TimberWolf), 6, 8);
            StaticLevel.Add(typeof(WhiteWolf), 6, 8);
            StaticLevel.Add(typeof(DeathwatchBeetleHatchling), 6, 8);
            StaticLevel.Add(typeof(Goat), 6, 8);
            StaticLevel.Add(typeof(Panther), 6, 8);
            StaticLevel.Add(typeof(SnowLeopard), 6, 8);
            StaticLevel.Add(typeof(Cougar), 6, 8);
            StaticLevel.Add(typeof(HellCat), 6, 8);
            StaticLevel.Add(typeof(IceSnake), 6, 8);
            StaticLevel.Add(typeof(LavaSnake), 6, 8);
            StaticLevel.Add(typeof(StrongMongbat), 8, 10);
            StaticLevel.Add(typeof(DesertOstard), 8, 10);
            StaticLevel.Add(typeof(ForestOstard), 8, 10);
            StaticLevel.Add(typeof(FrenziedOstard), 8, 10);
            StaticLevel.Add(typeof(HellHound), 8, 10);
            StaticLevel.Add(typeof(Ridgeback), 8, 10);
            StaticLevel.Add(typeof(SavageRidgeback), 9, 10);
            StaticLevel.Add(typeof(Bull), 9, 10);
            StaticLevel.Add(typeof(HeadlessOne), 9, 10);
            StaticLevel.Add(typeof(GazerLarva), 9, 10);
            StaticLevel.Add(typeof(HordeMinion), 10, 13);
            StaticLevel.Add(typeof(Ghoul), 10, 13);
            StaticLevel.Add(typeof(Shade), 10, 13);
            StaticLevel.Add(typeof(DeathwatchBeetle), 10, 13);
            StaticLevel.Add(typeof(Gazer), 10, 13);
            StaticLevel.Add(typeof(Spectre), 10, 13);
            StaticLevel.Add(typeof(Zombie), 10, 13);
            StaticLevel.Add(typeof(RestlessSoul), 10, 13);
            StaticLevel.Add(typeof(Skeleton), 10, 13);
            StaticLevel.Add(typeof(Orc), 10, 13);
            StaticLevel.Add(typeof(Ratman), 10, 13);
            StaticLevel.Add(typeof(Wraith), 10, 13);
            StaticLevel.Add(typeof(Imp), 10, 13);
            StaticLevel.Add(typeof(SkitteringHopper), 10, 13);
            StaticLevel.Add(typeof(Wisp), 10, 13);
           // StaticLevel.Add(typeof(UndeadBull), 10, 13);
            StaticLevel.Add(typeof(PlagueSpawn), 12, 15);
            StaticLevel.Add(typeof(Alligator), 12, 15);
            StaticLevel.Add(typeof(BoneKnight), 12, 15);
            StaticLevel.Add(typeof(SkeletalMage), 12, 15);
            StaticLevel.Add(typeof(OrcishMage), 12, 15);
            StaticLevel.Add(typeof(RatmanArcher), 12, 15);
            StaticLevel.Add(typeof(RatmanMage), 12, 15);
            StaticLevel.Add(typeof(ElderGazer), 12, 15);
            StaticLevel.Add(typeof(BoneMagi), 12, 15);
            StaticLevel.Add(typeof(CorruptedSoul), 12, 15);
            StaticLevel.Add(typeof(Troll), 12, 15);
           // StaticLevel.Add(typeof(GiantScorpion), 12, 15);
            StaticLevel.Add(typeof(GiantSpider), 12, 15);
            StaticLevel.Add(typeof(Gibberling), 12, 15);
            StaticLevel.Add(typeof(GiantToad), 12, 15);
            StaticLevel.Add(typeof(VampireBat), 12, 15);
            StaticLevel.Add(typeof(FrostSpider), 12, 15);
            StaticLevel.Add(typeof(OrcBomber), 12, 15);
            StaticLevel.Add(typeof(Ogre), 12, 15);
            StaticLevel.Add(typeof(Ettin), 12, 15);
            StaticLevel.Add(typeof(Reaper), 12, 15);
            StaticLevel.Add(typeof(SpectralArmour), 14, 17);
            StaticLevel.Add(typeof(Bogle), 14, 17);
            StaticLevel.Add(typeof(Treefellow), 14, 17);
            StaticLevel.Add(typeof(Savage), 14, 17);
            StaticLevel.Add(typeof(PatchworkSkeleton), 14, 17);
            StaticLevel.Add(typeof(Harpy), 14, 17);
            StaticLevel.Add(typeof(TerathanDrone), 14, 17);
            StaticLevel.Add(typeof(Bogling), 14, 17);
            StaticLevel.Add(typeof(Lizardman), 14, 17);
            StaticLevel.Add(typeof(Corpser), 14, 17);
            StaticLevel.Add(typeof(SwampTentacle), 14, 17);
            StaticLevel.Add(typeof(WhippingVine), 14, 17);
            StaticLevel.Add(typeof(WailingBanshee), 17, 20);
            StaticLevel.Add(typeof(MoundOfMaggots), 17, 20);
            StaticLevel.Add(typeof(Gaman), 17, 20);
            StaticLevel.Add(typeof(LavaLizard), 17, 20);
            StaticLevel.Add(typeof(Quagmire), 17, 20);
            StaticLevel.Add(typeof(Kappa), 17, 20);
            StaticLevel.Add(typeof(SeaSerpent), 17, 20);
            StaticLevel.Add(typeof(Mummy), 17, 20);
            StaticLevel.Add(typeof(StoneHarpy), 17, 20);
            StaticLevel.Add(typeof(Cursed), 17, 20);
            StaticLevel.Add(typeof(SavageShaman), 17, 20);
            StaticLevel.Add(typeof(Gargoyle), 17, 20);
            StaticLevel.Add(typeof(SandVortex), 17, 20);
          //  StaticLevel.Add(typeof(Noonwraith), 17, 20);
          //  StaticLevel.Add(typeof(RatmanLord), 20, 25);
          //  StaticLevel.Add(typeof(Banshee), 20, 25);
            StaticLevel.Add(typeof(SavageRider), 20, 25);
            StaticLevel.Add(typeof(GiantSerpent), 20, 25);
            StaticLevel.Add(typeof(PredatorHellCat), 20, 25);
            StaticLevel.Add(typeof(IceSerpent), 20, 25);
            StaticLevel.Add(typeof(LavaSerpent), 20, 25);
            StaticLevel.Add(typeof(SilverSerpent), 20, 25);
            StaticLevel.Add(typeof(FireGargoyle), 20, 25);
            StaticLevel.Add(typeof(StoneGargoyle), 20, 25);
            StaticLevel.Add(typeof(EnslavedGargoyle), 20, 25);
            StaticLevel.Add(typeof(DeepSeaSerpent), 20, 25);
            StaticLevel.Add(typeof(Pixie), 20, 25);
            StaticLevel.Add(typeof(OrcCaptain), 20, 25);
            StaticLevel.Add(typeof(SkeletalKnight), 20, 25);
            StaticLevel.Add(typeof(FrostTroll), 20, 25);
            StaticLevel.Add(typeof(DreadSpider), 20, 25);
            StaticLevel.Add(typeof(Brigand), 20, 25);
            StaticLevel.Add(typeof(Centaur), 25, 30);
            StaticLevel.Add(typeof(OrcishLord), 25, 30);
            StaticLevel.Add(typeof(OrcScout), 25, 30);
            StaticLevel.Add(typeof(Cyclops), 25, 30);
            StaticLevel.Add(typeof(GargoyleEnforcer), 25, 30);
            StaticLevel.Add(typeof(BlackSolenWorker), 25, 30);
            StaticLevel.Add(typeof(RedSolenWorker), 25, 30);
            StaticLevel.Add(typeof(SwampDragon), 25, 30);
            StaticLevel.Add(typeof(TerathanWarrior), 25, 30);
            StaticLevel.Add(typeof(GoreFiend), 25, 30);
            StaticLevel.Add(typeof(ShadowFiend), 25, 30);
            StaticLevel.Add(typeof(Troglodyte), 25, 30);
            StaticLevel.Add(typeof(OphidianWarrior), 25, 30);
            StaticLevel.Add(typeof(RevenantLion), 25, 30);
            StaticLevel.Add(typeof(PlagueBeast), 25, 30);
           /* StaticLevel.Add(typeof(WaterOstard), 25, 30);
            StaticLevel.Add(typeof(FireOstard), 25, 30);
            StaticLevel.Add(typeof(EarthOstard), 25, 30);
            StaticLevel.Add(typeof(AirOstard), 25, 30);
            StaticLevel.Add(typeof(WaterFrenziedOstard), 30, 35);
            StaticLevel.Add(typeof(FireFrenziedOstard), 30, 35);
            StaticLevel.Add(typeof(EarthFrenziedOstard), 30, 35);
            StaticLevel.Add(typeof(AirFrenziedOstard), 30, 35);*/
            StaticLevel.Add(typeof(Doppleganger), 30, 35);
            StaticLevel.Add(typeof(Beetle), 30, 35);
            StaticLevel.Add(typeof(ScaledSwampDragon), 30, 35);
            StaticLevel.Add(typeof(AirElemental), 30, 35);
            StaticLevel.Add(typeof(FireElemental), 30, 35);
            StaticLevel.Add(typeof(WaterElemental), 30, 35);
            StaticLevel.Add(typeof(EarthElemental), 30, 35);
            StaticLevel.Add(typeof(SnowElemental), 30, 35);
            StaticLevel.Add(typeof(AgapiteElemental), 30, 35);
            StaticLevel.Add(typeof(BronzeElemental), 30, 35);
            StaticLevel.Add(typeof(CopperElemental), 30, 35);
            StaticLevel.Add(typeof(DullCopperElemental), 30, 35);
            StaticLevel.Add(typeof(GoldenElemental), 30, 35);
            StaticLevel.Add(typeof(ShadowIronElemental), 30, 35);
            StaticLevel.Add(typeof(IceElemental), 35, 40);
            StaticLevel.Add(typeof(PoisonElemental), 35, 40);
            StaticLevel.Add(typeof(ToxicElemental), 35, 40);
            StaticLevel.Add(typeof(VeriteElemental), 35, 40);
            StaticLevel.Add(typeof(OphidianArchmage), 35, 40);
            StaticLevel.Add(typeof(OphidianKnight), 35, 40);
            StaticLevel.Add(typeof(OphidianMage), 35, 40);
            StaticLevel.Add(typeof(Phoenix), 35, 40);
            StaticLevel.Add(typeof(Ronin), 35, 40);
            StaticLevel.Add(typeof(TerathanAvenger), 35, 40);
          /*  StaticLevel.Add(typeof(Crawler), 30, 35);
            StaticLevel.Add(typeof(IceOstard), 35, 40);
            StaticLevel.Add(typeof(SnowOstard), 35, 40);
            StaticLevel.Add(typeof(LavaOstard), 35, 40);
            StaticLevel.Add(typeof(LightningOstard), 35, 40);
            StaticLevel.Add(typeof(IceFrenziedOstard), 40, 45);
            StaticLevel.Add(typeof(SnowFrenziedOstard), 40, 45);
            StaticLevel.Add(typeof(LavaFrenziedOstard), 40, 45);
            StaticLevel.Add(typeof(LightningFrenziedOstard), 40, 45);*/
            StaticLevel.Add(typeof(ValoriteElemental), 40, 45);
            StaticLevel.Add(typeof(Lich), 40, 45);
            StaticLevel.Add(typeof(PestilentBandage), 40, 45);
            StaticLevel.Add(typeof(Efreet), 40, 45);
            StaticLevel.Add(typeof(EvilMage), 40, 45);
            StaticLevel.Add(typeof(TerathanMatriarch), 40, 45);
            StaticLevel.Add(typeof(Drake), 40, 45);
           // StaticLevel.Add(typeof(MasterBrigand), 40, 45);
            StaticLevel.Add(typeof(BlackSolenWarrior), 40, 45);
            StaticLevel.Add(typeof(RedSolenWarrior), 40, 45);
            StaticLevel.Add(typeof(RedSolenInfiltratorWarrior), 40, 45);
            StaticLevel.Add(typeof(BlackSolenInfiltratorWarrior), 40, 45);
            StaticLevel.Add(typeof(OphidianMatriarch), 40, 45);
           /* StaticLevel.Add(typeof(GoatmanArcher), 40, 45);
            StaticLevel.Add(typeof(GoatmanWarrior), 40, 45);
            StaticLevel.Add(typeof(Ignus), 40, 45);
            StaticLevel.Add(typeof(DeepWyvern), 40, 45);
            StaticLevel.Add(typeof(VolcanoWyvern), 40, 45);
            StaticLevel.Add(typeof(AirElementalLord), 40, 45);
            StaticLevel.Add(typeof(FireElementalLord), 40, 45);
            StaticLevel.Add(typeof(WaterElementalLord), 40, 45);
            StaticLevel.Add(typeof(EarthElementalLord), 40, 45);
            StaticLevel.Add(typeof(SnowElementalLord), 40, 45);
            StaticLevel.Add(typeof(AgapiteElementalLord), 40, 45);
            StaticLevel.Add(typeof(BronzeElementalLord), 40, 45);
            StaticLevel.Add(typeof(CopperElementalLord), 40, 45);
            StaticLevel.Add(typeof(DullCopperElementalLord), 40, 45);
            StaticLevel.Add(typeof(DullCopperElementalLord), 40, 45);
            StaticLevel.Add(typeof(GoldenElementalLord), 40, 45);
            StaticLevel.Add(typeof(ShadowIronElementalLord), 40, 45);
            StaticLevel.Add(typeof(IceElementalLord), 45, 50);
            StaticLevel.Add(typeof(PoisonElementalLord), 45, 50);
            StaticLevel.Add(typeof(ToxicElementalLord), 45, 50);
            StaticLevel.Add(typeof(VeriteElementalLord), 45, 50);*/
            StaticLevel.Add(typeof(AntLion), 45, 50);
            StaticLevel.Add(typeof(BlackSolenInfiltratorQueen), 45, 50);
            StaticLevel.Add(typeof(BlackSolenQueen), 45, 50);
            StaticLevel.Add(typeof(RedSolenInfiltratorQueen), 45, 50);
            StaticLevel.Add(typeof(RedSolenQueen), 45, 50);
            StaticLevel.Add(typeof(CrystalElemental), 45, 50);
          /*  StaticLevel.Add(typeof(ElderOstard), 45, 50);
            StaticLevel.Add(typeof(BloodOstard), 45, 50);
            StaticLevel.Add(typeof(VoidOstard), 45, 50);
            StaticLevel.Add(typeof(SwiftOstard), 45, 50);
            StaticLevel.Add(typeof(CorpseOstard), 45, 50);
            StaticLevel.Add(typeof(PlacidOstard), 45, 50);
            StaticLevel.Add(typeof(WhiteWyrmling), 45, 50);
            StaticLevel.Add(typeof(WaterDrake), 45, 50);
            StaticLevel.Add(typeof(FireDrake), 45, 50);
            StaticLevel.Add(typeof(AirDrake), 45, 50);
            StaticLevel.Add(typeof(EarthDrake), 45, 50);
            StaticLevel.Add(typeof(Wyvern), 45, 50);
            StaticLevel.Add(typeof(IceDrake), 50, 55);
            StaticLevel.Add(typeof(LavaDrake), 50, 55);
            StaticLevel.Add(typeof(StormDrake), 50, 55);
            StaticLevel.Add(typeof(UndeadDrake), 50, 55);
            StaticLevel.Add(typeof(PoisonDrake), 50, 55);
            StaticLevel.Add(typeof(ElderFrenziedOstard), 50, 55);
            StaticLevel.Add(typeof(BloodFrenziedOstard), 50, 55);
            StaticLevel.Add(typeof(VoidFrenziedOstard), 50, 55);
            StaticLevel.Add(typeof(SwiftFrenziedOstard), 50, 55);
            StaticLevel.Add(typeof(CorpseFrenziedOstard), 50, 55);
            StaticLevel.Add(typeof(PlacidFrenziedOstard), 50, 55);*/
            StaticLevel.Add(typeof(IceFiend), 50, 55);
            StaticLevel.Add(typeof(Betrayer), 50, 55);
            StaticLevel.Add(typeof(BloodElemental), 50, 55);
            StaticLevel.Add(typeof(Daemon), 50, 55);
            StaticLevel.Add(typeof(Golem), 50, 55);
            StaticLevel.Add(typeof(GolemController), 50, 55);
            StaticLevel.Add(typeof(EvilMageLord), 50, 55);
            StaticLevel.Add(typeof(SkeletalMount), 50, 55);
            StaticLevel.Add(typeof(LadyOfTheSnow), 50, 55);
            StaticLevel.Add(typeof(EliteNinja), 50, 55);
            StaticLevel.Add(typeof(FanDancer), 50, 55);
            StaticLevel.Add(typeof(FireBeetle), 50, 55);
            StaticLevel.Add(typeof(FireSteed), 50, 55);
            StaticLevel.Add(typeof(HellSteed), 50, 55);
            StaticLevel.Add(typeof(SilverSteed), 50, 55);
            StaticLevel.Add(typeof(Kirin), 50, 55);
          /*  StaticLevel.Add(typeof(Seeker), 50, 55);
            StaticLevel.Add(typeof(IceDaemon), 50, 55);
            StaticLevel.Add(typeof(Yeti), 50, 55);
            StaticLevel.Add(typeof(GreatBallofFire), 50, 55);
            StaticLevel.Add(typeof(BabyMinotaur), 50, 55);
            StaticLevel.Add(typeof(VenusPeopleTrap), 55, 60);
            StaticLevel.Add(typeof(UmberHulk), 55, 60);
            StaticLevel.Add(typeof(CrystalElementalLord), 55, 60);*/
            StaticLevel.Add(typeof(GargoyleDestroyer), 55, 60);
            StaticLevel.Add(typeof(LesserHiryu), 55, 60);
            StaticLevel.Add(typeof(Nightmare), 55, 60);
            StaticLevel.Add(typeof(Unicorn), 55, 60);
            StaticLevel.Add(typeof(BogThing), 55, 60);
            StaticLevel.Add(typeof(ChaosDaemon), 55, 60);
            StaticLevel.Add(typeof(JukaWarrior), 55, 60);
            StaticLevel.Add(typeof(MeerWarrior), 55, 60);
            StaticLevel.Add(typeof(LichLord), 55, 60);
            StaticLevel.Add(typeof(RottingCorpse), 55, 60);
            StaticLevel.Add(typeof(ExodusMinion), 55, 60);
           /* StaticLevel.Add(typeof(OstardofDreams), 55, 60);
            StaticLevel.Add(typeof(OstardofRage), 55, 60);
            StaticLevel.Add(typeof(OstardoftheCrypt), 55, 60);
            StaticLevel.Add(typeof(FrenziedOstardofDreams), 60, 65);
            StaticLevel.Add(typeof(FrenziedOstardofRage), 60, 65);
            StaticLevel.Add(typeof(FrenziedOstardoftheCrypt), 60, 65);
            StaticLevel.Add(typeof(BloodElementalLord), 60, 65);*/
            StaticLevel.Add(typeof(Succubus), 60, 65);
            StaticLevel.Add(typeof(Titan), 60, 65);
            StaticLevel.Add(typeof(OgreLord), 60, 65);
            StaticLevel.Add(typeof(ArcticOgreLord), 60, 65);
           // StaticLevel.Add(typeof(Temptress), 60, 65);
            StaticLevel.Add(typeof(ArcaneDaemon), 60, 65);
            StaticLevel.Add(typeof(FleshGolem), 60, 65);
            StaticLevel.Add(typeof(Dragon), 65, 70);
          //  StaticLevel.Add(typeof(GoldenDrake), 65, 70);
          //  StaticLevel.Add(typeof(HeavenlyDrake), 65, 70);
            StaticLevel.Add(typeof(JukaMage), 65, 70);
            StaticLevel.Add(typeof(MeerCaptain), 65, 70);
            StaticLevel.Add(typeof(MeerMage), 65, 70);
            StaticLevel.Add(typeof(Oni), 65, 70);
            StaticLevel.Add(typeof(CrystalDaemon), 65, 70);
          //  StaticLevel.Add(typeof(Beastman), 65, 70);
          //  StaticLevel.Add(typeof(DaemonLieutenant), 70, 75);
            StaticLevel.Add(typeof(JukaLord), 70, 75);
            StaticLevel.Add(typeof(Hiryu), 70, 75);
            StaticLevel.Add(typeof(MeerEternal), 70, 75);
            StaticLevel.Add(typeof(WhiteWyrm), 75, 80);
            StaticLevel.Add(typeof(ShadowWyrm), 75, 80);
            StaticLevel.Add(typeof(SerpentineDragon), 75, 80);
            StaticLevel.Add(typeof(WandererOfTheVoid), 75, 80);
            StaticLevel.Add(typeof(YomotsuPriest), 75, 80);
            StaticLevel.Add(typeof(YomotsuWarrior), 75, 80);
          /*  StaticLevel.Add(typeof(ForestWraith), 75, 80);
            StaticLevel.Add(typeof(BeastmanLord), 75, 80);
            StaticLevel.Add(typeof(WaterDragon), 75, 80);
            StaticLevel.Add(typeof(FireDragon), 75, 80);
            StaticLevel.Add(typeof(AirDragon), 75, 80);
            StaticLevel.Add(typeof(EarthDragon), 75, 80);
            StaticLevel.Add(typeof(IceDragon), 80, 85);
            StaticLevel.Add(typeof(SandDragon), 80, 85);
            StaticLevel.Add(typeof(LavaDragon), 80, 85);
            StaticLevel.Add(typeof(StormDragon), 80, 85);
            StaticLevel.Add(typeof(UndeadDragon), 80, 85);
            StaticLevel.Add(typeof(PoisonDragon), 80, 85);
            StaticLevel.Add(typeof(BlackWisp), 80, 85);*/
            StaticLevel.Add(typeof(ShadowWisp), 80, 85);
            StaticLevel.Add(typeof(RaiJu), 80, 85);
            StaticLevel.Add(typeof(AncientLich), 80, 85);
            StaticLevel.Add(typeof(SkeletalDragon), 80, 85);
            StaticLevel.Add(typeof(YomotsuElder), 80, 85);
            StaticLevel.Add(typeof(ExodusOverseer), 80, 85);
          /*  StaticLevel.Add(typeof(ArcaneDaemonLord), 80, 85);
            StaticLevel.Add(typeof(ChaosDaemonLord), 80, 85);
            StaticLevel.Add(typeof(TempestDaemon), 85, 90);*/
            StaticLevel.Add(typeof(OrcBrute), 85, 90);
            StaticLevel.Add(typeof(Moloch), 85, 90);
            StaticLevel.Add(typeof(FetidEssence), 85, 90);
            StaticLevel.Add(typeof(Satyr), 85, 90);
            StaticLevel.Add(typeof(BakeKitsune), 85, 90);
          /*  StaticLevel.Add(typeof(Mauler), 85, 90);
            StaticLevel.Add(typeof(Naga), 85, 90);
            StaticLevel.Add(typeof(Starburst), 90, 100);
            StaticLevel.Add(typeof(HillGiant), 90, 100);
            StaticLevel.Add(typeof(MountainGiant), 90, 100);*/
            StaticLevel.Add(typeof(PlagueBeastLord), 90, 100);
            StaticLevel.Add(typeof(Kraken), 90, 100);
            StaticLevel.Add(typeof(Devourer), 90, 100);
            StaticLevel.Add(typeof(CuSidhe), 90, 100);
            StaticLevel.Add(typeof(Juggernaut), 90, 100);
            StaticLevel.Add(typeof(InterredGrizzle), 90, 100);
            StaticLevel.Add(typeof(KazeKemono), 90, 100);
            StaticLevel.Add(typeof(Balron), 90, 100);
            StaticLevel.Add(typeof(BoneDemon), 90, 100);
          /*  StaticLevel.Add(typeof(TrasherDaemon), 90, 100);
            StaticLevel.Add(typeof(FourArmedDaemon), 90, 100);
            StaticLevel.Add(typeof(Balrog), 90, 100);*/
            StaticLevel.Add(typeof(Ravager), 90, 100);
            StaticLevel.Add(typeof(ChaosDragoon), 100, 110);
            StaticLevel.Add(typeof(ChaosDragoonElite), 100, 110);
            StaticLevel.Add(typeof(FerelTreefellow), 100, 110);
            StaticLevel.Add(typeof(VorpalBunny), 100, 110);
            StaticLevel.Add(typeof(Executioner), 100, 110);
            StaticLevel.Add(typeof(KhaldunRevenant), 100, 110);
            StaticLevel.Add(typeof(KhaldunSummoner), 100, 110);
            StaticLevel.Add(typeof(KhaldunZealot), 100, 110);
            StaticLevel.Add(typeof(Minotaur), 100, 110);
            StaticLevel.Add(typeof(MinotaurScout), 100, 110);
          //  StaticLevel.Add(typeof(PurplePeopleEater), 100, 110);
          //  StaticLevel.Add(typeof(RhinocerosBeetle), 110, 120);
            StaticLevel.Add(typeof(Leviathan), 110, 120);
            StaticLevel.Add(typeof(MinotaurCaptain), 110, 120);
            StaticLevel.Add(typeof(EtherealWarrior), 110, 120);
            StaticLevel.Add(typeof(RuneBeetle), 110, 120);
            StaticLevel.Add(typeof(DarknightCreeper), 110, 120);
            StaticLevel.Add(typeof(FleshRenderer), 110, 120);
            StaticLevel.Add(typeof(AbysmalHorror), 110, 120);
            StaticLevel.Add(typeof(Impaler), 110, 120);
            StaticLevel.Add(typeof(TsukiWolf), 110, 120);
          /*  StaticLevel.Add(typeof(GoldenDragon), 110, 120);
            StaticLevel.Add(typeof(HeavenlyDragon), 110, 120);
            StaticLevel.Add(typeof(VoidDaemon), 110, 120);
            StaticLevel.Add(typeof(DesireDaemon), 110, 120);
            StaticLevel.Add(typeof(Silvani), 110, 120);
            StaticLevel.Add(typeof(DaemonLord), 120, 130); 
            StaticLevel.Add(typeof(BlackDragon), 120, 130); */
            StaticLevel.Add(typeof(GreaterDragon), 120, 130);
            StaticLevel.Add(typeof(Yamandon), 120, 130);
            StaticLevel.Add(typeof(Guardian), 120, 130);
            StaticLevel.Add(typeof(ShadowKnight), 120, 130);
            StaticLevel.Add(typeof(AncientWyrm), 120, 130);
           /* StaticLevel.Add(typeof(Remorhaz), 120, 130);
            StaticLevel.Add(typeof(EvilSnowman), 130, 140);
            StaticLevel.Add(typeof(DemonKnight), 149);
            StaticLevel.Add(typeof(Diablo), 149);*/
            StaticLevel.Add(typeof(Barracoon), 149);
            StaticLevel.Add(typeof(Harrower), 149);
            StaticLevel.Add(typeof(LordOaks), 149);
            StaticLevel.Add(typeof(Mephitis), 149);
            StaticLevel.Add(typeof(Neira), 149);
            StaticLevel.Add(typeof(Rikktor), 149);
            StaticLevel.Add(typeof(Semidar), 149);
            StaticLevel.Add(typeof(Ilhenir), 149);
            StaticLevel.Add(typeof(Meraktus), 149);
            StaticLevel.Add(typeof(Serado), 149);
            StaticLevel.Add(typeof(Twaulo), 149);
          /*  StaticLevel.Add(typeof(SinisterMageLord), 149);
            StaticLevel.Add(typeof(KingLeoric), 149);
            StaticLevel.Add(typeof(Hephaestus), 149);
            StaticLevel.Add(typeof(TheCowKing), 149);
            StaticLevel.Add(typeof(Andariel), 149);*/
            StaticLevel.Add(typeof(MonstrousInterredGrizzle), 174);
        }
    }
}