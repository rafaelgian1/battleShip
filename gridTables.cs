using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleShips
{

    internal class gridTables
    {


        public void getGrids(TableLayoutPanel playerGrid, TableLayoutPanel enemyGrid, int gridSize)
        {
            generatePlayerGrid(playerGrid, gridSize);
            generateEnemyGrid(enemyGrid, gridSize);

        }

        public void generatePlayerGrid(TableLayoutPanel playerGrid, int gridSize)
        {
            playerGrid.Controls.Clear();
            playerGrid.RowCount = gridSize;
            playerGrid.ColumnCount = gridSize;
            playerGrid.RowStyles.Clear();
            playerGrid.ColumnStyles.Clear();

            for (int i = 0; i < gridSize; i++)
            {
                playerGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / gridSize));
                playerGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / gridSize));
            }
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button btn = new Button
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.Gray,
                        Tag = $"{(char)('Α' + row)}{col + 1}"
                    };
                    btn.Click += Button_Click;

                    playerGrid.Controls.Add(btn, col, row);
                }
            }
        }

        public void generateEnemyGrid(TableLayoutPanel enemyGrid, int gridSize)
        {
            enemyGrid.Controls.Clear();
            enemyGrid.RowCount = gridSize;
            enemyGrid.ColumnCount = gridSize;
            enemyGrid.RowStyles.Clear();
            enemyGrid.ColumnStyles.Clear();

            for (int i = 0; i < gridSize; i++)
            {
                enemyGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / gridSize));
                enemyGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / gridSize));
            }
            for (int row = 0; row < gridSize; row++)
            {
                for (int col = 0; col < gridSize; col++)
                {
                    Button btn = new Button
                    {
                        BackColor = Color.Gray,
                        Tag = $"{(char)('Α' + row)}{col + 1}"
                    };
                    btn.Click += enemyGrid_Click;

                    enemyGrid.Controls.Add(btn, col, row);
                }
            }
        }


        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                MessageBox.Show($"You clicked {clickedButton.Tag}");
            }
        }
        private void enemyGrid_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                var attackManager = new selectAttackAreas();  // Create the attack manager here
                bool hit = attackManager.select(clickedButton);

                clickedButton.BackColor = hit ? Color.Red : Color.Black;
                clickedButton.Enabled = false;
            }
        }
    }
}
