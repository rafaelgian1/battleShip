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
        
        
        int PlayerWins = 0;
        int ComputerWins = 0;
        gridTables tables = new gridTables();
        int gridSize = 10;
        shipsPlacement ships = new shipsPlacement();



        public NavalBattles()
        {

            InitializeComponent();
            
            tables.getGrids(playerTableLayoutPanel, enemyTableLayoutPanel, gridSize);
        }
        

        private void NavalBattles_Load(object sender, EventArgs e)
        {
            ships.createGrid();
            ships.renderGrid(playerTableLayoutPanel, ships.playerGrid);
            ships.renderGrid(enemyTableLayoutPanel, ships.enemyGrid); // Εχθρικός πίνακας αρχικά κενός
        }
    }
}

