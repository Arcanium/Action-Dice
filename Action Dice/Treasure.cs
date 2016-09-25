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

            if (lootType == 1)
            {
                return "+" + (1 + dungeonLevel / 4) + " Potion of Healing";
            }
            else if (lootType <= 4)
            {
                result = result + "+" + (1 + dungeonLevel / 4) + " Potion of ";
            }
            else if (lootType <= 7)
            {
                result = result + "+" + (1 + dungeonLevel / 3) + " Potion of ";
            }
            else if (lootType <= 9)
            {
                result = result + "+" + (1 + dungeonLevel / 2) + " Potion of ";
            }
            else if (lootType <= 10)
            {
                result = result + "+" + (1 + (2 * dungeonLevel) / 3) + " Potion of ";
            }
            else if (lootType <= 15)
            {
                result = result + "+" + (1 + dungeonLevel / 4) + " ";
                gear = true;
            }
            else if (lootType <= 19)
            {
                result = result + "+" + (1 + dungeonLevel / 3) + " ";
                gear = true;
            }
            else if (lootType == 20)
            {
                result = result + "+" + (1 + dungeonLevel / 2) + " ";
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
                        result = result + "Perception";
                        break;
                    case 5:
                        result = result + "Practical";
                        break;
                    case 6:
                        result = result + "Precision";
                        break;
                    case 7:
                        result = result + "Speech";
                        break;
                    case 8:
                        result = result + "Stealth";
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
