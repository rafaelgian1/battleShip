using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        private string[,] playerGrid;
        private HashSet<string> hitPositions = new HashSet<string>();
        private List<string> availablePositions;

        private Random random = new Random();



        public selectAttackAreas(string[,] enemyGrid, string[,] playerGrid)
        {
            this.enemyGrid = enemyGrid;
            this.playerGrid = playerGrid;
            availablePositions = new List<string>();
            for (int row = 0; row < enemyGrid.GetLength(0); row++)
            {
                for (int col = 0; col < enemyGrid.GetLength(1); col++)
                {
                    availablePositions.Add($"{(char)('A' + row)}{col + 1}");
                }
            }
        }

        public bool selectAttackPosition(Button clickedButton)
        {
            string position = clickedButton.Tag.ToString();
            if (hitPositions.Contains(position))
            {
                return false;
            }
            hitPositions.Add(position);
            bool hit = IsShipHit(position);

            clickedButton.Enabled = false;
            if (hit)
            {
                clickedButton.BackColor = Color.Red;
                clickedButton.Text = "X";
            }
            else
            {
                clickedButton.BackColor= Color.Green;
                clickedButton.Text = "-";
            }
            Console.WriteLine($"Clicked position: {position}");
            return hit;
        }

        public bool IsShipHit(string position)
        {
            if (string.IsNullOrEmpty(position) || position.Length < 2)
                return false;
            int row = position[0] - 'A'; // Μετατρέπει το γράμμα σε αριθμό
            if (!int.TryParse(position.Substring(1), out int col))
                return false;

            col -= 1;
            if (row < 0 || row >= enemyGrid.GetLength(0) || col < 0 || col >= enemyGrid.GetLength(1)){  
            return false;
        }
            return !string.IsNullOrEmpty(enemyGrid[row, col]);
        }
        public bool AreAllShipsSunk()
        {
            return hitPositions.Count == enemyGrid.Cast<string>().Count(pos => !string.IsNullOrEmpty(pos));//Ελέγχει αν τα συνολικά κτυπήματα πλοίων ισούνται με τον αριθμό των κελιών τα οποία ΔΕΝ είναι κένα στον πίνακα του αντιπάλου
        }
        
        public string getPosition()
        {
            return getRandomAttackPosition();
        }
        private string getRandomAttackPosition()
        {
            if (availablePositions.Count == 0)
            {
                return null;
            }
            int index = random.Next(availablePositions.Count);
            string position = availablePositions[index]; //Αρχικοποιεί την τυχαία τοποθεσία σε μια μεταβλητή string
            availablePositions.RemoveAt(index); //Αφαιρεί από την λίστα με της διαθέσιμες τοποθεσίες την συγκεκριμένη τοποθεσία που επιλέχθηκε τυχαία για την επίθεση του αντιπάλου.
            return position;
        }

        public void AttackPlayer(string position)
        {
            hitPositions.Add(position);//Προσθέτει στο hashset την τοποθεσία που επέλεξε ο αντίπαλος να επιτεθεί στον παίκτη.
        }

        public bool AreAllPlayerShipSunk()
        {
            return hitPositions.Count == playerGrid.Cast<string>().Count(pos => !string.IsNullOrEmpty(pos));//Επιστρέφει αν οι συνολικές τοποθεσίες που βρίσκονται στο hitPosition είναι ίσες με όλες τις μη κενές τοποθεσίες πάνω στον πίνακα του παίκτη με την χρήση point.
        }
    }
}