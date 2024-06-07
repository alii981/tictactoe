using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class Form1 : Form
    {
        private Button[] buttons;
        private char currentPlayer = 'X';
        public int c = 0,j=0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Initializare()
        {
            buttons = new Button[9] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            foreach (var button in buttons )
            {
                button.Text = string.Empty;
                button.Click += new EventHandler(Button_Click);
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if(clickedButton.Text==string.Empty)
            {
                clickedButton.Text = currentPlayer.ToString();
                if (WinCheck())
                {
                    MessageBox.Show($"Player {currentPlayer} wins!");
                    ResetGame();
                    j++;
                }
                else if (IsDraw())
                {
                    MessageBox.Show("It's a draw!");
                    ResetGame();
                    return;
                }
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                if (currentPlayer == 'O')
                {
                    Calculator();
                    if (WinCheck())
                    {
                        MessageBox.Show("Player O wins!");
                        ResetGame();
                        c++;
                    }
                    else if (IsDraw())
                    {
                        MessageBox.Show("It's a draw!");
                        ResetGame();
                    }
                    currentPlayer = 'X';
                }
            }
            Scor();
        }
        private void ResetGame()
        {
            foreach (var button in buttons)
            {
                button.Text = string.Empty;
            }
            currentPlayer = 'X';
        }

        private bool IsDraw()
        {
            foreach (var button in buttons)
            {
                if (button.Text == string.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        private void Calculator()
        {
            int nr = 1;
            Random random = new Random();
            do
            {
                nr = random.Next(0, 9);
            } while (!string.IsNullOrEmpty(buttons[nr].Text));
            buttons[nr].Text = currentPlayer.ToString();
        }

        private bool WinCheck()
        {
            int[,] winConditions =
            {
                { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 },
                { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 },
                { 0, 4, 8 }, { 2, 4, 6 }
            };
            for (int i = 0; i < winConditions.GetLength(0); i++)
            {
                if (buttons[winConditions[i, 0]].Text == currentPlayer.ToString() &&
                    buttons[winConditions[i, 1]].Text == currentPlayer.ToString() &&
                    buttons[winConditions[i, 2]].Text == currentPlayer.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        private void Scor()
        {
            label1.Text = "Player score is " + j;
            label2.Text = "Computer score is " + c;
        }

            private void Form1_Load(object sender, EventArgs e)
        {
            Initializare();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
