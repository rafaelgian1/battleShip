using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Shapes;
using Button = System.Windows.Forms.Button;
using Control = System.Windows.Forms.Control;

namespace battleShips
{
    public class selectAttackAreas
    {
        private string[,] enemyGrid;
        private HashSet<string> hitPositions = new HashSet<string>();
        private List<string> selectedPositions = new List<string>();

        shipsPlacement placement;


        public selectAttackAreas(string[,] enemyGrid)
        {
            this.enemyGrid = enemyGrid;
        }

        public bool selectAttackPosition(Button clickedButton)
        {
            string position = clickedButton.Tag.ToString();
            if (selectedPositions.Contains(position))
            {
                //MessageBox.Show("Η θέση έχει ήδη επιλεχθεί!");
                hitPositions.Add(position);
                //MessageBox.Show(hitPositions.ToString());
                return false;
            }
            selectedPositions.Add(position);
            return true;
        }

        public void AttackEnemy(TableLayoutPanel enemyGridPanel)
        {
            foreach(Control control in enemyGridPanel.Controls)
            {
                if(control is Button button && !button.Enabled)
                {
                    fire(button);
                }
            }
        }


        public void fire(Button clickedButton)
        {
            string position = clickedButton.Tag.ToString();
          

            if (IsShipHit(position))
            {
                hitPositions.Add(position);
                clickedButton.BackColor = Color.Red; // Κόκκινο για hit
                clickedButton.Text = "X"; // Κόκκινο "Χ" για χτύπημα
            }
            else
            {
                clickedButton.BackColor = Color.Green; // Πράσινο για αποτυχία
                clickedButton.Text = "-"; // Πράσινη παύλα για αποτυχία
            }
            clickedButton.Enabled = false;
        }
        public bool IsShipHit(string position)
        {
            int row = position[0] - 'A'; // Μετατρέπει το γράμμα σε αριθμό
            int col = int.Parse(position.Substring(1)) - 1; // Μετατρέπει τον αριθμό σε στήλη (π.χ. 1 -> 0, 2 -> 1, ...)

            return !string.IsNullOrEmpty(enemyGrid[row, col]);
        }

        public bool AreAllShipsSunk()
        {
            return hitPositions.Count == enemyGrid.Cast<string>().Count(pos => !string.IsNullOrEmpty(pos));//Ελέγχει αν τα συνολικά κτυπήματα πλοίων ισούνται με τον αριθμό των κελιών τα οποία ΔΕΝ είναι κένα στον πίνακα του αντιπάλου
        }
    }
}

