using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Dice
{
    class Treasure
    {

        public static string compute(int dungeonLevel)
        {
            int dungeonBonus = dungeonLevel / 4;

            Dice roller = new Dice();
            String result = "";
            bool gear = false;

            int comNonCom = roller.roll(2);
            bool combatSkills;

            if (comNonCom == 1)
            {
                combatSkills = true;
            }
            else
            {
                combatSkills = false;
            }

            int lootType = roller.roll(20);

            if (lootType <= 3)
            {
                result = result + "+" + (1 + dungeonBonus) + " Potion of ";
            }
            else if (lootType <= 6)
            {
                result = result + "+" + (2 + dungeonBonus) + " Potion of ";
            }
            else if (lootType <= 9)
            {
                result = result + "+" + (3 + dungeonBonus) + " Potion of ";
            }
            else if (lootType <= 10)
            {
                result = result + "+" + (4 + dungeonBonus) + " Potion of ";
            }
            else if (lootType <= 15)
            {
                result = result + "+" + (1 + dungeonBonus) + " ";
                gear = true;
            }
            else if (lootType <= 19)
            {
                result = result + "+" + (2 + dungeonBonus) + " ";
                gear = true;
            }
            else if (lootType == 20)
            {
                result = result + "+" + (3 + dungeonBonus) + " ";
                gear = true;
            }
            else
            {
                result += "--lootType is broken--";
            }


            if (gear)
            {
                int gearType = roller.roll(4);

                switch (gearType)
                {
                    case 1:
                        result = result + "Helm of ";
                        break;
                    case 2:
                        result = result + "Armor of ";
                        break;
                    case 3:
                        result = result + "Bracers of ";
                        break;
                    case 4:
                        result = result + "Boots of ";
                        break;
                    default:
                        result += "--gearType is broken--";
                        break;
                }
            }

            if (combatSkills)
            {
                int skillChoice = roller.roll(6);

                switch (skillChoice)
                {
                    case 1:
                        result = result + "Move";
                        break;
                    case 2:
                        result = result + "Melee";
                        break;
                    case 3:
                        result = result + "Ranged";
                        break;
                    case 4:
                        result = result + "Magic";
                        break;
                    case 5:
                        result = result + "Block";
                        break;
                    case 6:
                        result = result + "Dodge";
                        break;
                    default:
                        result = result + "-1-combatSkills is broken--";
                        break;
                }
            }
            else
            {
                int skillChoice = roller.roll(8);

                switch (skillChoice)
                {
                    case 1:
                        result = result + "Animal Handling";
                        break;
                    case 2:
                        result = result + "Arcane Arts";
                        break;
                    case 3:
                        result = result + "Athletics";
                        break;
                    case 4:
                        result = result + "Speech";
                        break;
                    case 5:
                        result = result + "Stealth";
                        break;
                    case 6:
                        result = result + "Perception";
                        break;
                    case 7:
                        result = result + "Practical";
                        break;
                    case 8:
                        result = result + "Precision";
                        break;
                    default:
                        result = result + "-2-combatSkills is broken--";
                        break;
                }
            }
            return result;
        }
    }
}
