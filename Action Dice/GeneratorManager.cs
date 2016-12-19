using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Dice
{
    class GeneratorManager
    {

        #region Private Static Members
        static int move = 0;
        static int melee = 0;
        static int ranged = 0;
        static int magic = 0;
        static int block = 0;
        static int dodge = 0;

        static int animalHandling = 0;
        static int arcaneArts = 0;
        static int athletics = 0;
        static int perception = 0;
        static int practical = 0;
        static int precision = 0;
        static int stealth = 0;
        static int speech = 0;

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
                    return randomCombatSkillPicker(level);
            else if (meleeButton.Checked)
                if (melee < level)
                    return ++melee;
                else
                    return randomCombatSkillPicker(level);
            else if (rangedButton.Checked)
                if (ranged < level)
                    return ++ranged;
                else
                    return randomCombatSkillPicker(level);
            else if (magicButton.Checked)
                if (magic < level)
                    return ++magic;
                else
                    return randomCombatSkillPicker(level);
            else if (blockButton.Checked)
                if (block < level)
                    return ++block;
                else
                    return randomCombatSkillPicker(level);
            else if (dodgeButton.Checked)
                if (dodge < level)
                    return ++dodge;
                else
                    return randomCombatSkillPicker(level);
            else if (randomButton.Checked)
                return randomCombatSkillPicker(level);
            return 0; //This is an error state, it should never be reached.
        }

        public static void combatPreferencePicker(System.Windows.Forms.RadioButton moveButton, System.Windows.Forms.RadioButton meleeButton, System.Windows.Forms.RadioButton rangedButton,
            System.Windows.Forms.RadioButton magicButton, System.Windows.Forms.RadioButton blockButton, System.Windows.Forms.RadioButton dodgeButton,
            System.Windows.Forms.RadioButton randomButton)
        {
            Random rando = new Random();

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

        //Probably oughta test this. Random numbers never work quite right.
        private static int randomCombatSkillPicker(int level)
        {
            Random rando = new Random();

            for (;;)
            {
                int randomNumber = rando.Next(1, 7);
                switch (randomNumber)
                {
                    case 1:
                        if (level < move)
                            return ++move;
                        break;
                    case 2:
                        if (level < melee)
                            return ++melee;
                        break;
                    case 3:
                        if (level < ranged)
                            return ++ranged;
                        break;
                    case 4:
                        if (level < magic)
                            return ++magic;
                        break;
                    case 5:
                        if (level < block)
                            return ++block;
                        break;
                    case 6:
                        if (level < dodge)
                            return ++dodge;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}
