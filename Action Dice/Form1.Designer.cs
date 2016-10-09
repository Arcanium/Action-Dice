namespace Action_Dice
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.AddList = new System.Windows.Forms.Button();
            this.AddRoll = new System.Windows.Forms.Button();
            this.AddCount = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.Step = new System.Windows.Forms.Button();
            this.MoveList = new System.Windows.Forms.Button();
            this.InitiativeClear = new System.Windows.Forms.Button();
            this.InitiativeListBox = new System.Windows.Forms.ListBox();
            this.InitiativeTextBox = new System.Windows.Forms.TextBox();
            this.TreasureListBox = new System.Windows.Forms.ListBox();
            this.TreasureButton = new System.Windows.Forms.Button();
            this.TreasureTextBox = new System.Windows.Forms.TextBox();
            this.TreasureLabel = new System.Windows.Forms.Label();
            this.InitiativeLabel = new System.Windows.Forms.Label();
            this.BattleListBox = new System.Windows.Forms.ListBox();
            this.PlayerTurnLabel = new System.Windows.Forms.Label();
            this.BattleTextBox = new System.Windows.Forms.TextBox();
            this.BattleLabel = new System.Windows.Forms.Label();
            this.Attack = new System.Windows.Forms.Button();
            this.Defend = new System.Windows.Forms.Button();
            this.Resolve = new System.Windows.Forms.Button();
            this.DamageListBox = new System.Windows.Forms.ListBox();
            this.DamageLabel = new System.Windows.Forms.Label();
            this.Reset = new System.Windows.Forms.Button();
            this.BattleClear = new System.Windows.Forms.Button();
            this.Down = new System.Windows.Forms.Button();
            this.Undo = new System.Windows.Forms.Button();
            this.Redo = new System.Windows.Forms.Button();
            this.AddListTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.AddRollTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.AddCountTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.DownTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.NextTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.StepTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.MoveListTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.AttackTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.DefendTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.ResolveTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ManagerTab = new System.Windows.Forms.TabPage();
            this.GeneratorTab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.ManagerTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddList
            // 
            this.AddList.Location = new System.Drawing.Point(678, 80);
            this.AddList.Name = "AddList";
            this.AddList.Size = new System.Drawing.Size(75, 23);
            this.AddList.TabIndex = 0;
            this.AddList.Text = "Add List";
            this.AddListTooltip.SetToolTip(this.AddList, "Enter a name and number, for the position of the list to place it on.");
            this.AddList.UseVisualStyleBackColor = true;
            this.AddList.Click += new System.EventHandler(this.AddList_Click);
            // 
            // AddRoll
            // 
            this.AddRoll.Location = new System.Drawing.Point(678, 109);
            this.AddRoll.Name = "AddRoll";
            this.AddRoll.Size = new System.Drawing.Size(75, 23);
            this.AddRoll.TabIndex = 1;
            this.AddRoll.Text = "Add Roll";
            this.AddRollTooltip.SetToolTip(this.AddRoll, "Enter a name and number, to assign the player a roll.");
            this.AddRoll.UseVisualStyleBackColor = true;
            this.AddRoll.Click += new System.EventHandler(this.AddRoll_Click);
            // 
            // AddCount
            // 
            this.AddCount.Location = new System.Drawing.Point(678, 138);
            this.AddCount.Name = "AddCount";
            this.AddCount.Size = new System.Drawing.Size(75, 23);
            this.AddCount.TabIndex = 2;
            this.AddCount.Text = "Add Stack";
            this.AddCountTooltip.SetToolTip(this.AddCount, "Enter a name and number, for the number of mobs wanted.");
            this.AddCount.UseVisualStyleBackColor = true;
            this.AddCount.Click += new System.EventHandler(this.AddCount_Click);
            // 
            // Next
            // 
            this.Next.Location = new System.Drawing.Point(678, 167);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(75, 23);
            this.Next.TabIndex = 3;
            this.Next.Text = "Next";
            this.NextTooltip.SetToolTip(this.Next, "Moves to the next player that isn\'t down.");
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // Step
            // 
            this.Step.Location = new System.Drawing.Point(678, 196);
            this.Step.Name = "Step";
            this.Step.Size = new System.Drawing.Size(75, 23);
            this.Step.TabIndex = 4;
            this.Step.Text = "Step";
            this.StepTooltip.SetToolTip(this.Step, "Moves to the next item in the list.");
            this.Step.UseVisualStyleBackColor = true;
            this.Step.Click += new System.EventHandler(this.Step_Click);
            // 
            // MoveList
            // 
            this.MoveList.Location = new System.Drawing.Point(678, 254);
            this.MoveList.Name = "MoveList";
            this.MoveList.Size = new System.Drawing.Size(75, 23);
            this.MoveList.TabIndex = 5;
            this.MoveList.Text = "Move List";
            this.MoveListTooltip.SetToolTip(this.MoveList, "Enter a name and number, to move the character to that position.");
            this.MoveList.UseVisualStyleBackColor = true;
            this.MoveList.Click += new System.EventHandler(this.MoveList_Click);
            // 
            // InitiativeClear
            // 
            this.InitiativeClear.Location = new System.Drawing.Point(759, 80);
            this.InitiativeClear.Name = "InitiativeClear";
            this.InitiativeClear.Size = new System.Drawing.Size(75, 23);
            this.InitiativeClear.TabIndex = 7;
            this.InitiativeClear.Text = "Clear";
            this.InitiativeClear.UseVisualStyleBackColor = true;
            this.InitiativeClear.Click += new System.EventHandler(this.InitiativeClear_Click);
            // 
            // InitiativeListBox
            // 
            this.InitiativeListBox.FormattingEnabled = true;
            this.InitiativeListBox.Location = new System.Drawing.Point(31, 80);
            this.InitiativeListBox.Name = "InitiativeListBox";
            this.InitiativeListBox.Size = new System.Drawing.Size(641, 472);
            this.InitiativeListBox.TabIndex = 8;
            // 
            // InitiativeTextBox
            // 
            this.InitiativeTextBox.Location = new System.Drawing.Point(31, 48);
            this.InitiativeTextBox.Name = "InitiativeTextBox";
            this.InitiativeTextBox.Size = new System.Drawing.Size(641, 20);
            this.InitiativeTextBox.TabIndex = 9;
            // 
            // TreasureListBox
            // 
            this.TreasureListBox.FormattingEnabled = true;
            this.TreasureListBox.Location = new System.Drawing.Point(31, 657);
            this.TreasureListBox.Name = "TreasureListBox";
            this.TreasureListBox.Size = new System.Drawing.Size(641, 30);
            this.TreasureListBox.TabIndex = 10;
            // 
            // TreasureButton
            // 
            this.TreasureButton.Location = new System.Drawing.Point(678, 657);
            this.TreasureButton.Name = "TreasureButton";
            this.TreasureButton.Size = new System.Drawing.Size(75, 23);
            this.TreasureButton.TabIndex = 11;
            this.TreasureButton.Text = "Treasure";
            this.TreasureButton.UseVisualStyleBackColor = true;
            this.TreasureButton.Click += new System.EventHandler(this.TreasureButton_Click);
            // 
            // TreasureTextBox
            // 
            this.TreasureTextBox.Location = new System.Drawing.Point(31, 631);
            this.TreasureTextBox.Name = "TreasureTextBox";
            this.TreasureTextBox.Size = new System.Drawing.Size(641, 20);
            this.TreasureTextBox.TabIndex = 12;
            // 
            // TreasureLabel
            // 
            this.TreasureLabel.AutoSize = true;
            this.TreasureLabel.Location = new System.Drawing.Point(32, 613);
            this.TreasureLabel.Name = "TreasureLabel";
            this.TreasureLabel.Size = new System.Drawing.Size(110, 13);
            this.TreasureLabel.TabIndex = 13;
            this.TreasureLabel.Text = "Input Dungeon Level:";
            // 
            // InitiativeLabel
            // 
            this.InitiativeLabel.AutoSize = true;
            this.InitiativeLabel.Location = new System.Drawing.Point(28, 22);
            this.InitiativeLabel.Name = "InitiativeLabel";
            this.InitiativeLabel.Size = new System.Drawing.Size(69, 13);
            this.InitiativeLabel.TabIndex = 14;
            this.InitiativeLabel.Text = "Current Turn:";
            // 
            // BattleListBox
            // 
            this.BattleListBox.FormattingEnabled = true;
            this.BattleListBox.Location = new System.Drawing.Point(1000, 74);
            this.BattleListBox.Name = "BattleListBox";
            this.BattleListBox.Size = new System.Drawing.Size(288, 472);
            this.BattleListBox.TabIndex = 15;
            // 
            // PlayerTurnLabel
            // 
            this.PlayerTurnLabel.AutoSize = true;
            this.PlayerTurnLabel.Location = new System.Drawing.Point(103, 22);
            this.PlayerTurnLabel.Name = "PlayerTurnLabel";
            this.PlayerTurnLabel.Size = new System.Drawing.Size(84, 13);
            this.PlayerTurnLabel.TabIndex = 16;
            this.PlayerTurnLabel.Text = "PlayerTurnLabel";
            // 
            // BattleTextBox
            // 
            this.BattleTextBox.Location = new System.Drawing.Point(1000, 48);
            this.BattleTextBox.Name = "BattleTextBox";
            this.BattleTextBox.Size = new System.Drawing.Size(288, 20);
            this.BattleTextBox.TabIndex = 17;
            // 
            // BattleLabel
            // 
            this.BattleLabel.AutoSize = true;
            this.BattleLabel.Location = new System.Drawing.Point(997, 22);
            this.BattleLabel.Name = "BattleLabel";
            this.BattleLabel.Size = new System.Drawing.Size(110, 13);
            this.BattleLabel.TabIndex = 18;
            this.BattleLabel.Text = "Attacks and Defends:";
            // 
            // Attack
            // 
            this.Attack.Location = new System.Drawing.Point(1294, 74);
            this.Attack.Name = "Attack";
            this.Attack.Size = new System.Drawing.Size(75, 23);
            this.Attack.TabIndex = 19;
            this.Attack.Text = "Add Attack";
            this.AttackTooltip.SetToolTip(this.Attack, "Enter two numbers separated by a space, for the attack roll and attack bonus.");
            this.Attack.UseVisualStyleBackColor = true;
            this.Attack.Click += new System.EventHandler(this.Attack_Click);
            // 
            // Defend
            // 
            this.Defend.Location = new System.Drawing.Point(1295, 103);
            this.Defend.Name = "Defend";
            this.Defend.Size = new System.Drawing.Size(75, 23);
            this.Defend.TabIndex = 20;
            this.Defend.Text = "Add Defend";
            this.DefendTooltip.SetToolTip(this.Defend, "Enter nothing to pass, or block or dodge followed by two numbers all separated by" +
        " a space, for the defense roll and bonus.");
            this.Defend.UseVisualStyleBackColor = true;
            this.Defend.Click += new System.EventHandler(this.Defend_Click);
            // 
            // Resolve
            // 
            this.Resolve.Location = new System.Drawing.Point(1294, 132);
            this.Resolve.Name = "Resolve";
            this.Resolve.Size = new System.Drawing.Size(75, 23);
            this.Resolve.TabIndex = 21;
            this.Resolve.Text = "Resolve";
            this.ResolveTooltip.SetToolTip(this.Resolve, "Resolves all complete attacks and defends.");
            this.Resolve.UseVisualStyleBackColor = true;
            this.Resolve.Click += new System.EventHandler(this.Resolve_Click);
            // 
            // DamageListBox
            // 
            this.DamageListBox.FormattingEnabled = true;
            this.DamageListBox.Location = new System.Drawing.Point(1294, 48);
            this.DamageListBox.Name = "DamageListBox";
            this.DamageListBox.Size = new System.Drawing.Size(76, 17);
            this.DamageListBox.TabIndex = 22;
            // 
            // DamageLabel
            // 
            this.DamageLabel.AutoSize = true;
            this.DamageLabel.Location = new System.Drawing.Point(1291, 22);
            this.DamageLabel.Name = "DamageLabel";
            this.DamageLabel.Size = new System.Drawing.Size(50, 13);
            this.DamageLabel.TabIndex = 23;
            this.DamageLabel.Text = "Damage:";
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(1294, 161);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 24;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // BattleClear
            // 
            this.BattleClear.Location = new System.Drawing.Point(1294, 190);
            this.BattleClear.Name = "BattleClear";
            this.BattleClear.Size = new System.Drawing.Size(75, 23);
            this.BattleClear.TabIndex = 25;
            this.BattleClear.Text = "Clear";
            this.BattleClear.UseVisualStyleBackColor = true;
            this.BattleClear.Click += new System.EventHandler(this.BattleClear_Click);
            // 
            // Down
            // 
            this.Down.Location = new System.Drawing.Point(678, 225);
            this.Down.Name = "Down";
            this.Down.Size = new System.Drawing.Size(75, 23);
            this.Down.TabIndex = 26;
            this.Down.Text = "Down";
            this.DownTooltip.SetToolTip(this.Down, "Marks a character or enemy as downed.");
            this.Down.UseVisualStyleBackColor = true;
            this.Down.Click += new System.EventHandler(this.Down_Click);
            // 
            // Undo
            // 
            this.Undo.Location = new System.Drawing.Point(759, 109);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(75, 23);
            this.Undo.TabIndex = 27;
            this.Undo.Text = "Undo";
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // Redo
            // 
            this.Redo.Location = new System.Drawing.Point(759, 138);
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(75, 23);
            this.Redo.TabIndex = 28;
            this.Redo.Text = "Redo";
            this.Redo.UseVisualStyleBackColor = true;
            this.Redo.Click += new System.EventHandler(this.Redo_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ManagerTab);
            this.tabControl1.Controls.Add(this.GeneratorTab);
            this.tabControl1.Location = new System.Drawing.Point(-5, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(1475, 770);
            this.tabControl1.TabIndex = 29;
            // 
            // ManagerTab
            // 
            this.ManagerTab.BackColor = System.Drawing.Color.Transparent;
            this.ManagerTab.Controls.Add(this.InitiativeLabel);
            this.ManagerTab.Controls.Add(this.BattleClear);
            this.ManagerTab.Controls.Add(this.Redo);
            this.ManagerTab.Controls.Add(this.Reset);
            this.ManagerTab.Controls.Add(this.PlayerTurnLabel);
            this.ManagerTab.Controls.Add(this.Resolve);
            this.ManagerTab.Controls.Add(this.DamageListBox);
            this.ManagerTab.Controls.Add(this.Defend);
            this.ManagerTab.Controls.Add(this.DamageLabel);
            this.ManagerTab.Controls.Add(this.Attack);
            this.ManagerTab.Controls.Add(this.Undo);
            this.ManagerTab.Controls.Add(this.InitiativeTextBox);
            this.ManagerTab.Controls.Add(this.Down);
            this.ManagerTab.Controls.Add(this.InitiativeListBox);
            this.ManagerTab.Controls.Add(this.AddList);
            this.ManagerTab.Controls.Add(this.BattleListBox);
            this.ManagerTab.Controls.Add(this.BattleTextBox);
            this.ManagerTab.Controls.Add(this.BattleLabel);
            this.ManagerTab.Controls.Add(this.AddRoll);
            this.ManagerTab.Controls.Add(this.AddCount);
            this.ManagerTab.Controls.Add(this.Next);
            this.ManagerTab.Controls.Add(this.Step);
            this.ManagerTab.Controls.Add(this.TreasureButton);
            this.ManagerTab.Controls.Add(this.TreasureTextBox);
            this.ManagerTab.Controls.Add(this.TreasureListBox);
            this.ManagerTab.Controls.Add(this.MoveList);
            this.ManagerTab.Controls.Add(this.InitiativeClear);
            this.ManagerTab.Location = new System.Drawing.Point(4, 22);
            this.ManagerTab.Name = "ManagerTab";
            this.ManagerTab.Padding = new System.Windows.Forms.Padding(3);
            this.ManagerTab.Size = new System.Drawing.Size(1467, 744);
            this.ManagerTab.TabIndex = 0;
            this.ManagerTab.Text = "GM Assistant";
            // 
            // GeneratorTab
            // 
            this.GeneratorTab.BackColor = System.Drawing.Color.LightGray;
            this.GeneratorTab.Location = new System.Drawing.Point(4, 22);
            this.GeneratorTab.Name = "GeneratorTab";
            this.GeneratorTab.Padding = new System.Windows.Forms.Padding(3);
            this.GeneratorTab.Size = new System.Drawing.Size(1467, 744);
            this.GeneratorTab.TabIndex = 1;
            this.GeneratorTab.Text = "Character Generator";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 749);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.TreasureLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Action Dice";
            this.tabControl1.ResumeLayout(false);
            this.ManagerTab.ResumeLayout(false);
            this.ManagerTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddList;
        private System.Windows.Forms.Button AddRoll;
        private System.Windows.Forms.Button AddCount;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button Step;
        private System.Windows.Forms.Button MoveList;
        private System.Windows.Forms.Button InitiativeClear;
        private System.Windows.Forms.ListBox InitiativeListBox;
        private System.Windows.Forms.TextBox InitiativeTextBox;
        private System.Windows.Forms.ListBox TreasureListBox;
        private System.Windows.Forms.Button TreasureButton;
        private System.Windows.Forms.TextBox TreasureTextBox;
        private System.Windows.Forms.Label TreasureLabel;
        private System.Windows.Forms.Label InitiativeLabel;
        private System.Windows.Forms.ListBox BattleListBox;
        private System.Windows.Forms.Label PlayerTurnLabel;
        private System.Windows.Forms.TextBox BattleTextBox;
        private System.Windows.Forms.Label BattleLabel;
        private System.Windows.Forms.Button Attack;
        private System.Windows.Forms.Button Defend;
        private System.Windows.Forms.Button Resolve;
        private System.Windows.Forms.ListBox DamageListBox;
        private System.Windows.Forms.Label DamageLabel;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button BattleClear;
        private System.Windows.Forms.Button Down;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button Redo;
        private System.Windows.Forms.ToolTip AddListTooltip;
        private System.Windows.Forms.ToolTip AddRollTooltip;
        private System.Windows.Forms.ToolTip AddCountTooltip;
        private System.Windows.Forms.ToolTip DownTooltip;
        private System.Windows.Forms.ToolTip NextTooltip;
        private System.Windows.Forms.ToolTip StepTooltip;
        private System.Windows.Forms.ToolTip MoveListTooltip;
        private System.Windows.Forms.ToolTip AttackTooltip;
        private System.Windows.Forms.ToolTip DefendTooltip;
        private System.Windows.Forms.ToolTip ResolveTooltip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ManagerTab;
        private System.Windows.Forms.TabPage GeneratorTab;
    }
}

