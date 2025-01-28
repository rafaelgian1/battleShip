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
        private shipsPlacement ships;
        private selectAttackAreas attackManager;
        
    

        public NavalBattles()
        {

            InitializeComponent();
            ships = new shipsPlacement(BoardSize);
            attackManager = ships.attackManager;
        }
        

        private void NavalBattles_Load(object sender, EventArgs e)
        {
            ships.createGrid();
            ships.renderGrid(playerTableLayoutPanel, ships.playerGrid, revealShips:true);
            ships.renderGrid(enemyTableLayoutPanel, ships.enemyGrid, revealShips:false);
            
            //Εχθρικός πίνακας αρχικά κενός,πρωτα επιλεγει
            // ο χρήστης 5 τοποθεσίες που θα επιτεθεί και μετά
            // γίνονται ωρατές οι τοποθεσίες που βρίσκονται τα πλόια. 
        }

        private void attackToOpponent_Click(object sender, EventArgs e)
        {
            attackManager.AttackEnemy(enemyTableLayoutPanel);
            if (attackManager.AreAllShipsSunk())
            {
                MessageBox.Show("Συγχαρητήρια έχετε πετύχει όλα τα πλόια του αντιπάλου!");
            }
        }
    }
}

