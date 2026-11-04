using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KolkoKrzyzyk
{
    public partial class Form1 : Form
    {
        Button[,] Przycisk = new Button[3, 3];
        string symbol = "O";
        string startowy = "O";
        int wygraneX = 0;
        int wygraneO = 0;
        int remisy = 0;

        public Form1()
        {
            InitializeComponent();


            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.Przycisk[i, j] = new Button();
                    this.Przycisk[i, j].Location = new System.Drawing.Point(39 + (80 * i), 60 + (50 * j));
                    this.Przycisk[i, j].Name = "Przycisk" + (i * 3 + j).ToString();
                    this.Przycisk[i, j].Size = new System.Drawing.Size(75, 45);
                    this.Przycisk[i, j].TabIndex = 2 + (i * 3 + j);
                    this.Przycisk[i, j].Text = "";
                    this.Przycisk[i, j].UseVisualStyleBackColor = true;

                    this.Przycisk[i, j].Click += new System.EventHandler(this.Przycisk_Click);

                    this.Controls.Add(Przycisk[i, j]);
                }
            }

            label1.Text = "Rozpoczyna gracz " + symbol;
            AktualizujWyniki();
        }


        private bool wygrana(string symbol)
        {

            if (Przycisk[0, 0].Text.Equals(symbol) &&
                Przycisk[0, 1].Text.Equals(symbol) &&
                Przycisk[0, 2].Text.Equals(symbol)) return true;

            if (Przycisk[1, 0].Text.Equals(symbol) &&
                Przycisk[1, 1].Text.Equals(symbol) &&
                Przycisk[1, 2].Text.Equals(symbol)) return true;

            if (Przycisk[2, 0].Text.Equals(symbol) &&
                Przycisk[2, 1].Text.Equals(symbol) &&
                Przycisk[2, 2].Text.Equals(symbol)) return true;


            if (Przycisk[0, 0].Text.Equals(symbol) &&
                Przycisk[1, 0].Text.Equals(symbol) &&
                Przycisk[2, 0].Text.Equals(symbol)) return true;

            if (Przycisk[0, 1].Text.Equals(symbol) &&
                Przycisk[1, 1].Text.Equals(symbol) &&
                Przycisk[2, 1].Text.Equals(symbol)) return true;

            if (Przycisk[0, 2].Text.Equals(symbol) &&
                Przycisk[1, 2].Text.Equals(symbol) &&
                Przycisk[2, 2].Text.Equals(symbol)) return true;

            if (Przycisk[0, 0].Text.Equals(symbol) &&
                Przycisk[1, 1].Text.Equals(symbol) &&
                Przycisk[2, 2].Text.Equals(symbol)) return true;

            if (Przycisk[0, 2].Text.Equals(symbol) &&
                Przycisk[1, 1].Text.Equals(symbol) &&
                Przycisk[2, 0].Text.Equals(symbol)) return true;

            return false;
        }

        private bool PelnaPlansza()
        {
            int licznik = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!Przycisk[i, j].Text.Equals("")) licznik++;

                }
            }
            return (licznik == 9);
        }

        private void ZerujPlansze()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    this.Przycisk[i, j].Text = "";

                    this.Przycisk[i, j].Enabled = true;

                }
            }

            if (startowy.Equals("O"))
            {

                startowy = "X";

            }
            else
            {
                startowy = "O";
            }
            symbol = startowy;
            label1.Text = "Rozpoczyna gracz " + symbol;
        }

        private void AktualizujWyniki()
        {
            labelWyniki.Text = "X: " + wygraneX
                + " | O: " + wygraneO
                + " | Remisy: " + remisy;
        }

        private void buttonKoniec_Click(object sender, EventArgs e)
        {
            DialogResult decyzja = MessageBox.Show(
                "Zamykamy grę?",
                "Zamykanie programu...",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (decyzja == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Przycisk_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text.Equals(""))
            {
                ((Button)sender).Text = symbol;

                if (symbol.Equals("X"))
                {
                    ((Button)sender).ForeColor = Color.Blue;
                }
                else
                {
                    ((Button)sender).ForeColor = Color.Red;
                }
            } else return;
            
            if (wygrana(symbol))
            {
                label1.Text = "Wygral " + symbol;

                if (symbol.Equals("X"))
                {
                    wygraneX++;
                }
                else
                {
                    wygraneO++;
                }

                AktualizujWyniki();

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j <3; j++)
                    {
                        Przycisk[i, j].Enabled = false;
                    }
                }
            }
            else
            {
                if (PelnaPlansza())
                {
                    label1.Text = "Remis";
                    remisy++;
                    AktualizujWyniki();
                    MessageBox.Show("Mamy remis byku.", "Próbuj ponownie");
                    
                }
                else
                {
                    if (symbol.Equals("O")) symbol = "X";
                    else symbol = "O";
                    label1.Text = "Ruch gracza " + symbol;
                }
            }
        }
        
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ZerujPlansze();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonZerujWyniki_Click(object sender, EventArgs e)
        {
            wygraneX = 0;
            wygraneO = 0;
            remisy = 0;
            AktualizujWyniki();
        }
    }
}

