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
        public static int BoardSize = 10;
        private shipsPlacement ships;
        private selectAttackAreas attackManager;
        private int playerScore = 0;
        private int enemyScore = 0;
        private int playerTries = 0;
        private int enemyTries = 0;
        private DateTime gameStartTime;
        private TimeSpan elapsedTime;
        private Label timerLabel = new Label();

        private bool isEnemyTurnInProgress = false;


        public NavalBattles()
        {

            InitializeComponent();
            ships = new shipsPlacement(BoardSize);
            attackManager = ships.attackManager;
            attackManager.PlayerMoveRequested += PlayerMove;
            InitializeGame();
        }

        private void InitializeGame()
        {
            ships.createGrid();
            ships.renderGrid(playerTableLayoutPanel, ships.playerGrid, revealShips: true);
            ships.renderGrid(enemyTableLayoutPanel, ships.enemyGrid, revealShips: false);


            enemyTurnTimer = new Timer();
            //enemyTurnTimer.Interval = 1000; //Για να γίνεται η κίνηση του αντιπάλου αυτόματα χωρίς να υπάρχει καθυστέρηση του interval
            enemyTurnTimer.Tick += EnemyTurnTimer_Tick;
        }

        private void EnemyTurnTimer_Tick(object sender, EventArgs E)
        {
            EnemyMove();
            enemyTurnTimer.Stop();
        }
        public void setPlayerMove(Button clickedButton)
        {
            PlayerMove(clickedButton);
        }

        private void PlayerMove(Button clickedButton)
        {
            playerTimer.Start();
            playerTries++;
            string position = clickedButton.Tag?.ToString();
            
            if (attackManager.IsEnemyShipHit(position))
            {
                
                attackManager.getEnemyHitPositions(position);
                clickedButton.BackColor = Color.Red;
                clickedButton.Text = "X";
                playerScore++;
                playerScoreIndex.Text = $"{playerScore}";

                ships.handleShiphit(position, true);
            }
            else
            {
                clickedButton.BackColor= Color.Green;
                clickedButton.Text = "-";
            }

            if (attackManager.AreAllEnemyShipsSunk())
            {
                var timePlayed = elapsedTime.ToString(@"mm\:ss");
                
                playerTimer.Stop();
                enemyTurnTimer.Stop();
                gameTimer.Stop();
                var restartOption = MessageBox.Show($"Συγχαρητήρια! Βύθισες όλα τα πλοία του αντιπάλου σου με συνολικό σκορ {playerScore} - {enemyScore}" +
                   $" Οι συνολικές σου προσπάθεις ήταν {playerTries} σε συνολικό χρόνο {timePlayed}!",
                    "Θέλεις να ξεκινήσεις νέο παιχνίδι ή να τερματιστεί;",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if (restartOption == DialogResult.Yes)
                {
                    RestartGame();
                }
                else
                {
                    Application.Exit();
                }

            }
            enemyTurnTimer.Start();
        }

        private void EnemyMove()
        {
            if (isEnemyTurnInProgress) return;
            isEnemyTurnInProgress = true;
            enemyTries++;
            string position = attackManager.getPosition();
            Button attackedButton = GetButtonFromPosition(position);

            Console.WriteLine("o antipalos epelexe " + position);//για να βλεπουμε στο debugging την επιλογή του υπολογιστή
            if (position != null)
            {

                if (attackManager.IsShipHit(position))
                {
                    attackManager.getPlayerHitPositions(position);
                    
                    attackedButton.BackgroundImage = null;
                    attackedButton.BackColor = Color.Red;
                    attackedButton.Text = "X";
                    enemyScore++;
                    enemyScoreIndex.Text = $"{enemyScore}";
                    ships.handleShiphit(position, false);
                }
                else
                {
                    attackedButton.BackColor = Color.Green;
                    attackedButton.Text = "-";
                }
            }
            if (attackManager.AreAllPlayerShipSunk())
            {

                var timePlayed = elapsedTime.ToString(@"mm\:ss");
                //gameTimer.Stop();
                enemyTurnTimer.Stop();
                playerTimer.Stop();
                gameTimer.Stop();
                var restartOption = MessageBox.Show($"Δυστυχώς έχασες! Ο αντίπαλος έχει κερδίσει με συνολικό σκορ {enemyScore} - {playerScore} πόντους" +
                    $"Οι συνολικές σου προσπάθειες ήταν {playerTries} σε συνολικό χρόνο {timePlayed}!",
                    "Θέλεις να ξεκινήσεις νέο παιχνίδι ή να τερματιστεί;",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );

                if(restartOption == DialogResult.Yes)
                {
                    RestartGame();
                    isEnemyTurnInProgress = false;
                    return;
                }
                else
                {
                    Application.Exit();
                }
            }
               isEnemyTurnInProgress = false;
               enemyTurnTimer.Stop();
        }

        private Button GetButtonFromPosition(string position)
        {
            if (string.IsNullOrEmpty(position) || position.Length < 2) return null;

            int row = position[0] - 'A';
            if (!int.TryParse(position.Substring(1), out int col)) return null;

            col -= 1;


            foreach (Control control in playerTableLayoutPanel.Controls)
            {
                if (control is Button button && button.Tag?.ToString() == position)
                {
                    return button;
                }
            }

            return null;
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
        private void RestartGame()
        {
            playerScore = 0;
            enemyScore = 0;
            playerTries = 0;
            enemyTries = 0;
            playerScoreIndex.Text = "0";
            enemyScoreIndex.Text = "0";

            ships = new shipsPlacement(BoardSize);

           
            attackManager = ships.attackManager;

            
            ships.createGrid(); 
            ships.renderGrid(playerTableLayoutPanel, ships.playerGrid, revealShips: true); 
            ships.renderGrid(enemyTableLayoutPanel, ships.enemyGrid, revealShips: false); 

            attackManager.PlayerMoveRequested += PlayerMove;

           
            gameStartTime = DateTime.Now;
            elapsedTime = TimeSpan.Zero;

            if (gameTimer != null)
                gameTimer.Start();

            if (enemyTurnTimer != null)
                enemyTurnTimer.Stop(); 

            if (playerTimer != null)
                playerTimer.Stop(); 

            
            enemyTurnTimer.Stop(); // Για να μην ξεκινήσει πρώτος ο αντιπάλος στο νεο παιχνίδι
        }


        private void NavalBattles_Load(object sender, EventArgs e)
        {
            gameStartTime = DateTime.Now;
            elapsedTime = TimeSpan.Zero;
            gameTimer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            elapsedTime = DateTime.Now - gameStartTime;
            timerLabel.Text = elapsedTime.ToString(@"mm\:ss");
            timerLabel.Location = new Point(this.ClientSize.Width - this.Width, 0);
            timerLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            timerLabel.BackColor = Color.Transparent;
            timerLabel.ForeColor = Color.Orange;
            this.Controls.Add(timerLabel);
        }
    }
}