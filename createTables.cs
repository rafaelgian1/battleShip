using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleShips
{
    internal class createTables
    {
        
        public void initializeTables(int size, char[,] playerBoard, char[,] enemyBoard,char[,] hiddenEnemyBoard)
        {
            for(int i = 0; i <size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    playerBoard[i, j] = '~';
                    enemyBoard[i, j] = '~';
                    hiddenEnemyBoard[i, j] = '~';
                }
            }
           // playerShips.Clear();
           //enemyShips.Clear();
        }
     
    }
}
