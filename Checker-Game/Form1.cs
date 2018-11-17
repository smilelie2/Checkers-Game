using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Checker_Game
{
    public partial class Form : System.Windows.Forms.Form
    {
        private char[,] board = new char[8, 8];
        private int[,] position_p1 = new int[8, 2];

        public Form()
        {
            InitializeComponent();
            CheckerBoard.Controls.Add(p1_1);
            CheckerBoard.Controls.Add(p1_2);
            CheckerBoard.Controls.Add(p1_3);
            CheckerBoard.Controls.Add(p1_4);
            CheckerBoard.Controls.Add(p1_5);
            CheckerBoard.Controls.Add(p1_6);
            CheckerBoard.Controls.Add(p1_7);
            CheckerBoard.Controls.Add(p1_8);

            board[0, 6] = 'W'; // p1_1
            board[1, 7] = 'W'; // p1_2
            board[2, 6] = 'W';
            board[3, 7] = 'W';
            board[4, 6] = 'W';
            board[5, 7] = 'W';
            board[6, 6] = 'W';
            board[7, 7] = 'W';

            position_p1[0, 0] = 0; position_p1[0, 1] = 6; // position_p1[ตัวที่ , แกน 0=x 1=y]
            position_p1[1, 0] = 1; position_p1[1, 1] = 7;
            position_p1[2, 0] = 2; position_p1[2, 1] = 6;
            position_p1[3, 0] = 3; position_p1[3, 1] = 7;
            position_p1[4, 0] = 4; position_p1[4, 1] = 6;
            position_p1[5, 0] = 5; position_p1[5, 1] = 7;
            position_p1[6, 0] = 6; position_p1[6, 1] = 6;
            position_p1[7, 0] = 7; position_p1[7, 1] = 7;

            CheckerBoard.Controls.Add(p2_1);
            CheckerBoard.Controls.Add(p2_2);
            CheckerBoard.Controls.Add(p2_3);
            CheckerBoard.Controls.Add(p2_4);
            CheckerBoard.Controls.Add(p2_5);
            CheckerBoard.Controls.Add(p2_6);
            CheckerBoard.Controls.Add(p2_7);
            CheckerBoard.Controls.Add(p2_8);

            board[0, 0] = 'B'; // p2_1
            board[1, 1] = 'B'; // p2_2
            board[2, 0] = 'B';
            board[3, 1] = 'B';
            board[4, 0] = 'B';
            board[5, 1] = 'B';
            board[6, 0] = 'B';
            board[7, 1] = 'B';

        }

        private void p1_1_Click(object sender, EventArgs e)
        {
            CreateMovePlayer1(p1_1, position_p1[0, 0], position_p1[0, 1], 0);
        }
        private void p1_2_Click(object sender, EventArgs e)
        {
            CreateMovePlayer1(p1_2, position_p1[1, 0], position_p1[1, 1], 1);
        }
        private void p1_3_Click(object sender, EventArgs e)
        {
            CreateMovePlayer1(p1_3, position_p1[2, 0], position_p1[2, 1], 2);
        }

        private void p1_4_Click(object sender, EventArgs e)
        {
            CreateMovePlayer1(p1_4, position_p1[3, 0], position_p1[3, 1], 3);
        }

        private void p1_5_Click(object sender, EventArgs e)
        {
            CreateMovePlayer1(p1_5, position_p1[4, 0], position_p1[4, 1], 4);
        }

        private void p1_6_Click(object sender, EventArgs e)
        {
            CreateMovePlayer1(p1_6, position_p1[5, 0], position_p1[5, 1], 5);
        }

        private void p1_7_Click(object sender, EventArgs e)
        {
            CreateMovePlayer1(p1_7, position_p1[6, 0], position_p1[6, 1], 6);
        }

        private void p1_8_Click(object sender, EventArgs e)
        {
            CreateMovePlayer1(p1_8, position_p1[7, 0], position_p1[7, 1], 7);
        }
        private void CreateMovePlayer1(PictureBox p1, int pos_x, int pos_y, int number_mak)
        {
            var moveLeft = new PictureBox
            {
                Name = "moveLeft",
                Size = new Size(92, 92),
                Location = new Point(p1.Left - 88, p1.Top - 88),
                Image = Image.FromFile("./../../../selected.png"),
                Cursor = Cursors.Hand
            };
            var moveRight = new PictureBox
            {
                Name = "moveRight",
                Size = new Size(92, 92),
                Location = new Point(p1.Left + 92, p1.Top - 88),
                Image = Image.FromFile("./../../../selected.png"),
                Cursor = Cursors.Hand
            };

            if (pos_x - 1 >= 0 && pos_y - 1 >= 0 && board[pos_x - 1, pos_y - 1] != 'W')
            {
                CheckerBoard.Controls.Add(moveLeft);
            }
            if (pos_x + 1 <= 7 && pos_y - 1 >= 0 && board[pos_x + 1, pos_y - 1] != 'W')
            {
                CheckerBoard.Controls.Add(moveRight);
            }
            moveLeft.Click += (sender2, e2) => moveLeft_Click(p1, moveLeft, moveRight, pos_x, pos_y, number_mak);
            moveRight.Click += (sender2, e2) => moveRight_Click(p1, moveLeft, moveRight, pos_x, pos_y, number_mak);
        }
        private void moveLeft_Click(PictureBox p1, PictureBox moveLeft, PictureBox moveRight, int pos_x, int pos_y, int number_mak)
        {
            p1.Left -= 90;
            p1.Top -= 90;
            board[pos_x, pos_y] = ' ';
            board[pos_x - 1, pos_y - 1] = 'W';
            position_p1[number_mak, 0] = pos_x - 1;
            position_p1[number_mak, 1] = pos_y - 1;
            CheckerBoard.Controls.Remove(moveLeft);
            CheckerBoard.Controls.Remove(moveRight);
        }
        private void moveRight_Click(PictureBox p1, PictureBox moveLeft, PictureBox moveRight, int pos_x, int pos_y, int number_mak)
        {
            p1.Left += 90;
            p1.Top -= 90;
            board[pos_x, pos_y] = ' ';
            board[pos_x + 1, pos_y - 1] = 'W';
            position_p1[number_mak, 0] = pos_x + 1;
            position_p1[number_mak, 1] = pos_y - 1;
            CheckerBoard.Controls.Remove(moveLeft);
            CheckerBoard.Controls.Remove(moveRight);
        }
    }
}
