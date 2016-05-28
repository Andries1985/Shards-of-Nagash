using System;
using System.Collections.Generic;

using Server;
using Server.Misc;
using Server.Items;
using Server.Gumps;
using Server.Customs;
using Server.Mobiles;
using Server.Network;

using Custom;

namespace Custom.Gumps
{
    public class ClassSelectGump : Server.Gumps.Gump
    {
        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler(Login_Event);
        }

        public static void Login_Event(LoginEventArgs e)
        {
            PlayerMobile pm = (PlayerMobile)e.Mobile;
            if (pm.Class == Class.None)
                pm.SendGump(new ClassSelectGump(pm.Class));
        }

        public Class selected = Class.None;

        public ClassSelectGump(Class on)
            : base(0, 0)
        {
            selected = on;

            Closable = false;
            Disposable = false;
            Dragable = true;
            Resizable = false;
            AddPage(0);
            AddBackground(64, 79, 478, 312, 9270);
            AddAlphaRegion(193, 123, 324, 255);
            AddAlphaRegion(81, 95, 442, 21);
            AddLabel(258, 96, 1953, @"Class Chooser");
            AddButton(80, 160, 2445, 2445, (int)Buttons.Warrior_Button, GumpButtonType.Reply, 0);
            AddButton(80, 190, 2445, 2445, (int)Buttons.Ranger_Button, GumpButtonType.Reply, 0);
            AddButton(80, 220, 2445, 2445, (int)Buttons.Thief_Button, GumpButtonType.Reply, 0);
            AddButton(80, 250, 2445, 2445, (int)Buttons.Bard_Button, GumpButtonType.Reply, 0);
            AddButton(80, 280, 2445, 2445, (int)Buttons.Crafter_Button, GumpButtonType.Reply, 0);
            AddButton(80, 130, 2445, 2445, (int)Buttons.Mage_Button, GumpButtonType.Reply, 0);
            AddLabel(118, 131, 1953, @"Mage");
            AddLabel(105, 162, 1953, @"Warrior");
            AddLabel(111, 192, 1953, @"Ranger");
            AddLabel(115, 222, 1953, @"Thief");
            AddLabel(117, 252, 1953, @"Bard");
            AddLabel(107, 283, 1953, @"Crafter");
            AddHtml(195, 124, 335, 251, @"" + GetClassFile(selected), (bool)false, (bool)true);

            if (selected != Class.None)
                AddButton(80, 351, 247, 248, (int)Buttons.Okay_Button, GumpButtonType.Reply, 0);
        }

        public enum Buttons
        {
            Mage_Button,
            Warrior_Button,
            Ranger_Button,
            Thief_Button,
            Bard_Button,
            Crafter_Button,
            Okay_Button,
        }

