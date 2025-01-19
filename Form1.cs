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

namespace battleShips
{
    public partial class NavalBattles : Form
    {
        public static int BoardSize = 10; // Μέγεθος πίνακα 10x10
        public static readonly char[,] PlayerBoard = new char[BoardSize, BoardSize]; // Πίνακας παίκτη
        static readonly char[,] ComputerBoard = new char[BoardSize, BoardSize]; // Πίνακας υπολογιστή
        static readonly char[,] ComputerHiddenBoard = new char[BoardSize, BoardSize]; // Κρυφός πίνακας υπολογιστή
        static readonly List<Ship> PlayerShips = new List<Ship>();
        static readonly List<Ship> ComputerShips = new List<Ship>();
        static readonly Random random = new Random();
        int PlayerWins = 0;
        int ComputerWins = 0;
        createTables create = new createTables();



        public NavalBattles()
        {

            InitializeComponent();
            bool playAgain = true;
            while (playAgain)
            {
                restartGame(playAgain);
            }

        }

        static void placeShips(char[,] board, List<Ship> ships)
        {
            var shipSizes = new Dictionary<string, int>
            {
                { "Αεροπλανοφόρο", 5 },
                { "Αντιτορπιλικό", 4 },
                { "Πολεμικό", 3},
                { "Υποβρύχιο", 2 }
            };
            foreach (var ships in shipSizes)
            {

            }
            
        }

        private void restartGame(bool playAgain)
        {
            create.initializeTables(BoardSize, PlayerBoard, ComputerBoard,ComputerHiddenBoard);
        }
        class Ship
        {
            public string name { get; set; }
            public int size { get; set; }
            public List<(int row, int col)> coordinates { get; set; }


        public 
      private void createTables(Grid grid)
        {

        }
        private void attackToOpponentEvent(object sender, EventArgs e)
        {

        }

        
        private void restartGame()
        {
            enemyPositions = new List<Button> {Α1,Α2,Α3,Α4,Α5,Α6,Α7,Α8,Α9,Α10,
                                              Β1,Β2,Β3,Β4,Β5,Β6,Β7,Β8,Β9,Β10,
                                              Γ1,Γ2,Γ3,Γ4,Γ5,Γ6,Γ7,Γ8,Γ9,Γ10,
                                              Δ1,Δ2,Δ3,Δ4,Δ5,Δ6,Δ7,Δ8,Δ9,Δ10,
                                              Ε1,Ε2,Ε3,Ε4,Ε5,Ε6,Ε7,Ε8,Ε9,Ε10,
                                              Ζ1,Ζ2,Ζ3,Ζ4,Ζ5,Ζ6,Ζ7,Ζ8,Ζ9,Ζ10,
                                              Η1,Η2,Η3,Η4,Η5,Η6,Η7,Η8,Η9,Η10,
                                              Θ1,Θ2,Θ3,Θ4,Θ5,Θ6,Θ7,Θ8,Θ9,Θ10,
                                              Ι1,Ι2,Ι3,Ι4,Ι5,Ι6,Ι7,Ι8,Ι9,Ι10,
                                              Κ1,Κ2,Κ3,Κ4,Κ5,Κ6,Κ7,Κ8,Κ9,Κ10};
            enemyLocations.Items.Clear();
            enemyLocations.Text = null;
            for(int i =0; i<enemyPositions.Count; i++)
            {
                enemyPositions[i].Enabled = true;
                enemyPositions[i].Tag = null;
                enemyPositions[i].BackColor = Color.Gray;
                enemyLocations.Items.Add(enemyPositions[i].Text);
            }
        }
        
        private void enemyShipsPlacement()
        {
            for(int i=0; i < 4; i++)
            {
                int field = random.Next(enemyPositions.Count);
                if(enemyPositions[field].Enabled == true && (string)enemyPositions[field].Tag == null)
                {
                    enemyPositions[field].Tag = "strikeShip";
                    Debug.WriteLine("Enemy Position "  + enemyPositions[field].Text);
                }
                else
                {
                    field = random.Next(enemyPositions.Count);
                }
            }
        }
    }
}
