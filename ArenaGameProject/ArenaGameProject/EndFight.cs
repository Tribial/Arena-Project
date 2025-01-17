﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArenaGameProject
{
    public partial class EndFight : Form
    {
        bool Win;
        public EndFight(bool Win)
        {
            this.Win = Win;
            InitializeComponent();
        }

        private void EndFight_Load(object sender, EventArgs e)//ustawia odpowiedni obraz do wygranej lub przegranej
        {
            if (Win)
                AllyWon.Visible = true;
            else
                EnemyWon.Visible = true;
        }

        private void Won_Click(object sender, EventArgs e)//po kliknieciu zamyka Form'a
        {
            Close();
        }

        private void EndFight_Shown(object sender, EventArgs e)//po pokazaniu obrazu
        {
            if (Win)//wyswietla odpowiedni komunikat
                MessageBox.Show("The dark forces have been defeated. This fight wasn't easy, you can be proud.");
            else
                MessageBox.Show("The dark forces have won this battle. But the war is still not over!");
        }

    }
}
