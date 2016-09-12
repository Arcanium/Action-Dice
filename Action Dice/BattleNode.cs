using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Dice
{
    class BattleNode
    {
        private int attackRoll = 0;
        private int attackBonus = 0;
        private string defenseType = "";
        private int defenseRoll = 0;
        private int defenseBonus = 0;

        public int AttackRoll
        {
            get
            {
                return attackRoll;
            }
            set
            {
                attackRoll = value;
            }
        }

        public int AttackBonus
        {
            get
            {
                return attackBonus;
            }
            set
            {
                attackBonus = value;
            }
        }

        public string DefenseType
        {
            get
            {
                return defenseType;
            }
            set
            {
                defenseType = value;
            }
        }

        public int DefenseRoll
        {
            get
            {
                return defenseRoll;
            }
            set
            {
                defenseRoll = value;
            }
        }

        public int DefenseBonus
        {
            get
            {
                return defenseBonus;
            }
            set
            {
                defenseBonus = value;
            }
        }

        public string Attack
        {
            get
            {
                return Convert.ToString(attackRoll) + "d6 + " + Convert.ToString(attackBonus);
            }
            set
            {
                string[] contents = value.Split(' ');
                attackRoll = Convert.ToInt32(contents[0][0]);
                attackBonus = Convert.ToInt32(contents[2]);
            }
        }

        public string Defend
        {
            get
            {
                return defenseType + " " + Convert.ToString(defenseRoll) + "d6 + " + Convert.ToString(defenseBonus);
            }
            set
            {
                string[] contents = value.Split(' ');
                if(contents.Length > 0)
                {
                    defenseType = contents[0];
                    defenseRoll = Convert.ToInt32(contents[1][0]);
                    defenseBonus = Convert.ToInt32(contents[3]);
                }
            }
        }

        public string BattleItem
        {
            get
            {
                return Convert.ToString(attackRoll) + "d6 + " + Convert.ToString(attackBonus) + " " + defenseType + " " + Convert.ToString(defenseRoll) + "d6 + " + Convert.ToString(defenseBonus);
            }
            set
            {
                //3d6  +   1  block 1d6  +   3
                //[0] [1] [2]  [3]  [4] [5] [6]
                //Need 0, 2, 3, 4, 6

                string[] contents = value.Split(' ');
                //Grab the first character of the first string.
                attackRoll = Convert.ToInt32(contents[0].Replace("d6", ""));
                attackBonus = Convert.ToInt32(contents[2]);
                defenseType = contents[3];
                if (contents.Length > 4)
                {
                    defenseRoll = Convert.ToInt32(contents[4].Replace("d6", ""));
                    defenseBonus = Convert.ToInt32(contents[6]);
                }
            }
        }
    }
}
