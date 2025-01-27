using System;
using System.Collections.Generic;
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

        public string[,] playerGrid = new string[gridSize, gridSize]; // Πίνακας παίκτη
        public string[,] enemyGrid = new string[gridSize, gridSize]; // Πίνακας αντιπάλου

        public class shipInformation
        {
            public int shipLength { get; set; }
            public Image shipImage { get; set; }

        }
        private Dictionary<string, shipInformation> ships = new Dictionary<string, shipInformation>
        {
            {"Αεροπλανοφόρο", new shipInformation{shipLength = 5, shipImage=Properties.Resources.aircraftcarrier } },
            {"Αντιτορπιλικό", new shipInformation{shipLength = 4, shipImage=Properties.Resources.destroyer } },
            {"Πολεμικό", new shipInformation{shipLength=3, shipImage=Properties.Resources.battleship } },
            {"Υποβρύχιο", new shipInformation{shipLength=2, shipImage = Properties.Resources.submarine } },
        };
        Random random = new Random();

        public void createGrid()
        {
            foreach (var ship in ships)
            {
                placeShipRandomly(playerGrid, ship.Key, ship.Value.shipLength);
                placeShipRandomly(enemyGrid, ship.Key, ship.Value.shipLength); /*Για να έχουν διαφορετικό ship key όταν καλόυντε οι συναρτήσεις
                επειδή στην περίπτωση που καλείται μέσω της ίδιας μεθόδου τα πλόια τοποθετούνται στις ίδιες τοποθεσίες και στους δύο πίνακες.*/

            }
        }

        private void placeShipRandomly(string[,] tableGrid, string shipName, int shipSize)
        {
            //Random random = new Random();
            bool placed = false;

            while (!placed)
            {
                int row = random.Next(gridSize);
                int column = random.Next(gridSize);
                bool horizontal = random.Next(2) == 0; //οριζόντια είναι ίσο με 0 και κάθετα ίσο με 1 

               
                if (canPlaceShip(tableGrid, row, column, shipSize, horizontal))
                {

                    for (int i = 0; i < shipSize; i++)
                    {
                        if (horizontal)
                        {
                            tableGrid[row, column + i] = shipName;
                        }
                        else
                        {
                            tableGrid[row + i, column] = shipName;
                        }
                    }
                    placed = true;
                }
            }
        }

        private bool canPlaceShip(string[,] grid, int row, int col, int shipSize, bool horizontal)
        {
            if (horizontal)
            {
                if (col + shipSize > gridSize) return false; // Υπέρβαση ορίου
                for (int i = 0; i < shipSize; i++)
                {
                    if (!string.IsNullOrEmpty(grid[row, col + i])) return false; // Ήδη κατειλημμένο
                }
            }
            else
            {
                if (row + shipSize > gridSize) return false; // Υπέρβαση ορίου
                for (int i = 0; i < shipSize; i++)
                {
                    if (!string.IsNullOrEmpty(grid[row + i, col])) return false; // Ήδη κατειλημμένο
                }
            }

            return true;
        }
        
        
        public void renderGrid(TableLayoutPanel tableLayout, string[,] grid)
        {
            tableLayout.Controls.Clear();
            tableLayout.RowCount = gridSize;
            tableLayout.ColumnCount = gridSize;

            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    PictureBox shipImage = new PictureBox
                    {
                        Dock = DockStyle.Fill,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = string.IsNullOrEmpty(grid[row, col]) ? Color.LightGray : Color.LightBlue,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                    };

                    if (!string.IsNullOrEmpty(grid[row, col]))
                    {
                        switch (grid[row, col])
                        {
                            case "Αεροπλανοφόρο":
                                shipImage.Image = Properties.Resources.aircraftcarrier;
                                break;
                            case "Αντιτορπιλικό":
                                shipImage.Image = Properties.Resources.destroyer;
                                break;
                            case "Πολεμικό":
                                shipImage.Image = Properties.Resources.battleship;
                                break;
                            case "Υποβρύχιο":
                                shipImage.Image = Properties.Resources.submarine;
                                break;
                            default:
                                break;
                        }
                    }
                    tableLayout.Controls.Add(shipImage, col, row);
                }
            }
        }


    }
}
