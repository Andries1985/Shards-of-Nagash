using System;

using Server;
using Server.Items;

namespace Custom
{
    public class ItemProps
    {
        public static int BonusCount(Item item)
        {
            if (item == null)
                return 0;

            int props = 0;

            #region [Weapon]
            if (item is BaseWeapon)
            {
                /*if (item is BaseRanged)
                {
                    if (((BaseRanged)item).EnergyBow)
                        props += 2;
                }*/

                BaseWeapon wea = (BaseWeapon)item;
                foreach (int i in Enum.GetValues(typeof(AosAttribute)))
                {
                    if (wea.Attributes[(AosAttribute)i] > 0)
                        ++props;
                }

                if (wea.SkillBonuses.Skill_1_Value > 0)
                    ++props;

                if (wea.SkillBonuses.Skill_2_Value > 0)
                    ++props;

                if (wea.SkillBonuses.Skill_3_Value > 0)
                    ++props;

                if (wea.SkillBonuses.Skill_4_Value > 0)
                    ++props;

                if (wea.SkillBonuses.Skill_5_Value > 0)
                    ++props;

                foreach (int i in Enum.GetValues(typeof(AosWeaponAttribute)))
                {
                    if (wea.WeaponAttributes[(AosWeaponAttribute)i] > 0)
                        ++props;
                }

                if (wea.Slayer != SlayerName.None)
                    ++props;

                if (wea.Slayer2 != SlayerName.None)
                    ++props;
            }
            #endregion

            #region [Armor]
            else if (item is BaseArmor)
            {
                BaseArmor arm = (BaseArmor)item;
                foreach (int i in Enum.GetValues(typeof(AosAttribute)))
                {
                    if (arm.Attributes[(AosAttribute)i] > 0)
                        ++props;
                }

                if (arm.SkillBonuses.Skill_1_Value > 0)
                    ++props;

                if (arm.SkillBonuses.Skill_2_Value > 0)
                    ++props;

                if (arm.SkillBonuses.Skill_3_Value > 0)
                    ++props;

                if (arm.SkillBonuses.Skill_4_Value > 0)
                    ++props;

                if (arm.SkillBonuses.Skill_5_Value > 0)
                    ++props;

                foreach (int i in Enum.GetValues(typeof(AosArmorAttribute)))
                {
                    if (arm.ArmorAttributes[(AosArmorAttribute)i] > 0)
                        ++props;
                }
            }
            #endregion

            #region [Clothing]
            else if (item is BaseClothing)
            {
                BaseClothing clo = (BaseClothing)item;
                foreach (int i in Enum.GetValues(typeof(AosAttribute)))
                {
                    if (clo.Attributes[(AosAttribute)i] > 0)
                        ++props;
                }

                if (clo.SkillBonuses.Skill_1_Value > 0)
                    ++props;

                if (clo.SkillBonuses.Skill_2_Value > 0)
                    ++props;

                if (clo.SkillBonuses.Skill_3_Value > 0)
                    ++props;

                if (clo.SkillBonuses.Skill_4_Value > 0)
                    ++props;

                if (clo.SkillBonuses.Skill_5_Value > 0)
                    ++props;

                foreach (int i in Enum.GetValues(typeof(AosArmorAttribute)))
                {
                    if (clo.ClothingAttributes[(AosArmorAttribute)i] > 0)
                        ++props;
                }
            }
            #endregion

            #region [Jewelry]
            else if (item is BaseJewel)
            {
                BaseJewel jew = (BaseJewel)item;
                foreach (int i in Enum.GetValues(typeof(AosAttribute)))
                {
                    if (jew.Attributes[(AosAttribute)i] > 0)
                        ++props;
                }

                if (jew.SkillBonuses.Skill_1_Value > 0)
                    ++props;

                if (jew.SkillBonuses.Skill_2_Value > 0)
                    ++props;

                if (jew.SkillBonuses.Skill_3_Value > 0)
                    ++props;

                if (jew.SkillBonuses.Skill_4_Value > 0)
                    ++props;

                if (jew.SkillBonuses.Skill_5_Value > 0)
                    ++props;

                foreach (int i in Enum.GetValues(typeof(AosElementAttribute)))
                {
                    if (jew.Resistances[(AosElementAttribute)i] > 0)
                        ++props;
                }
            }
            #endregion

            return props;
        }

