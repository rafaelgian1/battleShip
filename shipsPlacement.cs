using System;
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

        private Dictionary<string, shipInformation> ships;
        private Random random;

        public shipsPlacement(int gridSize)
        {
            playerGrid = new string[gridSize, gridSize];
            enemyGrid = new string[gridSize, gridSize];
            attackManager = new selectAttackAreas(enemyGrid, playerGrid);

            random = new Random();
            ships = new Dictionary<string, shipInformation>
            {
                { "Αεροπλανοφόρο", new shipInformation { shipLength = 5, shipImage = Properties.Resources.aircraftcarrier } },
                { "Αντιτορπιλικό", new shipInformation { shipLength = 4, shipImage = Properties.Resources.destroyer } },
                { "Πολεμικό", new shipInformation { shipLength = 3, shipImage = Properties.Resources.battleship } },
                { "Υποβρύχιο", new shipInformation { shipLength = 2, shipImage = Properties.Resources.submarine } }
            };
        }

        public class shipInformation
        {
            public int shipLength { get; set; }
            public Image shipImage { get; set; }
        }

        public void createGrid()
        {
            foreach (var ship in ships)
            {
                placeShipRandomly(playerGrid, ship.Key, ship.Value.shipLength);
                placeShipRandomly(enemyGrid, ship.Key, ship.Value.shipLength);
            }
        }

        private void placeShipRandomly(string[,] grid, string shipName, int shipSize)
        {
            bool placed = false;

            while (!placed)
            {
                int row = random.Next(gridSize);
                int col = random.Next(gridSize);
                bool horizontal = random.Next(2) == 0;

                if (canPlaceShip(grid, row, col, shipSize, horizontal))
                {
                    placeShip(grid, row, col, shipSize, horizontal, shipName);
                    placed = true;
                }
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

        private void placeShip(string[,] grid, int row, int col, int shipSize, bool horizontal, string shipName)
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

        public void renderGrid(TableLayoutPanel tableLayout, string[,] grid, bool revealShips = false)
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
                    button.Click += (sender, e) => { attackManager.selectAttackPosition(button); };

                    tableLayout.Controls.Add(button, col, row);
                }
            }
        }
    }
}


//    }
//}
//public class shipInformation
//{
//    public int shipLength { get; set; }
//    public Image shipImage { get; set; }
//}

//public void createGrid()
//{
//    foreach (var ship in ships)
//    {
//        placeShipRandomly(playerGrid, ship.Key, ship.Value.shipLength);
//        placeShipRandomly(enemyGrid, ship.Key, ship.Value.shipLength);
//    }
//}

//private void placeShipRandomly(string[,] grid, string shipName, int shipSize)
//{
//    bool placed = false;

//    while (!placed)
//    {
//        int row = random.Next(gridSize);
//        int col = random.Next(gridSize);
//        bool horizontal = random.Next(2) == 0;

//        if (canPlaceShip(grid, row, col, shipSize, horizontal))
//        {
//            placeShip(grid, row, col, shipSize, horizontal, shipName);
//            placed = true;
//        }
//    }
//}

//private bool canPlaceShip(string[,] grid, int row, int col, int shipSize, bool horizontal)
//{
//    if (horizontal)
//    {
//        if (col + shipSize > gridSize) return false;
//        for (int i = 0; i < shipSize; i++)
//        {
//            if (!string.IsNullOrEmpty(grid[row, col + i])) return false;
//        }
//    }
//    else
//    {
//        if (row + shipSize > gridSize) return false;
//        for (int i = 0; i < shipSize; i++)
//        {
//            if (!string.IsNullOrEmpty(grid[row + i, col])) return false;
//        }
//    }
//    return true;
//}

//private void placeShip(string[,] grid, int row, int col, int shipSize, bool horizontal, string shipName)
//{
//    for (int i = 0; i < shipSize; i++)
//    {
//        if (horizontal)
//        {
//            grid[row, col + i] = shipName;
//        }
//        else
//        {
//            grid[row + i, col] = shipName;
//        }
//    }
//}

//public void renderGrid(TableLayoutPanel tableLayout, string[,] grid, bool revealShips = false)
//{
//    tableLayout.Controls.Clear();
//    tableLayout.RowCount = gridSize;
//    tableLayout.ColumnCount = gridSize;

//    for (int row = 0; row < gridSize; row++)
//    {
//        for (int col = 0; col < gridSize; col++)
//        {
//            Button button = new Button
//            {
//                Dock = DockStyle.Fill,
//                BackColor = Color.LightGray,
//                Tag = $"{(char)('Α' + row)}{col + 1}",
//                Text = $"{(char)('Α' + row)}{col + 1}",
//                BackgroundImageLayout = ImageLayout.Stretch
//            };

//            if (revealShips && !string.IsNullOrEmpty(grid[row, col]) && ships.ContainsKey(grid[row,col]))
//            {
//                button.BackgroundImage = ships[grid[row, col]].shipImage;
//            }
//            button.Click += (sender, e) => { attackManager.selectAttackPosition(button); };

//            tableLayout.Controls.Add(button, col, row);
//        }
//    }
//}
//public void revealShips(Button clickedButton)
//{
//    attackManager.fire(clickedButton);
//}
//    }
//}


