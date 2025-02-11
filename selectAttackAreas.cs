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
        public HashSet<string> playerHitPositions = new HashSet<string>();
        private HashSet<string> enemyHitPositions = new HashSet<string>();
        private List<string> playerAvailablePositions;
        private List<string> enemyAvailablePositions;
        public event Action<Button> PlayerMoveRequested;
        private Random random = new Random();

        public selectAttackAreas(string[,] enemyGrid, string[,] playerGrid)
        {

            this.enemyGrid = enemyGrid;
            this.playerGrid = playerGrid;
            playerAvailablePositions = new List<string>();
            enemyAvailablePositions = new List<string>();
            for (int row = 0; row < enemyGrid.GetLength(0); row++)
            {
                for (int col = 0; col < enemyGrid.GetLength(1); col++)
                {
                    playerAvailablePositions.Add($"{(char)('A' + row)}{col + 1}");
                    enemyAvailablePositions.Add($"{(char)('A' + row)}{col + 1}");
                }
            }
        }

        public bool SelectAttackPosition(Button clickedButton)
        {
            string position = clickedButton.Tag.ToString();
            if (enemyHitPositions.Contains(position))
            {
                return false;
            }

            bool hit = IsShipHit(position);

            PlayerMoveRequested?.Invoke(clickedButton);
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
            if (row < 0 || row >= playerGrid.GetLength(0) || col < 0 || col >= playerGrid.GetLength(1))
            {
                return false;
            }
            bool hit = !string.IsNullOrEmpty(playerGrid[row,col]);
            return hit;
        }

        public bool IsEnemyShipHit(string position)
        {
            


            if (string.IsNullOrEmpty(position) || position.Length < 2)
                return false;
            int row = position[0] - 'A'; // Μετατρέπει το γράμμα σε αριθμό
            if (!int.TryParse(position.Substring(1), out int col))
                return false;

            col -= 1;
            if (row < 0 || row >= enemyGrid.GetLength(0) || col < 0 || col >= playerGrid.GetLength(1))
            {
                return false;
            }
            bool hit = !string.IsNullOrEmpty(enemyGrid[row, col]);
            return hit;

        }
           
        public string getPosition()
        {
            return getRandomAttackPosition();
        }
        private string getRandomAttackPosition()
        {
            if (playerAvailablePositions.Count == 0)
            {
                return null;
            }
            int index = random.Next(playerAvailablePositions.Count);
            string position = playerAvailablePositions[index]; //Αρχικοποιεί την τυχαία τοποθεσία σε μια μεταβλητή string
            playerAvailablePositions.Remove(position); //Αφαιρεί από την λίστα με της διαθέσιμες τοποθεσίες την συγκεκριμένη τοποθεσία που επιλέχθηκε τυχαία για την επίθεση του αντιπάλου.
            
            return position;
        }



        public void getEnemyHitPositions(string position)
        {
            enemyHitPositions.Add(position);
            playerAvailablePositions.Remove(position);

        }
        public void getPlayerHitPositions(string position)
        {
            playerHitPositions.Add(position);
            enemyAvailablePositions.Remove(position);
        }


        public bool AreAllPlayerShipSunk()
        {
            return playerHitPositions.Count == 14;//Συνολικά και τα 4 πλοία καταλαμβάνουν 14 τετραγωνάκια.
        }
        public bool AreAllEnemyShipsSunk()
        {
            return enemyHitPositions.Count == 14;
        }
    }
}