using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Action_Dice
{
    class InitiativeManager
    {
        #region Public Constants

        public const string TOP_OF_ROUND = "0 Top Of The Round";
        public const string TOP_LABEL_TEXT = "Top of the Round -- All Action Dice refill!";
        public const string DOWN = "Down"; //I removed a space at the start. Hopefully this doesn't create more problems.

        #endregion

        #region Public Static Methods

        public static void Start(ListBox box, Label label)
        {
            box.Items.Clear();
            box.Items.Add(TOP_OF_ROUND);
            label.Text = TOP_LABEL_TEXT;
        }

        public static void AddListPlace(ListBox box, string name, int position = -1)
        {
            if (position > box.Items.Count || position < 0)
                position = box.Items.Count;

            InitiativeListNode node = new InitiativeListNode
            {
                Location = GetLocationList(box, position),
                Name = name
            };

            int positionBelow = ((position + 1) < box.Items.Count) ? position + 1 : 0;
            int positionAbove = ((position - 1) >= 0) ? position - 1 : box.Items.Count - 1;

            if (!box.Items[positionBelow].ToString().Contains(TOP_OF_ROUND))
                node.Roll = Convert.ToInt32(box.Items[positionBelow].ToString().Split(' ')[2]);
            else if (!box.Items[positionAbove].ToString().Contains(TOP_OF_ROUND))
                node.Roll = Convert.ToInt32(box.Items[positionAbove].ToString().Split(' ')[2]);
            else
                //No other roll exists, so give this one the average roll.
                node.Roll = 7;

            box.Items.Insert(node.Location, node.ListItem);

            UpdatePositions(box);
        }

        public static void AddRollPlace(ListBox box, string name, int roll = -1)
        {
            Dice roller = new Dice();
            if (roll > 12)
                roll = 12;
            else if (roll < 2)
                roll = roller.Roll(6, 2);

            InitiativeListNode node = new InitiativeListNode
            {
                Roll = roll,
                Name = name,

                Location = GetLocationRoll(box, roll)
            };

            box.Items.Insert(node.Location, node.ListItem);

            UpdatePositions(box);
        }

        public static int UpdateUndoBox(ListBox box, List<ListBox> undoBox, int tracker)
        {
            ListBox tmp = new ListBox();
            tmp.Items.AddRange(box.Items);

            TrimUndoListBox(undoBox, tracker);
            undoBox.Add(tmp);

            return ++tracker;
        }

        public static void UpdatePositions(ListBox box)
        {
            int locOfTopOfRound = -1;
            while (!box.Items[++locOfTopOfRound].ToString().Contains(TOP_OF_ROUND)) ;

            InitiativeListNode node = new InitiativeListNode();
            int position = 0;
            do
            {
                if (box.Items[locOfTopOfRound].ToString().Contains(TOP_OF_ROUND))
                {
                    string[] contents = box.Items[locOfTopOfRound].ToString().Split(' ');
                    contents[0] = "0";
                    string pushVal = string.Join(" ", contents);
                    box.Items.RemoveAt(locOfTopOfRound);
                    box.Items.Insert(locOfTopOfRound, pushVal);
                }
                else
                {
                    node.ListItem = box.Items[locOfTopOfRound].ToString();
                    node.Location = position;
                    box.Items.RemoveAt(locOfTopOfRound);
                    box.Items.Insert(locOfTopOfRound, node.ListItem);
                }
                position++;

                locOfTopOfRound++;
                if (locOfTopOfRound == box.Items.Count)
                    locOfTopOfRound = 0;
            } while (!box.Items[locOfTopOfRound].ToString().Contains(TOP_OF_ROUND) && box.Items.Count > 1);
        }

        public static void TrimUndoListBox(List<ListBox> undoBox, int currentPosition)
        {
            while (currentPosition < undoBox.Count)
            {
                undoBox.RemoveAt(undoBox.Count - 1);
            }
        }

        public static string UpdatePlayerTurnLabel(ListBox box)
        {
            if (!box.Items[0].ToString().Contains(TOP_OF_ROUND))
                return box.Items[0].ToString().Split(' ')[1];
            else
                return TOP_LABEL_TEXT;
        }

        #endregion

        #region Private Static Methods

        private static int GetLocationList(ListBox box, int position)
        {
            int locOfTopOfRound = 0;
            while (!box.Items[locOfTopOfRound++].ToString().Contains(TOP_OF_ROUND)) ;

            for (int positionCount = 1; positionCount < position && !box.Items[locOfTopOfRound].ToString().Contains(TOP_OF_ROUND); positionCount++)
            {
                if (locOfTopOfRound == box.Items.Count)
                    locOfTopOfRound = 0;
                locOfTopOfRound++;
            }

            return locOfTopOfRound;
        }

        private static int GetLocationRoll(ListBox box, int roll)
        {
            for (int position = 0; position < box.Items.Count; position++)
            {
                if (!box.Items[position].ToString().Contains(TOP_OF_ROUND))
                {
                    InitiativeListNode tmp = new InitiativeListNode(box.Items[position].ToString());
                    if (roll >= tmp.Roll)
                    {
                        return position;
                    }
                }
            }
            return box.Items.Count;
        }

        #endregion
    }
}
