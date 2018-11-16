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

            board[0, 6] = 'R';
            board[1, 7] = 'R';
            board[2, 6] = 'R';
            board[3, 7] = 'R';
            board[4, 6] = 'R';
            board[5, 7] = 'R';
            board[6, 6] = 'R';
            board[7, 7] = 'R';
        }

        private void p1_1_Click(object sender, EventArgs e)
        {
            p1_1.Left += 90;
            p1_1.Top -= 90;
        }
    }
}