        public static string GetClassFile(Class on)
        {
            string basedir = "Classes";
            string filename = "Null";

            switch (on)
            {
                case Class.None: basedir = ""; break;
                case Class.Mage: filename = "Mage_Class"; break;
                case Class.Warrior: filename = "Warrior_Class"; break;
                case Class.Ranger: filename = "Ranger_Class"; break;
                case Class.Thief: filename = "Thief_Class"; break;
                case Class.Bard: filename = "Bard_Class"; break;
                case Class.Crafter: filename = "Crafter_Class"; break;
            }

            if (FileReader.LoadedFiles.ContainsKey(basedir))
            {
                if (FileReader.LoadedFiles[basedir].ContainsKey(filename))
                    return FileReader.LoadedFiles[basedir][filename];
                else
                    return "Please select a class. After picking a class please type [combatstats and target yourself to view your skills.";
            }
            else
                return "Please select a class. After picking a class please type [combatstats and target yourself to view your skills.";
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            PlayerMobile pm = (PlayerMobile)state.Mobile;

            switch (info.ButtonID)
            {
                case (int)Buttons.Mage_Button:
                    {
                        pm.CloseGump(typeof(ClassSelectGump));
                        pm.SendGump(new ClassSelectGump(Class.Mage));
                        break;
                    }
                case (int)Buttons.Warrior_Button:
                    {
                        pm.CloseGump(typeof(ClassSelectGump));
                        pm.SendGump(new ClassSelectGump(Class.Warrior));
                        break;
                    }
                case (int)Buttons.Ranger_Button:
                    {
                        pm.CloseGump(typeof(ClassSelectGump));
                        pm.SendGump(new ClassSelectGump(Class.Ranger));
                        break;
                    }
                case (int)Buttons.Thief_Button:
                    {
                        pm.CloseGump(typeof(ClassSelectGump));
                        pm.SendGump(new ClassSelectGump(Class.Thief));
                        break;
                    }
                case (int)Buttons.Bard_Button:
                    {
                        pm.CloseGump(typeof(ClassSelectGump));
                        pm.SendGump(new ClassSelectGump(Class.Bard));
                        break;
                    }
                case (int)Buttons.Crafter_Button:
                    {
                        pm.CloseGump(typeof(ClassSelectGump));
                        pm.SendGump(new ClassSelectGump(Class.Crafter));
                        break;
                    }
                case (int)Buttons.Okay_Button:
                    {
                        pm.CloseGump(typeof(ClassSelectGump));
                        pm.Class = selected;

                        //wipe their skills
                        for (int i = 0; i < pm.Skills.Length; i++)
                            pm.Skills[i].Base = 0;

                        switch (pm.Class)
                        {
                            case Class.Mage:
                                {
                                    pm.Str = 20;
                                    pm.Dex = 25;
                                    pm.Int = 35;
                                    pm.Skills[(SkillName.Alchemy)].Cap = 140; pm.Skills[(SkillName.EvalInt)].Cap = 140; pm.Skills[(SkillName.EvalInt)].Base = 15;
                                    pm.Skills[(SkillName.Inscribe)].Cap = 140; pm.Skills[(SkillName.ItemID)].Cap = 140; pm.Skills[(SkillName.ItemID)].Base = 15;
                                    pm.Skills[(SkillName.Magery)].Cap = 140; pm.Skills[(SkillName.Meditation)].Cap = 140;
                                    pm.Skills[(SkillName.MagicResist)].Cap = 140; pm.Skills[(SkillName.SpiritSpeak)].Cap = 140;
                                    Spellbook book = new Spellbook((ulong)0x382A8C38);
                                    book.LootType = LootType.Blessed;
                                    EquipItem(book);

                                    BagOfReagents regs = new BagOfReagents(30);
                                    PackItem(regs);
                                    regs.LootType = LootType.Regular;

                                    EquipItem(new Robe(Utility.RandomBlueHue()));
                                    EquipItem(new WizardsHat());
                                    EquipItem(new GnarledStaff());
                                    EquipItem(new LongPants());
                                    EquipItem(new FancyShirt());
                                    EquipItem(new Boots());
                                    break;
                                }
                            case Class.Warrior:
                                {
                                    pm.Str = 40;
                                    pm.Dex = 30;
                                    pm.Int = 10;
                                    pm.SkillPoints += 10;
                                    pm.Skills[(SkillName.Anatomy)].Cap = 140; pm.Skills[(SkillName.Fencing)].Cap = 140; pm.Skills[(SkillName.Fencing)].Base = 15;
                                    pm.Skills[(SkillName.Healing)].Cap = 140; pm.Skills[(SkillName.Macing)].Cap = 140; pm.Skills[(SkillName.Macing)].Base = 15;
                                    pm.Skills[(SkillName.Parry)].Cap = 140; pm.Skills[(SkillName.Swords)].Cap = 140; pm.Skills[(SkillName.Swords)].Base = 15;
                                    pm.Skills[(SkillName.Tactics)].Cap = 140; pm.Skills[(SkillName.Wrestling)].Cap = 140;
                                    EquipItem(new Broadsword());
                                    EquipItem(new RingmailChest());
                                    EquipItem(new RingmailLegs());
                                    EquipItem(new RingmailArms());
                                    EquipItem(new WoodenKiteShield());

                                    EquipItem(new FancyShirt());
                                    EquipItem(new Boots());

                                    PackItem(new Spear());
                                    PackItem(new Mace());
                                    PackItem(new Bandage(50));
                                    break;
                                }
                            case Class.Ranger:
                                {
                                    pm.Str = 25;
                                    pm.Dex = 35;
                                    pm.Int = 20;
                                    pm.Skills[(SkillName.AnimalLore)].Cap = 140; pm.Skills[(SkillName.AnimalTaming)].Cap = 140;
                                    pm.Skills[(SkillName.Archery)].Cap = 140; pm.Skills[(SkillName.Camping)].Cap = 140;
                                    pm.Skills[(SkillName.Cooking)].Cap = 140; pm.Skills[(SkillName.Fishing)].Cap = 140;
                                    pm.Skills[(SkillName.Tracking)].Cap = 140; pm.Skills[(SkillName.Tracking)].Base = 15; pm.Skills[(SkillName.Veterinary)].Cap = 140; pm.Skills[(SkillName.Veterinary)].Base = 15;
                                    EquipItem(new Bow());
                                    PackItem(new Arrow(500));
                                    PackItem(new Bandage(20));

                                    EquipItem(new StuddedChest());
                                    EquipItem(new StuddedLegs());
                                    EquipItem(new StuddedArms());
                                    EquipItem(new StuddedGloves());
                                    EquipItem(new LeatherCap());

                                    EquipItem(new FancyShirt());
                                    EquipItem(new Boots());
                                    break;
                                }
                            case Class.Thief:
                                {
                                    pm.Str = 20;
                                    pm.Dex = 40;
                                    pm.Int = 20;
                                    pm.Skills[(SkillName.DetectHidden)].Cap = 140; pm.Skills[(SkillName.DetectHidden)].Base = 15; pm.Skills[(SkillName.Fencing)].Cap = 140;
                                    pm.Skills[(SkillName.Hiding)].Cap = 140; pm.Skills[(SkillName.Lockpicking)].Cap = 140;
                                    pm.Skills[(SkillName.Poisoning)].Cap = 140; pm.Skills[(SkillName.Snooping)].Cap = 140;
                                    pm.Skills[(SkillName.Stealing)].Cap = 140; pm.Skills[(SkillName.Stealth)].Cap = 140; pm.Skills[(SkillName.Stealth)].Base = 15;
                                    PackItem(new LesserPoisonPotion());
                                    PackItem(new LesserPoisonPotion());
                                    PackItem(new LesserPoisonPotion());
                                    PackItem(new LesserPoisonPotion());
                                    PackItem(new LesserPoisonPotion());
                                    PackItem(new Lockpick(10));

                                    EquipItem(new Dagger());
                                    EquipItem(new Robe(Utility.RandomBlueHue()));
                                    EquipItem(new LeatherChest());
                                    EquipItem(new LeatherArms());
                                    EquipItem(new LeatherGloves());
                                    EquipItem(new LeatherLegs());
                                    EquipItem(new LeatherCap());

                                    EquipItem(new FancyShirt());
                                    EquipItem(new Boots());
                                    break;
                                }
                            case Class.Bard:
                                {
                                    pm.Str = 25;
                                    pm.Dex = 30;
                                    pm.Int = 25;
                                    pm.Skills[(SkillName.Herding)].Cap = 140; pm.Skills[(SkillName.Cartography)].Cap = 140; pm.Skills[(SkillName.Cartography)].Base = 15;
                                    pm.Skills[(SkillName.Discordance)].Cap = 140; pm.Skills[(SkillName.Macing)].Cap = 140;
                                    pm.Skills[(SkillName.Musicianship)].Cap = 140; pm.Skills[(SkillName.Musicianship)].Base = 15; pm.Skills[(SkillName.Peacemaking)].Cap = 140;
                                    pm.Skills[(SkillName.Provocation)].Cap = 140; pm.Skills[(SkillName.TasteID)].Cap = 140;
                                    PackItem(new Lute());
                                    PackItem(new ShepherdsCrook());

                                    EquipItem(new LeatherChest());
                                    EquipItem(new LeatherArms());
                                    EquipItem(new LeatherCap());
                                    EquipItem(new LeatherLegs());
                                    EquipItem(new LeatherGloves());

                                    EquipItem(new FancyShirt());
                                    EquipItem(new Boots());
                                    break;
                                }
                            case Class.Crafter:
                                {
                                    pm.Str = 35;
                                    pm.Dex = 25;
                                    pm.Int = 20;
                                    pm.SkillPoints -= 20;
                                    pm.Skills[(SkillName.ArmsLore)].Cap = 140; pm.Skills[(SkillName.Blacksmith)].Cap = 140;
                                    pm.Skills[(SkillName.Fletching)].Cap = 140; pm.Skills[(SkillName.Carpentry)].Cap = 140;
                                    pm.Skills[(SkillName.Lumberjacking)].Cap = 140; pm.Skills[(SkillName.Mining)].Cap = 140;
                                    pm.Skills[(SkillName.Tailoring)].Cap = 140; pm.Skills[(SkillName.Tinkering)].Cap = 140;
                                    PackItem(new Shovel());
                                    PackItem(new Shovel());
                                    PackItem(new SmithHammer());
                                    PackItem(new SewingKit());
                                    PackItem(new Hammer());
                                    PackItem(new Board(15));

                                    EquipItem(new LongPants());
                                    EquipItem(new FancyShirt());
                                    EquipItem(new Boots());
                                    break;
                                }
                        }

                        PackItem(new IDWand());

                        pm.SkillPoints += 20;
                        for (int i = 0; i < pm.Skills.Length; i++)
                        {
                            if (pm.Skills[i].Cap >= 140)
                            {
                                if (pm.Skills[i].Base >= 15)
                                    pm.Skills[i].Base = 0;
                                else
                                    pm.Skills[i].Base = 10;
                            }
                            else
                            {
                                pm.Skills[i].Cap = 100;
                                pm.Skills[i].Base = 0;
                            }
                        }

                        if (pm.Hits < pm.HitsMax)
                            pm.Hits = pm.HitsMax;

                        if (pm.Mana < pm.ManaMax)
                            pm.Mana = pm.ManaMax;

                        if (pm.Stam < pm.StamMax)
                            pm.Stam = pm.StamMax;

                        break;
                    }
            }
        }

        public static void PackItem(Item item)
        {
            CharacterCreation.PackItem(item);
        }

        public static void EquipItem(Item item)
        {
            CharacterCreation.EquipItem(item);
        }
    }
}