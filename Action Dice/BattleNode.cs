using System;

namespace Action_Dice
{
    class BattleNode
    {
        public int AttackRoll { get; set; } = 0;
        public int AttackBonus { get; set; } = 0;
        public string DefenseType { get; set; } = "";
        public int DefenseRoll { get; set; } = 0;
        public int DefenseBonus { get; set; } = 0;

        public string Attack
        {
            get
            {
                return Convert.ToString(AttackRoll) + "d6 + " + Convert.ToString(AttackBonus);
            }
            set
            {
                string[] contents = value.Split(' ');
                AttackRoll = Convert.ToInt32(contents[0][0]);
                AttackBonus = Convert.ToInt32(contents[2]);
            }
        }

        public string Defend
        {
            get
            {
                return DefenseType + " " + Convert.ToString(DefenseRoll) + "d6 + " + Convert.ToString(DefenseBonus);
            }
            set
            {
                string[] contents = value.Split(' ');
                if(contents.Length > 0)
                {
                    DefenseType = contents[0];
                    DefenseRoll = Convert.ToInt32(contents[1][0]);
                    DefenseBonus = Convert.ToInt32(contents[3]);
                }
            }
        }

        public string BattleItem
        {
            get
            {
                return Convert.ToString(AttackRoll) + "d6 + " + Convert.ToString(AttackBonus) + " " + DefenseType + " " + Convert.ToString(DefenseRoll) + "d6 + " + Convert.ToString(DefenseBonus);
            }
            set
            {
                //3d6  +   1  block 1d6  +   3
                //[0] [1] [2]  [3]  [4] [5] [6]
                //Need 0, 2, 3, 4, 6

                string[] contents = value.Split(' ');
                //Grab the first character of the first string.
                AttackRoll = Convert.ToInt32(contents[0].Replace("d6", ""));
                AttackBonus = Convert.ToInt32(contents[2]);
                DefenseType = contents[3];
                if (contents.Length > 4)
                {
                    DefenseRoll = Convert.ToInt32(contents[4].Replace("d6", ""));
                    DefenseBonus = Convert.ToInt32(contents[6]);
                }
            }
        }
    }
}
