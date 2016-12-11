using System;
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
    public partial class Menu : Form
    {
        public static bool AllyWin;
        public static bool EnemyWin;

        public Menu()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FirtGame_Click(object sender, EventArgs e)
        {
            CharacterSelect ch = new CharacterSelect(1);
            this.Hide();
            ch.ShowDialog();
            this.Show();
            checkWin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CharacterSelect ch = new CharacterSelect(2);
            this.Hide();
            ch.ShowDialog();
            this.Show();
            checkWin();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CharacterSelect ch = new CharacterSelect(4);
            this.Hide();
            ch.ShowDialog();
            this.Show();
            checkWin();
        }

        private void checkWin()
        {
            if (AllyWin)
            {
                EndFight ef = new EndFight(true);
                ef.Show();
            }
            if(EnemyWin)
            {
                EndFight ef = new EndFight(false);
                ef.Show();
            }
        }
    }
}
