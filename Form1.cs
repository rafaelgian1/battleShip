using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Drawing.Text;

namespace battleShips
{
    public partial class NavalBattles : Form
    {
        public static int BoardSize = 10; // Μέγεθος πίνακα 10x10
        private shipsPlacement ships;
        private selectAttackAreas attackManager;
        //private Timer enemyTurnTimer;
        private int playerScore = 0;
        private int enemyScore = 0;



        public NavalBattles()
        {

            InitializeComponent();
            ships = new shipsPlacement(BoardSize);
            attackManager = ships.attackManager;
            InitializeGame();
        }

        private void InitializeGame()
        {
            ships.createGrid();
            ships.renderGrid(playerTableLayoutPanel, ships.playerGrid, revealShips: true);
            ships.renderGrid(enemyTableLayoutPanel, ships.enemyGrid, revealShips: false);

            enemyTurnTimer = new Timer();
            enemyTurnTimer.Interval = 1000;
            enemyTurnTimer.Tick += EnemyTurnTimer_Tick;
        }

        private void EnemyTurnTimer_Tick(object sender, EventArgs E)
        {
            enemyTurnTimer.Stop();
            EnemyMove();
        }

        private void enemyuTableLayoutPanel_Click(object sender, EventArgs e)
        {
            if(sender is Button clickedButton)
            {
                bool hit = attackManager.selectAttackPosition(clickedButton);
                clickedButton.Enabled = false;
                if (hit)
                {
                    clickedButton.BackColor = Color.Red;
                    clickedButton.Text = "X";
                }
                else
                {
                    clickedButton.BackColor = Color.Green;
                    clickedButton.Text = "-";
                }
                PlayerMove(sender,e);
            }
        }
        private void PlayerMove(object sender, EventArgs E)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            if (attackManager.selectAttackPosition(clickedButton))
            {
                clickedButton.Enabled = false;
                if (attackManager.IsShipHit(clickedButton.Tag.ToString()))
                {
                    playerScore++;
                    playerScoreIndex.Text = $"{playerScore}";
                }

                if (attackManager.AreAllShipsSunk())
                {
                    MessageBox.Show("Συγχαρητήρια! Νίκησες!");
                    return;
                }
                enemyTurnTimer.Start();
            }
        }
        private void EnemyMove()
        {
            string position = attackManager.getPosition();
            if (position != null)
            {
                attackManager.AttackPlayer(position);
                if (attackManager.IsShipHit(position))
                {
                    enemyScore++;
                    enemyScoreIndex.Text = "${enemyScoreIndex}";
                }
            }
            if (attackManager.AreAllPlayerShipSunk()){
                MessageBox.Show($"Δυστυχώς έχασες! Ο αντίπαλος έχει κερδίσει με συνολικό σκορ {enemyScoreIndex} πόντους");
            }
        }
        private void RestartButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void RestartGame() {
            playerScore = 0;
            enemyScore = 0;
            playerScoreIndex.Text = "0";
            enemyScoreIndex.Text = "0";

            ships = new shipsPlacement(BoardSize);
            attackManager = ships.attackManager;
            InitializeGame();
        }
    }
}