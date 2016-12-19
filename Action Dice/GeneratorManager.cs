using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Dice
{
    class GeneratorManager
    {
        //Random is kinda broken.
        #region Private Static Members
        private static Random rando = new Random();

        private static int move = 0;
        private static int melee = 0;
        private static int ranged = 0;
        private static int magic = 0;
        private static int block = 0;
        private static int dodge = 0;

        private static int animalHandling = 0;
        private static int arcaneArts = 0;
        private static int athletics = 0;
        private static int perception = 0;
        private static int practical = 0;
        private static int precision = 0;
        private static int speech = 0;
        private static int stealth = 0;

        #endregion

        #region Public Static Methods
        public static void Start(System.Windows.Forms.RadioButton combat1, System.Windows.Forms.RadioButton combat2, System.Windows.Forms.RadioButton combat3,
            System.Windows.Forms.RadioButton nonCombat1, System.Windows.Forms.RadioButton nonCombat2, System.Windows.Forms.RadioButton nonCombat3)
        {
            combat1.Select();
            combat2.Select();
            combat3.Select();
            nonCombat1.Select();
            nonCombat2.Select();
            nonCombat3.Select();
        }

        public static int GetSkillPointsByLevel(int level)
        {
            int skillPoints = 0;
            do
            {
                skillPoints++;
                level = level - 4;
            } while (level >= 0);
            return skillPoints;
        }

        public static int CombatSkillSelect(System.Windows.Forms.RadioButton moveButton, System.Windows.Forms.RadioButton meleeButton, System.Windows.Forms.RadioButton rangedButton,
            System.Windows.Forms.RadioButton magicButton, System.Windows.Forms.RadioButton blockButton, System.Windows.Forms.RadioButton dodgeButton,
            System.Windows.Forms.RadioButton randomButton, int level)
        {
            //Gotta check if the skill already is as high as the level.
            if (moveButton.Checked)
                if (move < level)
                    return ++move;
                else
                    return RandomCombatSkillSelect(level);
            else if (meleeButton.Checked)
                if (melee < level)
                    return ++melee;
                else
                    return RandomCombatSkillSelect(level);
            else if (rangedButton.Checked)
                if (ranged < level)
                    return ++ranged;
                else
                    return RandomCombatSkillSelect(level);
            else if (magicButton.Checked)
                if (magic < level)
                    return ++magic;
                else
                    return RandomCombatSkillSelect(level);
            else if (blockButton.Checked)
                if (block < level)
                    return ++block;
                else
                    return RandomCombatSkillSelect(level);
            else if (dodgeButton.Checked)
                if (dodge < level)
                    return ++dodge;
                else
                    return RandomCombatSkillSelect(level);
            else if (randomButton.Checked)
                return RandomCombatSkillSelect(level);
            return 0; //This is an error state, it should never be reached.
        }

        public static int NonCombatSkillSelect(System.Windows.Forms.RadioButton animalHandlingButton, System.Windows.Forms.RadioButton arcaneArtsButton, System.Windows.Forms.RadioButton athleticsButton,
           System.Windows.Forms.RadioButton perceptionButton, System.Windows.Forms.RadioButton practicalButton, System.Windows.Forms.RadioButton precisionButton,
           System.Windows.Forms.RadioButton speechButton, System.Windows.Forms.RadioButton stealthButton, System.Windows.Forms.RadioButton randomButton, int level)
        {
            //Gotta check if the skill already is as high as the level.
            if (animalHandlingButton.Checked)
                if (animalHandling < level)
                    return ++animalHandling;
                else
                    return RandomNonCombatSkillSelect(level);
            else if (arcaneArtsButton.Checked)
                if (arcaneArts < level)
                    return ++arcaneArts;
                else
                    return RandomNonCombatSkillSelect(level);
            else if (athleticsButton.Checked)
                if (athletics < level)
                    return ++athletics;
                else
                    return RandomNonCombatSkillSelect(level);
            else if (perceptionButton.Checked)
                if (perception < level)
                    return ++perception;
                else
                    return RandomNonCombatSkillSelect(level);
            else if (practicalButton.Checked)
                if (practical < level)
                    return ++practical;
                else
                    return RandomNonCombatSkillSelect(level);
            else if (precisionButton.Checked)
                if (precision < level)
                    return ++precision;
                else
                    return RandomNonCombatSkillSelect(level);
            else if (speechButton.Checked)
                if (speech < level)
                    return ++speech;
                else
                    return RandomNonCombatSkillSelect(level);
            else if (stealthButton.Checked)
                if (stealth < level)
                    return ++stealth;
                else
                    return RandomNonCombatSkillSelect(level);
            else if (randomButton.Checked)
                return RandomNonCombatSkillSelect(level);
            return 0; //This is an error state, it should never be reached.
        }

        public static void CombatPreferenceSelect(System.Windows.Forms.RadioButton moveButton, System.Windows.Forms.RadioButton meleeButton, System.Windows.Forms.RadioButton rangedButton,
            System.Windows.Forms.RadioButton magicButton, System.Windows.Forms.RadioButton blockButton, System.Windows.Forms.RadioButton dodgeButton,
            System.Windows.Forms.RadioButton randomButton)
        {
            int randomNumber = rando.Next(1, 8);
            switch (randomNumber)
            {
                case 1:
                    moveButton.Select();
                    break;
                case 2:
                    meleeButton.Select();
                    break;
                case 3:
                    rangedButton.Select();
                    break;
                case 4:
                    magicButton.Select();
                    break;
                case 5:
                    blockButton.Select();
                    break;
                case 6:
                    dodgeButton.Select();
                    break;
                case 7:
                    randomButton.Select();
                    break;
                default:
                    break;
            }
        }

        public static void NonCombatPreferenceSelect(System.Windows.Forms.RadioButton animalHandlingButton, System.Windows.Forms.RadioButton arcaneArtsButton,
            System.Windows.Forms.RadioButton athleticsButton, System.Windows.Forms.RadioButton perceptionButton, System.Windows.Forms.RadioButton practicalButton,
            System.Windows.Forms.RadioButton precisionButton, System.Windows.Forms.RadioButton speechButton, System.Windows.Forms.RadioButton stealthButton,
            System.Windows.Forms.RadioButton randomButton)
        {
            int randomNumber = rando.Next(1, 10);
            switch (randomNumber)
            {
                case 1:
                    animalHandlingButton.Select();
                    break;
                case 2:
                    arcaneArtsButton.Select();
                    break;
                case 3:
                    athleticsButton.Select();
                    break;
                case 4:
                    perceptionButton.Select();
                    break;
                case 5:
                    practicalButton.Select();
                    break;
                case 6:
                    precisionButton.Select();
                    break;
                case 7:
                    speechButton.Select();
                    break;
                case 8:
                    stealthButton.Select();
                    break;
                case 9:
                    randomButton.Select();
                    break;
                default:
                    break;
            }

        }

        //Probably oughta test this. Random numbers never work quite right.
        public static int RandomCombatSkillSelect(int level)
        {
            for (;;)
            {
                int randomNumber = rando.Next(1, 7);
                switch (randomNumber)
                {
                    case 1:
                        if (move < level)
                            return ++move;
                        break;
                    case 2:
                        if (melee < level)
                            return ++melee;
                        break;
                    case 3:
                        if (ranged < level)
                            return ++ranged;
                        break;
                    case 4:
                        if (magic < level)
                            return ++magic;
                        break;
                    case 5:
                        if (block < level)
                            return ++block;
                        break;
                    case 6:
                        if (dodge < level)
                            return ++dodge;
                        break;
                    default:
                        break;
                }
            }
        }

        //Probably oughta test this. Random numbers never work quite right.
        public static int RandomNonCombatSkillSelect(int level)
        {
            for (;;)
            {
                int randomNumber = rando.Next(1, 9);
                switch (randomNumber)
                {
                    case 1:
                        if (animalHandling < level)
                            return ++animalHandling;
                        break;
                    case 2:
                        if (arcaneArts < level)
                            return ++arcaneArts;
                        break;
                    case 3:
                        if (athletics < level)
                            return ++athletics;
                        break;
                    case 4:
                        if (perception < level)
                            return ++perception;
                        break;
                    case 5:
                        if (practical < level)
                            return ++practical;
                        break;
                    case 6:
                        if (precision < level)
                            return ++precision;
                        break;
                    case 7:
                        if (speech < level)
                            return ++speech;
                        break;
                    case 8:
                        if (stealth < level)
                            return ++stealth;
                        break;
                    default:
                        break;
                }
            }
        }

        public static void CreateCharacter(System.Windows.Forms.ListBox generatorBox, int level, string name = "")
        {
            int health = level * 6;
            string title = "";
            if (name != "")
            {
                title = "Name: " + name + ", ";
            }
            title += "Level: " + Convert.ToString(level) + ", ";
            title += "Health: " + Convert.ToString(health);
            generatorBox.Items.Add(title);

            if (move > 0 || melee > 0 || ranged > 0 || magic > 0 || block > 0 || dodge > 0)
            {
                string line = "";
                int lineCount = 0;
                generatorBox.Items.Add("Combat Skills:");

                if (move > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Move " + Convert.ToString(move);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Move " + Convert.ToString(move) + ", ";
                        lineCount++;
                    }
                }
                if (melee > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Melee " + Convert.ToString(melee);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Melee " + Convert.ToString(melee) + ", ";
                        lineCount++;
                    }
                }
                if (ranged > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Ranged " + Convert.ToString(ranged);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Ranged " + Convert.ToString(ranged) + ", ";
                        lineCount++;
                    }
                }
                if (magic > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Magic " + Convert.ToString(magic);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Magic " + Convert.ToString(magic) + ", ";
                        lineCount++;
                    }
                }
                if (block > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Block " + Convert.ToString(block);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Block " + Convert.ToString(block) + ", ";
                        lineCount++;
                    }
                }
                if (dodge > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Dodge " + Convert.ToString(dodge);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Dodge " + Convert.ToString(dodge) + ", ";
                        lineCount++;
                    }
                }
                if (lineCount > 0)
                {
                    char[] removeChars = { ',', ' ' };
                    line = line.TrimEnd(removeChars);
                    generatorBox.Items.Add(line);
                }

                move = 0;
                melee = 0;
                ranged = 0;
                magic = 0;
                block = 0;
                dodge = 0;
            }

            if (animalHandling > 0 || arcaneArts > 0 || athletics > 0 || perception > 0 || practical > 0 || precision > 0 || speech > 0 || stealth > 0)
            {
                string line = "";
                int lineCount = 0;
                generatorBox.Items.Add("Non-Combat Skills:");

                if (animalHandling > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Animal Handling " + Convert.ToString(animalHandling);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Animal Handling " + Convert.ToString(animalHandling) + ", ";
                        lineCount++;
                    }
                }
                if (arcaneArts > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Arcane Arts " + Convert.ToString(arcaneArts);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Arcane Arts " + Convert.ToString(arcaneArts) + ", ";
                        lineCount++;
                    }
                }
                if (athletics > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Athletics " + Convert.ToString(athletics);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Athletics " + Convert.ToString(athletics) + ", ";
                        lineCount++;
                    }
                }
                if (perception > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Perception " + Convert.ToString(perception);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Perception " + Convert.ToString(perception) + ", ";
                        lineCount++;
                    }
                }
                if (practical > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Practical " + Convert.ToString(practical);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Practical " + Convert.ToString(practical) + ", ";
                        lineCount++;
                    }
                }
                if (precision > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Precision " + Convert.ToString(precision);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Precision " + Convert.ToString(precision) + ", ";
                        lineCount++;
                    }
                }
                if (speech > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Speech " + Convert.ToString(speech);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Speech " + Convert.ToString(speech) + ", ";
                        lineCount++;
                    }
                }
                if (stealth > 0)
                {
                    if (lineCount == 2)
                    {
                        line += "Stealth " + Convert.ToString(stealth);
                        lineCount = 0;
                        generatorBox.Items.Add(line);
                        line = "";
                    }
                    else
                    {
                        line += "Stealth " + Convert.ToString(stealth) + ", ";
                        lineCount++;
                    }
                }
                if (lineCount > 0)
                {
                    char[] removeChars = { ',', ' ' };
                    line = line.TrimEnd(removeChars);
                    generatorBox.Items.Add(line);
                }

                animalHandling = 0;
                arcaneArts = 0;
                athletics = 0;
                perception = 0;
                practical = 0;
                precision = 0;
                speech = 0;
                stealth = 0;
            }
            generatorBox.Items.Add(" ");
        }

        #endregion
    }
}
