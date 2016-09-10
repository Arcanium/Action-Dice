using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Dice
{
    class BattleManager
    {
        public static void AddAttack(System.Windows.Forms.ListBox box, int attackRoll, int attackBonus)
        {
            box.Items.Add(attackRoll + "d6 + " + attackBonus);
        }
    }
}
