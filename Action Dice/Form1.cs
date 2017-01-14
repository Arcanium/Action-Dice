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
            InitiativeManager.Start(InitiativeListBox, PlayerTurnLabel);
            BattleManager.Start(BattleListBox, DamageListBox);
            GeneratorManager.Start(SurpriseCombatFirstPreference, SurpriseCombatSecondPreference, SurpriseCombatThirdPreference,
                SurpriseNonCombatFirstPreference, SurpriseNonCombatSecondPreference, SurpriseNonCombatThirdPreference);
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
                    if (contents.Length == 1)
                        InitiativeManager.AddListPlace(InitiativeListBox, contents[0]);
                    else
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
                    PlayerTurnLabel.Text = InitiativeManager.UpdatePlayerTurnLabel(InitiativeListBox);
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
                    PlayerTurnLabel.Text = InitiativeManager.UpdatePlayerTurnLabel(InitiativeListBox);
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
            while (InitiativeListBox.Items[0].ToString().EndsWith(InitiativeManager.DOWN));

            PlayerTurnLabel.Text = InitiativeManager.UpdatePlayerTurnLabel(InitiativeListBox);
            undoRedoTracker = InitiativeManager.UpdateUndoBox(InitiativeListBox, undoInitiativeListBox, undoRedoTracker);
        }

        //Steps to the very next item in the list.
        private void Step_Click(object sender, EventArgs e)
        {
            string tmpStep = InitiativeListBox.Items[0].ToString();
            InitiativeListBox.Items.RemoveAt(0);
            InitiativeListBox.Items.Insert(InitiativeListBox.Items.Count, tmpStep);

            PlayerTurnLabel.Text = InitiativeManager.UpdatePlayerTurnLabel(InitiativeListBox);
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
                    PlayerTurnLabel.Text = InitiativeManager.UpdatePlayerTurnLabel(InitiativeListBox);
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
                if (InitiativeListBox.Items[0].ToString().EndsWith(InitiativeManager.DOWN))
                {
                    string replace = InitiativeListBox.Items[0].ToString().Replace(InitiativeManager.DOWN, "");
                    InitiativeListBox.Items.RemoveAt(0);
                    InitiativeListBox.Items.Insert(0, replace);
                }
                else
                {
                    string insert = InitiativeListBox.Items[0].ToString().Insert(InitiativeListBox.Items[0].ToString().Length, InitiativeManager.DOWN);
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

                PlayerTurnLabel.Text = InitiativeManager.UpdatePlayerTurnLabel(InitiativeListBox);
            }
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            if (undoRedoTracker < undoInitiativeListBox.Count)
            {
                undoRedoTracker++;
                InitiativeListBox.Items.Clear();
                InitiativeListBox.Items.AddRange(undoInitiativeListBox[undoRedoTracker - 1].Items);

                PlayerTurnLabel.Text = InitiativeManager.UpdatePlayerTurnLabel(InitiativeListBox);
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
                    TreasureTextBox.Focus();
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
                    if (contents.Length == 1)
                        BattleManager.AddAttack(BattleListBox, Convert.ToInt32(contents[0]));
                    else if (contents.Length == 2)
                        BattleManager.AddAttack(BattleListBox, Convert.ToInt32(contents[0]), Convert.ToInt32(contents[1]));
                    else if (contents.Length == 3)
                        BattleManager.AddAttack(BattleListBox, Convert.ToInt32(contents[0]), Convert.ToInt32(contents[1]), BattleManager.PASS);
                    else if (contents.Length == 4)
                        BattleManager.AddAttack(BattleListBox, Convert.ToInt32(contents[0]), Convert.ToInt32(contents[1]), contents[2], Convert.ToInt32(contents[3]));
                    else if (contents.Length == 5)
                        BattleManager.AddAttack(BattleListBox, Convert.ToInt32(contents[0]), Convert.ToInt32(contents[1]), contents[2], Convert.ToInt32(contents[3]), Convert.ToInt32(contents[4]));
                }
                catch (IndexOutOfRangeException)
                {

                }
                catch (FormatException)
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
                    if (contents.Length == 2)
                        BattleManager.AddDefend(BattleListBox, contents[0], Convert.ToInt32(contents[1]));
                    else if (contents.Length == 3)
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
            catch (FormatException)
            {

            }
        }

        private void Resolve_Click(object sender, EventArgs e)
        {
            BattleManager.Resolve(BattleListBox, DamageListBox);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            DamageListBox.Items.Clear();
            DamageListBox.Items.Add(0);
        }

        private void BattleClear_Click(object sender, EventArgs e)
        {
            BattleManager.Start(BattleListBox, DamageListBox);
        }


        #endregion

        #region Generator

        private void GeneratorClear_Click(object sender, EventArgs e)
        {
            GeneratorListBox.Items.Clear();
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            if (GeneratorLevelTextBox.Text != "")
            {
                try
                {
                    int level = Convert.ToInt32(GeneratorLevelTextBox.Text);

                    if (SurpriseCombatFirstPreference.Checked)
                        GeneratorManager.CombatPreferenceSelect(MoveCombatFirstPreference, MeleeCombatFirstPreference, RangedCombatFirstPreference,
                            MagicCombatFirstPreference, BlockCombatFirstPreference, DodgeCombatFirstPreference, RandomCombatFirstPreference);
                    if (SurpriseCombatSecondPreference.Checked)
                        GeneratorManager.CombatPreferenceSelect(MoveCombatSecondPreference, MeleeCombatSecondPreference, RangedCombatSecondPreference,
                            MagicCombatSecondPreference, BlockCombatSecondPreference, DodgeCombatSecondPreference, RandomCombatSecondPreference);
                    if (SurpriseCombatThirdPreference.Checked)
                        GeneratorManager.CombatPreferenceSelect(MoveCombatThirdPreference, MeleeCombatThirdPreference, RangedCombatThirdPreference,
                            MagicCombatThirdPreference, BlockCombatThirdPreference, DodgeCombatThirdPreference, RandomCombatThirdPreference);

                    if (SurpriseNonCombatFirstPreference.Checked)
                        GeneratorManager.NonCombatPreferenceSelect(AnimalHandlingNonCombatFirstPreference, ArcaneArtsNonCombatFirstPreference, AthleticsNonCombatFirstPreference,
                            PerceptionNonCombatFirstPreference, PracticalNonCombatFirstPreference, PrecisionNonCombatFirstPreference, SpeechNonCombatFirstPreference,
                            StealthNonCombatFirstPreference, RandomNonCombatFirstPreference);
                    if (SurpriseNonCombatSecondPreference.Checked)
                        GeneratorManager.NonCombatPreferenceSelect(AnimalHandlingNonCombatSecondPreference, ArcaneArtsNonCombatSecondPreference, AthleticsNonCombatSecondPreference,
                            PerceptionNonCombatSecondPreference, PracticalNonCombatSecondPreference, PrecisionNonCombatSecondPreference, SpeechNonCombatSecondPreference,
                            StealthNonCombatSecondPreference, RandomNonCombatSecondPreference);
                    if (SurpriseNonCombatThirdPreference.Checked)
                        GeneratorManager.NonCombatPreferenceSelect(AnimalHandlingNonCombatThirdPreference, ArcaneArtsNonCombatThirdPreference, AthleticsNonCombatThirdPreference,
                            PerceptionNonCombatThirdPreference, PracticalNonCombatThirdPreference, PrecisionNonCombatThirdPreference, SpeechNonCombatThirdPreference,
                            StealthNonCombatThirdPreference, RandomNonCombatThirdPreference);

                    for (int baseLevel = 1; baseLevel <= level; baseLevel++)
                    {
                        int combatSkillPoints = GeneratorManager.GetSkillPointsByLevel(baseLevel);
                        int nonCombatSkillPoints = combatSkillPoints;

                        GeneratorManager.CombatSkillSelect(MoveCombatFirstPreference, MeleeCombatFirstPreference, RangedCombatFirstPreference,
                            MagicCombatFirstPreference, BlockCombatFirstPreference, DodgeCombatFirstPreference, RandomCombatFirstPreference, baseLevel);
                        combatSkillPoints--;
                        if (combatSkillPoints > 0)
                        {
                            GeneratorManager.CombatSkillSelect(MoveCombatSecondPreference, MeleeCombatSecondPreference, RangedCombatSecondPreference,
                            MagicCombatSecondPreference, BlockCombatSecondPreference, DodgeCombatSecondPreference, RandomCombatSecondPreference, baseLevel);
                            combatSkillPoints--;
                        }
                        if (combatSkillPoints > 0)
                        {
                            GeneratorManager.CombatSkillSelect(MoveCombatThirdPreference, MeleeCombatThirdPreference, RangedCombatThirdPreference,
                            MagicCombatThirdPreference, BlockCombatThirdPreference, DodgeCombatThirdPreference, RandomCombatThirdPreference, baseLevel);
                            combatSkillPoints--;
                        }
                        while (combatSkillPoints > 0)
                        {
                            GeneratorManager.RandomCombatSkillSelect(baseLevel);
                            combatSkillPoints--;
                        }

                        GeneratorManager.NonCombatSkillSelect(AnimalHandlingNonCombatFirstPreference, ArcaneArtsNonCombatFirstPreference, AthleticsNonCombatFirstPreference,
                            PerceptionNonCombatFirstPreference, PracticalNonCombatFirstPreference, PrecisionNonCombatFirstPreference, SpeechNonCombatFirstPreference,
                            StealthNonCombatFirstPreference, RandomNonCombatFirstPreference, baseLevel);
                        nonCombatSkillPoints--;
                        if (nonCombatSkillPoints > 0)
                        {
                            GeneratorManager.NonCombatSkillSelect(AnimalHandlingNonCombatSecondPreference, ArcaneArtsNonCombatSecondPreference, AthleticsNonCombatSecondPreference,
                                PerceptionNonCombatSecondPreference, PracticalNonCombatSecondPreference, PrecisionNonCombatSecondPreference, SpeechNonCombatSecondPreference,
                                StealthNonCombatSecondPreference, RandomNonCombatSecondPreference, baseLevel);
                            nonCombatSkillPoints--;
                        }
                        if (nonCombatSkillPoints > 0)
                        {
                            GeneratorManager.NonCombatSkillSelect(AnimalHandlingNonCombatThirdPreference, ArcaneArtsNonCombatThirdPreference, AthleticsNonCombatThirdPreference,
                                PerceptionNonCombatThirdPreference, PracticalNonCombatThirdPreference, PrecisionNonCombatThirdPreference, SpeechNonCombatThirdPreference,
                                StealthNonCombatThirdPreference, RandomNonCombatThirdPreference, baseLevel);
                            nonCombatSkillPoints--;
                        }
                        while (nonCombatSkillPoints > 0)
                        {
                            GeneratorManager.RandomNonCombatSkillSelect(baseLevel);
                            nonCombatSkillPoints--;
                        }
                    }

                    //Print out the results.
                    GeneratorManager.CreateCharacter(GeneratorListBox, level, GeneratorNameTextBox.Text);

                }
                catch (FormatException)
                {
                }
            }
        }

        #endregion
    }
}
