using System;

namespace Action_Dice
{
    class Treasure
    {

        public static string Compute(int dungeonLevel)
        {
            Dice roller = new Dice();
            String result = "";
            bool gear = false;

            int comNonCom = roller.Roll(2);
            bool combatSkills;

            if (comNonCom == 1)
            {
                combatSkills = true;
            }
            else
            {
                combatSkills = false;
            }

            int lootType = roller.Roll(20);

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
                int gearType = roller.Roll(4);

                switch (gearType)
                {
                    case 1:
                        result += "Helm of ";
                        break;
                    case 2:
                        result += "Armor of ";
                        break;
                    case 3:
                        result += "Bracers of ";
                        break;
                    case 4:
                        result += "Boots of ";
                        break;
                    default:
                        result += "--gearType is broken--";
                        break;
                }
            }

            if (combatSkills)
            {
                int skillChoice = roller.Roll(6);

                switch (skillChoice)
                {
                    case 1:
                        result += "Move";
                        break;
                    case 2:
                        result += "Melee";
                        break;
                    case 3:
                        result += "Ranged";
                        break;
                    case 4:
                        result += "Magic";
                        break;
                    case 5:
                        result += "Block";
                        break;
                    case 6:
                        result += "Dodge";
                        break;
                    default:
                        result += "-1-combatSkills is broken--";
                        break;
                }
            }
            else
            {
                int skillChoice = roller.Roll(8);

                switch (skillChoice)
                {
                    case 1:
                        result += "Animal Handling";
                        break;
                    case 2:
                        result += "Arcane Arts";
                        break;
                    case 3:
                        result += "Athletics";
                        break;
                    case 4:
                        result += "Perception";
                        break;
                    case 5:
                        result += "Practical";
                        break;
                    case 6:
                        result += "Precision";
                        break;
                    case 7:
                        result += "Speech";
                        break;
                    case 8:
                        result += "Stealth";
                        break;
                    default:
                        result += "-2-combatSkills is broken--";
                        break;
                }
            }
            return result;
        }
    }
}