        public static void FixSkillBonuses(Item item)
        {
            for (int i = 0; i < 7; i++)
            {

                #region Weapon
                if (item is BaseWeapon)
                {
                    BaseWeapon weap = (BaseWeapon)item;
                    if (weap.SkillBonuses.Skill_2_Value > 0 && weap.SkillBonuses.Skill_1_Value == 0)
                    {
                        weap.SkillBonuses.Skill_1_Name = weap.SkillBonuses.Skill_2_Name;
                        weap.SkillBonuses.Skill_1_Value = weap.SkillBonuses.Skill_2_Value;
                        weap.SkillBonuses.Skill_2_Value = 0;
                    }
                    else if (weap.SkillBonuses.Skill_3_Value > 0 && weap.SkillBonuses.Skill_2_Value == 0)
                    {
                        weap.SkillBonuses.Skill_2_Name = weap.SkillBonuses.Skill_3_Name;
                        weap.SkillBonuses.Skill_2_Value = weap.SkillBonuses.Skill_3_Value;
                        weap.SkillBonuses.Skill_3_Value = 0;
                    }
                    else if (weap.SkillBonuses.Skill_4_Value > 0 && weap.SkillBonuses.Skill_3_Value == 0)
                    {
                        weap.SkillBonuses.Skill_3_Name = weap.SkillBonuses.Skill_4_Name;
                        weap.SkillBonuses.Skill_3_Value = weap.SkillBonuses.Skill_4_Value;
                        weap.SkillBonuses.Skill_4_Value = 0;
                    }
                    else if (weap.SkillBonuses.Skill_5_Value > 0 && weap.SkillBonuses.Skill_4_Value == 0)
                    {
                        weap.SkillBonuses.Skill_4_Name = weap.SkillBonuses.Skill_5_Name;
                        weap.SkillBonuses.Skill_4_Value = weap.SkillBonuses.Skill_5_Value;
                        weap.SkillBonuses.Skill_5_Value = 0;
                    }

                    if (weap.SkillBonuses.Skill_5_Name == weap.SkillBonuses.Skill_4_Name)
                    {
                        if (weap.SkillBonuses.Skill_4_Value + weap.SkillBonuses.Skill_5_Value > 10)
                        {
                            weap.SkillBonuses.Skill_4_Value = 10;
                            weap.SkillBonuses.Skill_5_Value = 0;
                        }
                        else
                        {
                            weap.SkillBonuses.Skill_4_Value += weap.SkillBonuses.Skill_5_Value;
                            weap.SkillBonuses.Skill_5_Value = 0;
                        }
                    }
                    else if (weap.SkillBonuses.Skill_4_Name == weap.SkillBonuses.Skill_3_Name)
                    {
                        if (weap.SkillBonuses.Skill_3_Value + weap.SkillBonuses.Skill_4_Value > 10)
                        {
                            weap.SkillBonuses.Skill_3_Value = 10;
                            weap.SkillBonuses.Skill_4_Value = 0;
                        }
                        else
                        {
                            weap.SkillBonuses.Skill_3_Value += weap.SkillBonuses.Skill_5_Value;
                            weap.SkillBonuses.Skill_4_Value = 0;
                        }
                    }
                    else if (weap.SkillBonuses.Skill_3_Name == weap.SkillBonuses.Skill_2_Name)
                    {
                        if (weap.SkillBonuses.Skill_2_Value + weap.SkillBonuses.Skill_3_Value > 10)
                        {
                            weap.SkillBonuses.Skill_2_Value = 10;
                            weap.SkillBonuses.Skill_3_Value = 0;
                        }
                        else
                        {
                            weap.SkillBonuses.Skill_2_Value += weap.SkillBonuses.Skill_5_Value;
                            weap.SkillBonuses.Skill_3_Value = 0;
                        }
                    }
                    else if (weap.SkillBonuses.Skill_2_Name == weap.SkillBonuses.Skill_1_Name)
                    {
                        if (weap.SkillBonuses.Skill_1_Value + weap.SkillBonuses.Skill_2_Value > 10)
                        {
                            weap.SkillBonuses.Skill_1_Value = 10;
                            weap.SkillBonuses.Skill_2_Value = 0;
                        }
                        else
                        {
                            weap.SkillBonuses.Skill_1_Value += weap.SkillBonuses.Skill_5_Value;
                            weap.SkillBonuses.Skill_2_Value = 0;
                        }
                    }
                }
                #endregion

                #region Armor
                if (item is BaseArmor)
                {
                    BaseArmor arm = (BaseArmor)item;
                    if (arm.SkillBonuses.Skill_2_Value > 0 && arm.SkillBonuses.Skill_1_Value == 0)
                    {
                        arm.SkillBonuses.Skill_1_Name = arm.SkillBonuses.Skill_2_Name;
                        arm.SkillBonuses.Skill_1_Value = arm.SkillBonuses.Skill_2_Value;
                        arm.SkillBonuses.Skill_2_Value = 0;
                    }
                    else if (arm.SkillBonuses.Skill_3_Value > 0 && arm.SkillBonuses.Skill_2_Value == 0)
                    {
                        arm.SkillBonuses.Skill_2_Name = arm.SkillBonuses.Skill_3_Name;
                        arm.SkillBonuses.Skill_2_Value = arm.SkillBonuses.Skill_3_Value;
                        arm.SkillBonuses.Skill_3_Value = 0;
                    }
                    else if (arm.SkillBonuses.Skill_4_Value > 0 && arm.SkillBonuses.Skill_3_Value == 0)
                    {
                        arm.SkillBonuses.Skill_3_Name = arm.SkillBonuses.Skill_4_Name;
                        arm.SkillBonuses.Skill_3_Value = arm.SkillBonuses.Skill_4_Value;
                        arm.SkillBonuses.Skill_4_Value = 0;
                    }
                    else if (arm.SkillBonuses.Skill_5_Value > 0 && arm.SkillBonuses.Skill_4_Value == 0)
                    {
                        arm.SkillBonuses.Skill_4_Name = arm.SkillBonuses.Skill_5_Name;
                        arm.SkillBonuses.Skill_4_Value = arm.SkillBonuses.Skill_5_Value;
                        arm.SkillBonuses.Skill_5_Value = 0;
                    }


                    if (arm.SkillBonuses.Skill_5_Name == arm.SkillBonuses.Skill_4_Name)
                    {
                        if (arm.SkillBonuses.Skill_4_Value + arm.SkillBonuses.Skill_5_Value > 10)
                        {
                            arm.SkillBonuses.Skill_4_Value = 10;
                            arm.SkillBonuses.Skill_5_Value = 0;
                        }
                        else
                        {
                            arm.SkillBonuses.Skill_4_Value += arm.SkillBonuses.Skill_5_Value;
                            arm.SkillBonuses.Skill_5_Value = 0;
                        }
                    }
                    else if (arm.SkillBonuses.Skill_4_Name == arm.SkillBonuses.Skill_3_Name)
                    {
                        if (arm.SkillBonuses.Skill_3_Value + arm.SkillBonuses.Skill_4_Value > 10)
                        {
                            arm.SkillBonuses.Skill_3_Value = 10;
                            arm.SkillBonuses.Skill_4_Value = 0;
                        }
                        else
                        {
                            arm.SkillBonuses.Skill_3_Value += arm.SkillBonuses.Skill_5_Value;
                            arm.SkillBonuses.Skill_4_Value = 0;
                        }
                    }
                    else if (arm.SkillBonuses.Skill_3_Name == arm.SkillBonuses.Skill_2_Name)
                    {
                        if (arm.SkillBonuses.Skill_2_Value + arm.SkillBonuses.Skill_3_Value > 10)
                        {
                            arm.SkillBonuses.Skill_2_Value = 10;
                            arm.SkillBonuses.Skill_3_Value = 0;
                        }
                        else
                        {
                            arm.SkillBonuses.Skill_2_Value += arm.SkillBonuses.Skill_5_Value;
                            arm.SkillBonuses.Skill_3_Value = 0;
                        }
                    }
                    else if (arm.SkillBonuses.Skill_2_Name == arm.SkillBonuses.Skill_1_Name)
                    {
                        if (arm.SkillBonuses.Skill_1_Value + arm.SkillBonuses.Skill_2_Value > 10)
                        {
                            arm.SkillBonuses.Skill_1_Value = 10;
                            arm.SkillBonuses.Skill_2_Value = 0;
                        }
                        else
                        {
                            arm.SkillBonuses.Skill_1_Value += arm.SkillBonuses.Skill_5_Value;
                            arm.SkillBonuses.Skill_2_Value = 0;
                        }
                    }
                }
                #endregion

                #region Clothing
                if (item is BaseClothing)
                {
                    BaseClothing cloth = (BaseClothing)item;
                    if (cloth.SkillBonuses.Skill_2_Value > 0 && cloth.SkillBonuses.Skill_1_Value == 0)
                    {
                        cloth.SkillBonuses.Skill_1_Name = cloth.SkillBonuses.Skill_2_Name;
                        cloth.SkillBonuses.Skill_1_Value = cloth.SkillBonuses.Skill_2_Value;
                        cloth.SkillBonuses.Skill_2_Value = 0;
                    }
                    else if (cloth.SkillBonuses.Skill_3_Value > 0 && cloth.SkillBonuses.Skill_2_Value == 0)
                    {
                        cloth.SkillBonuses.Skill_2_Name = cloth.SkillBonuses.Skill_3_Name;
                        cloth.SkillBonuses.Skill_2_Value = cloth.SkillBonuses.Skill_3_Value;
                        cloth.SkillBonuses.Skill_3_Value = 0;
                    }
                    else if (cloth.SkillBonuses.Skill_4_Value > 0 && cloth.SkillBonuses.Skill_3_Value == 0)
                    {
                        cloth.SkillBonuses.Skill_3_Name = cloth.SkillBonuses.Skill_4_Name;
                        cloth.SkillBonuses.Skill_3_Value = cloth.SkillBonuses.Skill_4_Value;
                        cloth.SkillBonuses.Skill_4_Value = 0;
                    }
                    else if (cloth.SkillBonuses.Skill_5_Value > 0 && cloth.SkillBonuses.Skill_4_Value == 0)
                    {
                        cloth.SkillBonuses.Skill_4_Name = cloth.SkillBonuses.Skill_5_Name;
                        cloth.SkillBonuses.Skill_4_Value = cloth.SkillBonuses.Skill_5_Value;
                        cloth.SkillBonuses.Skill_5_Value = 0;
                    }


                    if (cloth.SkillBonuses.Skill_5_Name == cloth.SkillBonuses.Skill_4_Name)
                    {
                        if (cloth.SkillBonuses.Skill_4_Value + cloth.SkillBonuses.Skill_5_Value > 10)
                        {
                            cloth.SkillBonuses.Skill_4_Value = 10;
                            cloth.SkillBonuses.Skill_5_Value = 0;
                        }
                        else
                        {
                            cloth.SkillBonuses.Skill_4_Value += cloth.SkillBonuses.Skill_5_Value;
                            cloth.SkillBonuses.Skill_5_Value = 0;
                        }
                    }
                    else if (cloth.SkillBonuses.Skill_4_Name == cloth.SkillBonuses.Skill_3_Name)
                    {
                        if (cloth.SkillBonuses.Skill_3_Value + cloth.SkillBonuses.Skill_4_Value > 10)
                        {
                            cloth.SkillBonuses.Skill_3_Value = 10;
                            cloth.SkillBonuses.Skill_4_Value = 0;
                        }
                        else
                        {
                            cloth.SkillBonuses.Skill_3_Value += cloth.SkillBonuses.Skill_5_Value;
                            cloth.SkillBonuses.Skill_4_Value = 0;
                        }
                    }
                    else if (cloth.SkillBonuses.Skill_3_Name == cloth.SkillBonuses.Skill_2_Name)
                    {
                        if (cloth.SkillBonuses.Skill_2_Value + cloth.SkillBonuses.Skill_3_Value > 10)
                        {
                            cloth.SkillBonuses.Skill_2_Value = 10;
                            cloth.SkillBonuses.Skill_3_Value = 0;
                        }
                        else
                        {
                            cloth.SkillBonuses.Skill_2_Value += cloth.SkillBonuses.Skill_5_Value;
                            cloth.SkillBonuses.Skill_3_Value = 0;
                        }
                    }
                    else if (cloth.SkillBonuses.Skill_2_Name == cloth.SkillBonuses.Skill_1_Name)
                    {
                        if (cloth.SkillBonuses.Skill_1_Value + cloth.SkillBonuses.Skill_2_Value > 10)
                        {
                            cloth.SkillBonuses.Skill_1_Value = 10;
                            cloth.SkillBonuses.Skill_2_Value = 0;
                        }
                        else
                        {
                            cloth.SkillBonuses.Skill_1_Value += cloth.SkillBonuses.Skill_5_Value;
                            cloth.SkillBonuses.Skill_2_Value = 0;
                        }
                    }
                }
                #endregion

                #region Jewelery

                if (item is BaseJewel)
                {
                    BaseJewel jewl = (BaseJewel)item;
                    if (jewl.SkillBonuses.Skill_2_Value > 0 && jewl.SkillBonuses.Skill_1_Value == 0)
                    {
                        jewl.SkillBonuses.Skill_1_Name = jewl.SkillBonuses.Skill_2_Name;
                        jewl.SkillBonuses.Skill_1_Value = jewl.SkillBonuses.Skill_2_Value;
                        jewl.SkillBonuses.Skill_2_Value = 0;
                    }
                    else if (jewl.SkillBonuses.Skill_3_Value > 0 && jewl.SkillBonuses.Skill_2_Value == 0)
                    {
                        jewl.SkillBonuses.Skill_2_Name = jewl.SkillBonuses.Skill_3_Name;
                        jewl.SkillBonuses.Skill_2_Value = jewl.SkillBonuses.Skill_3_Value;
                        jewl.SkillBonuses.Skill_3_Value = 0;
                    }
                    else if (jewl.SkillBonuses.Skill_4_Value > 0 && jewl.SkillBonuses.Skill_3_Value == 0)
                    {
                        jewl.SkillBonuses.Skill_3_Name = jewl.SkillBonuses.Skill_4_Name;
                        jewl.SkillBonuses.Skill_3_Value = jewl.SkillBonuses.Skill_4_Value;
                        jewl.SkillBonuses.Skill_4_Value = 0;
                    }
                    else if (jewl.SkillBonuses.Skill_5_Value > 0 && jewl.SkillBonuses.Skill_4_Value == 0)
                    {
                        jewl.SkillBonuses.Skill_4_Name = jewl.SkillBonuses.Skill_5_Name;
                        jewl.SkillBonuses.Skill_4_Value = jewl.SkillBonuses.Skill_5_Value;
                        jewl.SkillBonuses.Skill_5_Value = 0;
                    }


                    if (jewl.SkillBonuses.Skill_5_Name == jewl.SkillBonuses.Skill_4_Name)
                    {
                        if (jewl.SkillBonuses.Skill_4_Value + jewl.SkillBonuses.Skill_5_Value > 10)
                        {
                            jewl.SkillBonuses.Skill_4_Value = 10;
                            jewl.SkillBonuses.Skill_5_Value = 0;
                        }
                        else
                        {
                            jewl.SkillBonuses.Skill_4_Value += jewl.SkillBonuses.Skill_5_Value;
                            jewl.SkillBonuses.Skill_5_Value = 0;
                        }
                    }
                    else if (jewl.SkillBonuses.Skill_4_Name == jewl.SkillBonuses.Skill_3_Name)
                    {
                        if (jewl.SkillBonuses.Skill_3_Value + jewl.SkillBonuses.Skill_4_Value > 10)
                        {
                            jewl.SkillBonuses.Skill_3_Value = 10;
                            jewl.SkillBonuses.Skill_4_Value = 0;
                        }
                        else
                        {
                            jewl.SkillBonuses.Skill_3_Value += jewl.SkillBonuses.Skill_5_Value;
                            jewl.SkillBonuses.Skill_4_Value = 0;
                        }
                    }
                    else if (jewl.SkillBonuses.Skill_3_Name == jewl.SkillBonuses.Skill_2_Name)
                    {
                        if (jewl.SkillBonuses.Skill_2_Value + jewl.SkillBonuses.Skill_3_Value > 10)
                        {
                            jewl.SkillBonuses.Skill_2_Value = 10;
                            jewl.SkillBonuses.Skill_3_Value = 0;
                        }
                        else
                        {
                            jewl.SkillBonuses.Skill_2_Value += jewl.SkillBonuses.Skill_5_Value;
                            jewl.SkillBonuses.Skill_3_Value = 0;
                        }
                    }
                    else if (jewl.SkillBonuses.Skill_2_Name == jewl.SkillBonuses.Skill_1_Name)
                    {
                        if (jewl.SkillBonuses.Skill_1_Value + jewl.SkillBonuses.Skill_2_Value > 10)
                        {
                            jewl.SkillBonuses.Skill_1_Value = 10;
                            jewl.SkillBonuses.Skill_2_Value = 0;
                        }
                        else
                        {
                            jewl.SkillBonuses.Skill_1_Value += jewl.SkillBonuses.Skill_5_Value;
                            jewl.SkillBonuses.Skill_2_Value = 0;
                        }
                    }
                }

                #endregion

            }
        }

        public static string RarityNameMod(Item item, string orig)
        {
            if (item is BaseWeapon && ((BaseWeapon)item).Crafter != null)
                return orig;
            else if (item is BaseArmor && ((BaseArmor)item).Crafter != null)
                return orig;
            else if (item is BaseClothing && ((BaseClothing)item).Crafter != null)
                return orig;/*
            else if (item.LootType == LootType.Newbied)
                return orig;
            */

            return (string)(RarityColor(item) + orig + "<BASEFONT COLOR=#FFFFFF>");
        }

        public static string RarityColor(Item item)
        {
            int bonuses = BonusCount(item);

            if (bonuses >= 9)
                return "<BASEFONT COLOR=#FF0000>"; //"<BASEFONT COLOR=#FF73B9>";
            else if (bonuses >= 7)
                return "<BASEFONT COLOR=#CACAFF>";
            else if (bonuses >= 5)
                return "<BASEFONT COLOR=#EEBBEE>";
            else if (bonuses >= 3)
                return "<BASEFONT COLOR=#FFDD75>";
            else if (bonuses >= 1)
                return "<BASEFONT COLOR=#B3FF99>";

            return "<BASEFONT COLOR=#FFFFFF>";
        }
    }
}