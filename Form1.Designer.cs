namespace battleShips
{
    partial class NavalBattles
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
            this.scoreIndex1 = new System.Windows.Forms.Label();
            this.playerScore1 = new System.Windows.Forms.Label();
            this.playerScore2 = new System.Windows.Forms.Label();
            this.scoreIndex2 = new System.Windows.Forms.Label();
            this.roundsIndex = new System.Windows.Forms.Label();
            this.locationsSelection = new System.Windows.Forms.Label();
            this.enemyLocations = new System.Windows.Forms.ComboBox();
            this.attackToOpponent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scoreIndex1
            // 
            this.scoreIndex1.AutoSize = true;
            this.scoreIndex1.BackColor = System.Drawing.Color.Transparent;
            this.scoreIndex1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreIndex1.ForeColor = System.Drawing.Color.White;
            this.scoreIndex1.Location = new System.Drawing.Point(428, 1258);
            this.scoreIndex1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreIndex1.Name = "scoreIndex1";
            this.scoreIndex1.Size = new System.Drawing.Size(80, 55);
            this.scoreIndex1.TabIndex = 0;
            this.scoreIndex1.Text = "00";
            // 
            // playerScore1
            // 
            this.playerScore1.AutoSize = true;
            this.playerScore1.BackColor = System.Drawing.Color.Transparent;
            this.playerScore1.Cursor = System.Windows.Forms.Cursors.Default;
            this.playerScore1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerScore1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.playerScore1.Location = new System.Drawing.Point(80, 1258);
            this.playerScore1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerScore1.Name = "playerScore1";
            this.playerScore1.Size = new System.Drawing.Size(325, 55);
            this.playerScore1.TabIndex = 1;
            this.playerScore1.Text = "Player Score:";
            // 
            // playerScore2
            // 
            this.playerScore2.AutoSize = true;
            this.playerScore2.BackColor = System.Drawing.Color.Transparent;
            this.playerScore2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerScore2.ForeColor = System.Drawing.Color.Red;
            this.playerScore2.Location = new System.Drawing.Point(926, 116);
            this.playerScore2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.playerScore2.Name = "playerScore2";
            this.playerScore2.Size = new System.Drawing.Size(338, 55);
            this.playerScore2.TabIndex = 2;
            this.playerScore2.Text = "Enemy Score:";
            // 
            // scoreIndex2
            // 
            this.scoreIndex2.AutoSize = true;
            this.scoreIndex2.BackColor = System.Drawing.Color.Transparent;
            this.scoreIndex2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreIndex2.ForeColor = System.Drawing.Color.Red;
            this.scoreIndex2.Location = new System.Drawing.Point(1284, 116);
            this.scoreIndex2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreIndex2.Name = "scoreIndex2";
            this.scoreIndex2.Size = new System.Drawing.Size(80, 55);
            this.scoreIndex2.TabIndex = 0;
            this.scoreIndex2.Text = "00";
            // 
            // roundsIndex
            // 
            this.roundsIndex.AutoSize = true;
            this.roundsIndex.BackColor = System.Drawing.Color.Transparent;
            this.roundsIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundsIndex.ForeColor = System.Drawing.Color.White;
            this.roundsIndex.Location = new System.Drawing.Point(2392, 40);
            this.roundsIndex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roundsIndex.Name = "roundsIndex";
            this.roundsIndex.Size = new System.Drawing.Size(80, 55);
            this.roundsIndex.TabIndex = 0;
            this.roundsIndex.Text = "00";
            // 
            // locationsSelection
            // 
            this.locationsSelection.AutoSize = true;
            this.locationsSelection.BackColor = System.Drawing.Color.Transparent;
            this.locationsSelection.Cursor = System.Windows.Forms.Cursors.Default;
            this.locationsSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationsSelection.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.locationsSelection.Location = new System.Drawing.Point(80, 116);
            this.locationsSelection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationsSelection.Name = "locationsSelection";
            this.locationsSelection.Size = new System.Drawing.Size(406, 55);
            this.locationsSelection.TabIndex = 1;
            this.locationsSelection.Text = "Attack Locations:";
            // 
            // enemyLocations
            // 
            this.enemyLocations.BackColor = System.Drawing.SystemColors.HighlightText;
            this.enemyLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enemyLocations.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enemyLocations.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.enemyLocations.FormattingEnabled = true;
            this.enemyLocations.Location = new System.Drawing.Point(528, 116);
            this.enemyLocations.Margin = new System.Windows.Forms.Padding(4);
            this.enemyLocations.Name = "enemyLocations";
            this.enemyLocations.Size = new System.Drawing.Size(220, 63);
            this.enemyLocations.TabIndex = 3;
            // 
            // attackToOpponent
            // 
            this.attackToOpponent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.attackToOpponent.Font = new System.Drawing.Font("Segoe Script", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attackToOpponent.Location = new System.Drawing.Point(1770, 1292);
            this.attackToOpponent.Margin = new System.Windows.Forms.Padding(6);
            this.attackToOpponent.Name = "attackToOpponent";
            this.attackToOpponent.Size = new System.Drawing.Size(266, 94);
            this.attackToOpponent.TabIndex = 5;
            this.attackToOpponent.Text = "FIRE!";
            this.attackToOpponent.UseVisualStyleBackColor = false;
//            this.attackToOpponent.Click += new System.EventHandler(this.attackToOpponentEvent);
            // 
            // NavalBattles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::battleShips.Properties.Resources.background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(2128, 1422);
            this.Controls.Add(this.attackToOpponent);
            this.Controls.Add(this.enemyLocations);
            this.Controls.Add(this.playerScore2);
            this.Controls.Add(this.locationsSelection);
            this.Controls.Add(this.playerScore1);
            this.Controls.Add(this.roundsIndex);
            this.Controls.Add(this.scoreIndex2);
            this.Controls.Add(this.scoreIndex1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "NavalBattles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreIndex1;
        private System.Windows.Forms.Label playerScore1;
        private System.Windows.Forms.Label playerScore2;
        private System.Windows.Forms.Label scoreIndex2;
        private System.Windows.Forms.Label roundsIndex;
        private System.Windows.Forms.Label locationsSelection;
        private System.Windows.Forms.ComboBox enemyLocations;
        private System.Windows.Forms.Button attackToOpponent;
    }
}

