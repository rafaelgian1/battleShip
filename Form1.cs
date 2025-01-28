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
    
        int gridSize = 10;
        shipsPlacement ships = new shipsPlacement();


        public NavalBattles()
        {

            InitializeComponent();
           
        }
        

        private void NavalBattles_Load(object sender, EventArgs e)
        {
            ships.createGrid();
            ships.renderGrid(playerTableLayoutPanel, ships.playerGrid);
        
            ships.renderGrid(enemyTableLayoutPanel, ships.enemyGrid); //Εχθρικός πίνακας αρχικά κενός,πρωτα επιλεγει
           // ο χρήστης 5 τοποθεσίες που θα επιτεθεί και μετά
           // γίνονται ωρατές οι τοποθεσίες που βρίσκονται τα πλόια. 
        }

        private void attackToOpponent_Click(object sender, EventArgs e)
        {     foreach (Control control in enemyTableLayoutPanel.Controls)
                {
                    if (control is Button button && ships.attackManager.IsShipHit(button.Tag.ToString()))
                    {
                        ships.revealShips(button);
                    }
                }
        }
    }
}

