using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Action_Dice
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        #region Initiative

        private int undoRedoTracker = 0;
        private List<System.Windows.Forms.ListBox> undoInitiativeListBox = new List<ListBox>();

        //adds to the specific spot in the list.
        //Rat 3 would put rat at index 3 in the list.
        private void AddList_Click(object sender, EventArgs e)
        {
            if (InitiativeTextBox.Text != "")
            {
                string[] contents = InitiativeTextBox.Text.Split(' ');
                InitiativeTextBox.Text = "";
                try
                {
                    InitiativeManager.AddListPlace(InitiativeListBox, contents[0], Convert.ToInt32(contents[1]));

                    undoRedoTracker = InitiativeManager.UpdateUndoBox(InitiativeListBox, undoInitiativeListBox, undoRedoTracker);
                }
                catch (IndexOutOfRangeException)
                {
                }
                catch (FormatException)
                {
                }
            }
        }

        //adds the result to the list and orders them by that.
        //Rat 3 would mean I rolled a total of 3 and it orders them by the roll result.
        private void AddRoll_Click(object sender, EventArgs e)
        {
            if (InitiativeTextBox.Text != "")
            {
                string[] contents = InitiativeTextBox.Text.Split(' ');
                InitiativeTextBox.Text = "";
                try
                {
                    if (contents.Length == 1)
                        InitiativeManager.AddRollPlace(InitiativeListBox, contents[0]);
                    else
                        InitiativeManager.AddRollPlace(InitiativeListBox, contents[0], Convert.ToInt32(contents[1]));

                    undoRedoTracker = InitiativeManager.UpdateUndoBox(InitiativeListBox, undoInitiativeListBox, undoRedoTracker);

                    if (!InitiativeListBox.Items[0].ToString().Contains(InitiativeManager.TOP_OF_ROUND))
                        PlayerTurnLabel.Text = InitiativeListBox.Items[0].ToString().Split(' ')[1];
                    else
                        PlayerTurnLabel.Text = InitiativeManager.TOP_LABEL_TEXT;
                }
                catch (IndexOutOfRangeException)
                {
                }
                catch (FormatException)
                {
                }
            }
        }

        //adds a number of creatures based on the count given.
        //Rat 3 would make 3 rats, roll their initiative and assign their place.
        private void AddCount_Click(object sender, EventArgs e)
        {
            if (InitiativeTextBox.Text != "")
            {
                string[] contents = InitiativeTextBox.Text.Split(' ');
                InitiativeTextBox.Text = "";
                try
                {
                    Dice roller = new Dice();
                    for (int count = 0; count < Convert.ToInt32(contents[1]); count++)
                    {
                        InitiativeManager.AddRollPlace(InitiativeListBox, contents[0] + Convert.ToString(count + 1), roller.roll(6, 2));
                    }

                    undoRedoTracker = InitiativeManager.UpdateUndoBox(InitiativeListBox, undoInitiativeListBox, undoRedoTracker);

                    if (!InitiativeListBox.Items[0].ToString().Contains(InitiativeManager.TOP_OF_ROUND))
                        PlayerTurnLabel.Text = InitiativeListBox.Items[0].ToString().Split(' ')[1];
                    else
                        PlayerTurnLabel.Text = InitiativeManager.TOP_LABEL_TEXT;
                }
                catch (IndexOutOfRangeException)
                {
                }
                catch (FormatException)
                {
                }
            }
        }

        //Finds the next turn of someone that isn't downed.
        private void Next_Click(object sender, EventArgs e)
        {
            do
            {
                string tmpNext = InitiativeListBox.Items[0].ToString();
                InitiativeListBox.Items.RemoveAt(0);
                InitiativeListBox.Items.Insert(InitiativeListBox.Items.Count, tmpNext);
            }
            while (InitiativeListBox.Items[0].ToString().EndsWith(" Down"));

            if (!InitiativeListBox.Items[0].ToString().Contains(InitiativeManager.TOP_OF_ROUND))
                PlayerTurnLabel.Text = InitiativeListBox.Items[0].ToString().Split(' ')[1];
            else
                PlayerTurnLabel.Text = InitiativeManager.TOP_LABEL_TEXT;

            undoRedoTracker = InitiativeManager.UpdateUndoBox(InitiativeListBox, undoInitiativeListBox, undoRedoTracker);
        }

        //Steps to the very next item in the list.
        private void Step_Click(object sender, EventArgs e)
        {
            string tmpStep = InitiativeListBox.Items[0].ToString();
            InitiativeListBox.Items.RemoveAt(0);
            InitiativeListBox.Items.Insert(InitiativeListBox.Items.Count, tmpStep);

            if (!InitiativeListBox.Items[0].ToString().Contains(InitiativeManager.TOP_OF_ROUND))
                PlayerTurnLabel.Text = InitiativeListBox.Items[0].ToString().Split(' ')[1];
            else
                PlayerTurnLabel.Text = InitiativeManager.TOP_LABEL_TEXT;

            undoRedoTracker = InitiativeManager.UpdateUndoBox(InitiativeListBox, undoInitiativeListBox, undoRedoTracker);
        }

        //Moves the current item to another place in the list.
        //If it were the Rat's turn and I put 3 in movelist, it would move rat to index 3.
        private void MoveList_Click(object sender, EventArgs e)
        {
            if (InitiativeTextBox.Text != "")
            {
                string[] contents = InitiativeTextBox.Text.Split(' ');
                InitiativeTextBox.Text = "";
                try
                {
                    if (Convert.ToInt32(contents[1]) > InitiativeListBox.Items.Count)
                        contents[1] = Convert.ToString(InitiativeListBox.Items.Count);
                    for (int index = 0; index < InitiativeListBox.Items.Count; index++)
                    {
                        if (!InitiativeListBox.Items[index].ToString().Contains(InitiativeManager.TOP_OF_ROUND))
                        {
                            InitiativeListNode tmp = new InitiativeListNode(InitiativeListBox.Items[index].ToString());
                            if (tmp.Name.Contains(contents[0]))
                            {
                                string tmpStr = InitiativeListBox.Items[index].ToString();
                                InitiativeListBox.Items.Insert(Convert.ToInt32(contents[1]), tmpStr);
                                InitiativeListBox.Items.RemoveAt(index);
                            }
                        }
                    }

                    undoRedoTracker = InitiativeManager.UpdateUndoBox(InitiativeListBox, undoInitiativeListBox, undoRedoTracker);

                    if (!InitiativeListBox.Items[0].ToString().Contains(InitiativeManager.TOP_OF_ROUND))
                        PlayerTurnLabel.Text = InitiativeListBox.Items[0].ToString().Split(' ')[1];
                    else
                        PlayerTurnLabel.Text = InitiativeManager.TOP_LABEL_TEXT;

                    InitiativeManager.UpdatePositions(InitiativeListBox);
                }
                catch (IndexOutOfRangeException)
                {
                }
                catch (FormatException)
                {
                }
            }
        }

        //Clears out the listview.
        private void InitiativeClear_Click(object sender, EventArgs e)
        {
            InitiativeManager.Start(InitiativeListBox, PlayerTurnLabel);

            undoRedoTracker = InitiativeManager.UpdateUndoBox(InitiativeListBox, undoInitiativeListBox, undoRedoTracker);
        }

        private void Down_Click(object sender, EventArgs e)
        {
            if (!InitiativeListBox.Items[0].ToString().Contains(InitiativeManager.TOP_OF_ROUND))
            {
                if (InitiativeListBox.Items[0].ToString().EndsWith(" Down"))
                {
                    string replace = InitiativeListBox.Items[0].ToString().Replace(" Down", "");
                    InitiativeListBox.Items.RemoveAt(0);
                    InitiativeListBox.Items.Insert(0, replace);
                }
                else
                {
                    string insert = InitiativeListBox.Items[0].ToString().Insert(InitiativeListBox.Items[0].ToString().Length, " Down");
                    InitiativeListBox.Items.RemoveAt(0);
                    InitiativeListBox.Items.Insert(0, insert);
                }
            }
            undoRedoTracker = InitiativeManager.UpdateUndoBox(InitiativeListBox, undoInitiativeListBox, undoRedoTracker);
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            if (undoRedoTracker > 1)
            {
                undoRedoTracker--;
                InitiativeListBox.Items.Clear();
                InitiativeListBox.Items.AddRange(undoInitiativeListBox[undoRedoTracker - 1].Items);

                if (!InitiativeListBox.Items[0].ToString().Contains(InitiativeManager.TOP_OF_ROUND))
                    PlayerTurnLabel.Text = InitiativeListBox.Items[0].ToString().Split(' ')[1];
                else
                    PlayerTurnLabel.Text = InitiativeManager.TOP_LABEL_TEXT;
            }
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            if (undoRedoTracker < undoInitiativeListBox.Count)
            {
                undoRedoTracker++;
                InitiativeListBox.Items.Clear();
                InitiativeListBox.Items.AddRange(undoInitiativeListBox[undoRedoTracker - 1].Items);
            }
        }

        #endregion

        #region Treasure
        private void TreasureButton_Click(object sender, EventArgs e)
        {
            if (TreasureTextBox.Text != "")
            {
                try
                {
                    TreasureListBox.Items.Clear();
                    TreasureListBox.Items.Add(Treasure.compute(Convert.ToInt32(TreasureTextBox.Text)));
                    TreasureTextBox.Text = "";
                }
                catch (FormatException)
                {
                    TreasureTextBox.Text = "";
                }
            }
        }

        #endregion

        #region Battle
        private void Attack_Click(object sender, EventArgs e)
        {
            if (BattleTextBox.Text != "")
            {
                try
                {
                    string[] contents = BattleTextBox.Text.Split(' ');
                    BattleTextBox.Text = "";
                    BattleManager.AddAttack(BattleListBox, Convert.ToInt32(contents[0]), Convert.ToInt32(contents[1]));
                }
                catch (IndexOutOfRangeException) //Placeholder.
                {

                }
            }
        }

        private void Defend_Click(object sender, EventArgs e)
        {
            try
            {
                if (BattleTextBox.Text != "")
                {
                    string[] contents = BattleTextBox.Text.Split(' ');
                    BattleTextBox.Text = "";
                    BattleManager.AddDefend(BattleListBox, contents[0], Convert.ToInt32(contents[1]), Convert.ToInt32(contents[2]));
                }
                else
                {
                    BattleManager.AddDefend(BattleListBox, BattleManager.PASS);
                }
            }
            catch (IndexOutOfRangeException)
            {

            }
        }

        private void Resolve_Click(object sender, EventArgs e)
        {
            BattleManager.Resolve(BattleListBox, DamageListBox);
        }








        #endregion
    }
}
