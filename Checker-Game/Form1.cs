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

            board[0, 6] = 'R'; // p1_1
            board[1, 7] = 'R'; // p1_2
            board[2, 6] = 'R';
            board[3, 7] = 'R';
            board[4, 6] = 'R';
            board[5, 7] = 'R';
            board[6, 6] = 'R';
            board[7, 7] = 'R';


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
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            Console.WriteLine(startupPath);

        }

        private void p1_1_Click(object sender, EventArgs e)
        {
            p1_1.Left += 90;
            p1_1.Top -= 90;
        }

        private void p1_3_Click(object sender, EventArgs e)
        {
            int p1_3X = p1_3.Left;
            int p1_3Y = p1_3.Top;
            var moveLeft = new PictureBox
            {
                Name = "moveLeft",
                Size = new Size(92, 92),
                Location = new Point(p1_3X - 88, p1_3Y - 88),
                Image = Image.FromFile("./../../../selected.png"),
                Cursor = Cursors.Hand
            };
            
            var moveRight = new PictureBox
            {
                Name = "moveRight",
                Size = new Size(92, 92),
                Location = new Point(p1_3X + 92, p1_3Y - 88),
                Image = Image.FromFile("./../../../selected.png"),
                Cursor = Cursors.Hand
            };
            moveLeft.Click += (sender2, e2) => moveLeft_Click(sender, e, moveLeft, moveRight);
            moveRight.Click += (sender2, e2) => moveRight_Click(sender, e, moveLeft, moveRight);

            CheckerBoard.Controls.Add(moveLeft);
            CheckerBoard.Controls.Add(moveRight);
        }

        private void moveLeft_Click(object sender, EventArgs e, PictureBox moveLeft, PictureBox moveRight)
        {
            p1_3.Left -= 90;
            p1_3.Top -= 90;
            CheckerBoard.Controls.Remove(moveLeft);
            CheckerBoard.Controls.Remove(moveRight);
        }
        private void moveRight_Click(object sender, EventArgs e, PictureBox moveLeft, PictureBox moveRight)
        {
            p1_3.Left += 90;
            p1_3.Top -= 90;
            CheckerBoard.Controls.Remove(moveLeft);
            CheckerBoard.Controls.Remove(moveRight);
            
        }
    }
}
