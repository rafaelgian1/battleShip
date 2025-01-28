using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;

namespace battleShips
{
    internal class selectAttackAreas
    {
        private string[,] enemyGrid;
        private HashSet<string> hitPositions = new HashSet<string>();
        private HashSet<string> selectedPositions = new HashSet<string>();

        public selectAttackAreas()
        {
        }

        public selectAttackAreas(string[,] enemyGrid)
        {
            this.enemyGrid = enemyGrid;
        }
        public bool selectAttackPosition(Button clickedButton)
        {
            string position = clickedButton.Tag.ToString();
            if (selectedPositions.Contains(position))
            {
                MessageBox.Show("Ήδη επιλεγμένη θέση για επίθεση");
                return false;
            }
            selectedPositions.Add(position);
            return true;
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
        }
        public bool IsShipHit(string position)
        {
            int row = position[0] - 'A'; // Μετατρέπει το γράμμα σε αριθμό
            int col = int.Parse(position.Substring(1)) - 1; // Μετατρέπει τον αριθμό σε στήλη (π.χ. 1 -> 0, 2 -> 1, ...)

            return !string.IsNullOrEmpty(enemyGrid[row, col]);
        }
    }
}

