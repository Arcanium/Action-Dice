using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Dice
{
    class BattleManager
    {
        public const string PASS = "Pass";
        public const string BLOCK = "Block";
        public const string DODGE = "Dodge";

        public static void Start(System.Windows.Forms.ListBox box, System.Windows.Forms.ListBox damageBox)
        {
            box.Items.Clear();
            damageBox.Items.Clear();
            damageBox.Items.Add(0);
        }

        public static void AddAttack(System.Windows.Forms.ListBox box, int attackRoll, int attackBonus = 0, string defenseType = "", int defenseRoll = 0, int defenseBonus = 0)
        {
            if (defenseType == "")
                box.Items.Add(attackRoll + "d6 + " + attackBonus);
            else if (defenseType.ToLower().Contains(PASS.ToLower()) || defenseType.ToUpper().Contains(PASS.ToUpper()))
                box.Items.Add(attackRoll + "d6 + " + attackBonus + " " + PASS);
            else if (defenseType.ToLower().Contains(BLOCK.ToLower()) || defenseType.ToUpper().Contains(BLOCK.ToUpper()))
                box.Items.Add(attackRoll + "d6 + " + attackBonus + " " + BLOCK + " " + defenseRoll + "d6 + " + defenseBonus);
            if (defenseType.ToLower().Contains(DODGE.ToLower()) || defenseType.ToUpper().Contains(DODGE.ToUpper()))
                box.Items.Add(attackRoll + "d6 + " + attackBonus + " " + DODGE + " " + defenseRoll + "d6 + " + defenseBonus);
        }

        public static void AddDefend(System.Windows.Forms.ListBox box, string defenseType, int defenseRoll = 0, int defenseBonus = 0)
        {
            //3d6  +   1  block 1d6  +   3
            //[0] [1] [2]  [3]  [4] [5] [6]
            for (int index = 0; index < box.Items.Count; index++)
            {
                string[] contents = box.Items[index].ToString().Split(' ');
                if (contents.Length < 4)
                {
                    string item = box.Items[index].ToString();
                    if (defenseType.ToLower().Contains(PASS.ToLower()) || defenseType.ToUpper().Contains(PASS.ToUpper()))
                    {
                        item = item + " " + PASS;
                    }
                    else
                    {
                        if (defenseType.ToLower().Contains(BLOCK.ToLower()) || defenseType.ToUpper().Contains(BLOCK.ToUpper()))
                            item = item + " " + BLOCK + " " + Convert.ToString(defenseRoll) + "d6 + " + Convert.ToString(defenseBonus);
                        else if (defenseType.ToLower().Contains(DODGE.ToLower()) || defenseType.ToUpper().Contains(DODGE.ToUpper()))
                            item = item + " " + DODGE + " " + Convert.ToString(defenseRoll) + "d6 + " + Convert.ToString(defenseBonus);
                    }
                    box.Items.RemoveAt(index);
                    box.Items.Insert(index, item);
                    return;
                }
            }
        }

        public static void Resolve(System.Windows.Forms.ListBox box, System.Windows.Forms.ListBox damageBox)
        {
            Dice roller = new Dice();
            int damage = Convert.ToInt32(damageBox.Items[0].ToString());
            damageBox.Items.Clear();

            int index = 0;
            while (index < box.Items.Count)
            {
                if (box.Items[index].ToString().Split(' ').Length > 3)
                {
                    BattleNode node = new BattleNode();
                    node.BattleItem = box.Items[index].ToString();
                    box.Items.RemoveAt(index);
                    if (node.DefenseType == PASS)
                    {
                        int attack = roller.roll(6, node.AttackRoll) + node.AttackBonus;
                        damage = damage + attack;
                    }
                    else if (node.DefenseType == BLOCK)
                    {
                        int attack = roller.roll(6, node.AttackRoll) + node.AttackBonus;
                        int defend = roller.roll(6, node.DefenseRoll) + node.DefenseBonus;
                        damage = (defend >= attack) ? damage + 1 : damage + attack - defend;
                    }
                    else if (node.DefenseType == DODGE)
                    {
                        int attack = roller.roll(6, node.AttackRoll) + node.AttackBonus;
                        int defend = roller.roll(6, node.DefenseRoll) + (node.DefenseBonus * 2);
                        if (attack > defend)
                            damage = damage + attack;
                    }
                }
                else
                    index++;
            }
            damageBox.Items.Add(damage);
        }
    }
}
