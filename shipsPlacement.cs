﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace battleShips
{
    public class shipsPlacement
    {
        private const int gridSize = 10;
        public string[,] playerGrid { get; private set; }
        public string[,] enemyGrid { get; private set; }
        public selectAttackAreas attackManager { get; private set; }
        private Random random;
        public Dictionary<string, shipInformation> ships;
        public string shipName;

        public Dictionary<string, int> playerShipLives;
        public Dictionary<string, int> enemyShipLives;


        public shipsPlacement(int gridSize)
        {
            playerGrid = new string[gridSize, gridSize];
            enemyGrid = new string[gridSize, gridSize];

            attackManager = new selectAttackAreas(enemyGrid, playerGrid);
            random = new Random();

            ships = new Dictionary<string, shipInformation>
            {
                { "Aircraft Carrier", new shipInformation { shipLength = 5, shipImage = Properties.Resources.aircraftcarrier } },
                { "Destroyer", new shipInformation { shipLength = 4, shipImage = Properties.Resources.destroyer } },
                { "Battleship", new shipInformation { shipLength = 3, shipImage = Properties.Resources.battleship } },
                { "Submarine", new shipInformation { shipLength = 2, shipImage = Properties.Resources.submarine } }
            };
            playerShipLives = ships.ToDictionary(ship => ship.Key, ship => ship.Value.shipLength); //Χρησιμοποιώ pointer για να κανει point στην μνήμη το περιεχόμενο του dictionary που περιέχει τα στοιχεία κάθε πλοίου και να χρησιμοποιήσει ουσιαστικά αυτά τα δεδομένα
            enemyShipLives = ships.ToDictionary(ship => ship.Key, ship => ship.Value.shipLength); //Αντίστοιχα και για τα πλοία του αντιπάλου
        }

        public class shipInformation
        {
            public int shipLength { get; set; }
            public Image shipImage { get; set; }
        }
        private void playerPlaceShipRandomly(string[,] grid, string shipName, int shipSize)
        {
            bool placed = false;

            while (!placed)
            {
                int row = random.Next(gridSize);
                int col = random.Next(gridSize);
                bool horizontal = random.Next(2) == 0;
                if (canPlaceShip(grid, row, col, shipSize, horizontal))
                {
                    playerPlaceShip(grid, row, col, shipSize, horizontal, shipName);
                    placed = true;
                    
                    Console.WriteLine($"topothetisi {shipName} ston pinaka sti thesi  ({row}, {col}), orizontia: {horizontal}");
                }
            }
        }
        private void enemyPlaceShipRandomly(string[,] grid, string shipName, int shipSize)
        {
            bool placed = false;

            while (!placed)
            {
                int row = random.Next(gridSize);
                int col = random.Next(gridSize);
                bool horizontal = random.Next(2) == 0;
                if (canPlaceShip(grid, row, col, shipSize, horizontal))
                {
                    enemyPlaceShip(grid, row, col, shipSize, horizontal, shipName);
                    placed = true;
                    // Debugging: Εκτύπωση της θέσης
                    Console.WriteLine($"topothetisi {shipName} ston pinaka sti thesi  ({row}, {col}), orizontia: {horizontal}");
                }
            }
        }

        public void createGrid()
        {
            foreach (var ship in ships)
            {
                playerPlaceShipRandomly(playerGrid, ship.Key, ship.Value.shipLength);
            }
            foreach (var ship in ships)
            {
                enemyPlaceShipRandomly(enemyGrid, ship.Key, ship.Value.shipLength);
            }
            Console.WriteLine("Pinakas antipalou:");
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Console.Write(enemyGrid[row, col] == null ? "-" : "X");
                }
                Console.WriteLine();
            }
        }


        private bool canPlaceShip(string[,] grid, int row, int col, int shipSize, bool horizontal)
        {
            if (horizontal)
            {
                if (col + shipSize > gridSize) return false;
                for (int i = 0; i < shipSize; i++)
                {
                    if (!string.IsNullOrEmpty(grid[row, col + i])) return false;
                }
            }
            else
            {
                if (row + shipSize > gridSize) return false;
                for (int i = 0; i < shipSize; i++)
                {
                    if (!string.IsNullOrEmpty(grid[row + i, col])) return false;
                }
            }
            return true;
        }

        private void playerPlaceShip(string[,] grid, int row, int col, int shipSize, bool horizontal, string shipName)
        {
            for (int i = 0; i < shipSize; i++)
            {
                if (horizontal)
                {
                    grid[row, col + i] = shipName;
                }
                else
                {
                    grid[row + i, col] = shipName;
                }
            }
        }
        private void enemyPlaceShip(string[,] grid, int row, int col, int shipSize, bool horizontal, string shipName)
        {
            for (int i = 0; i < shipSize; i++)
            {
                if (horizontal)
                {
                    grid[row, col + i] = shipName;
                }
                else
                {
                    grid[row + i, col] = shipName;
                }
            }
        }


        public void renderGrid(TableLayoutPanel tableLayout, string[,] grid, bool revealShips)
        {
            tableLayout.Controls.Clear();
            tableLayout.RowCount = gridSize;
            tableLayout.ColumnCount = gridSize;

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button button = new Button
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.LightGray,
                        Tag = $"{(char)('A' + row)}{col + 1}",
                        Text = $"{(char)('Α' + row)}{col + 1}",
                        BackgroundImageLayout = ImageLayout.Stretch
                    };

                    if (revealShips && !string.IsNullOrEmpty(grid[row, col]) && ships.ContainsKey(grid[row, col]))
                    {
                        button.BackgroundImage = ships[grid[row, col]].shipImage;
                    }
                    button.Click += (sender, e) => { attackManager.SelectAttackPosition(button); };

                    tableLayout.Controls.Add(button, col, row);
                }
            }
        }

        public void handleShiphit(string position, bool isPlayerAttack, Label playerShipHitLabel, Label enemyShipHitLabel)
        {
            int row = position[0] - 'A';
            int col = int.Parse(position.Substring(1)) - 1;

            string[,] grid = isPlayerAttack ? enemyGrid : playerGrid;
            Dictionary<string, int> targetShipLives = isPlayerAttack ? enemyShipLives : playerShipLives;

            string hitShipName = grid[row, col];

            if (!string.IsNullOrEmpty(hitShipName) && ships.ContainsKey(hitShipName))
            {
                switch (hitShipName)
                {
                    case "Aircraft Carrier":
                        shipName = "Αεροπλανοφόρο";
                        break;
                    case "Destroyer":
                        shipName = "Αντιτορπιλικό";
                        break;
                    case "Battleship":
                        shipName = "Πολεμικό";
                        break;
                    case "Submarine":
                        shipName = "Υποβρύχιο";
                        break;
                }
                if (targetShipLives.ContainsKey(hitShipName) && isPlayerAttack)
                {
                    targetShipLives[hitShipName]--;
                    if (targetShipLives[hitShipName] > 0)
                    {
                        enemyShipHitLabel.Text = ($"Το {shipName} του αντιπάλου κτυπήθηκε,\n του απομένουν πλεον {targetShipLives[hitShipName]}");
                    }
                }

                else if (targetShipLives.ContainsKey(hitShipName) && !isPlayerAttack)
                {
                    {
                        targetShipLives[hitShipName]--;
                        if (targetShipLives[(hitShipName)] > 0)
                        {
                            playerShipHitLabel.Text = ($"Το {shipName} σου κτυπήθηκε!\n Σου απομένουν πλέον {targetShipLives[hitShipName]}");
                        }
                    }
                }
                    if (targetShipLives[hitShipName] == 0 && isPlayerAttack)
                    {
                        MessageBox.Show($"Το {shipName} του αντιπάλου έχει βυθιστεί!");
                        enemyShipHitLabel.Text = "";
                    }
                    else if (targetShipLives[hitShipName] == 0 && !isPlayerAttack)
                    {
                        MessageBox.Show($"Το {shipName} σου έχει βυθιστεί!");
                        playerShipHitLabel.Text = "";
                    }
                }
            }
        }
    }