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
        public static bool AllyWin;//pole bool które mówi kto wygrał
        public static bool EnemyWin;

        public Menu()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();//wyjscie z gry
        }

        private void FirtGame_Click(object sender, EventArgs e)//uruchamia grę 1 na 1
        {
            CharacterSelect ch = new CharacterSelect(1);
            this.Hide();
            ch.ShowDialog();
            this.Show();
            checkWin();
        }

        private void button2_Click(object sender, EventArgs e)//uruchamia grę 2 na 2
        {
            CharacterSelect ch = new CharacterSelect(2);
            this.Hide();
            ch.ShowDialog();
            this.Show();
            checkWin();
        }

        private void button3_Click(object sender, EventArgs e)//uruchamia grę 4 na 4
        {
            CharacterSelect ch = new CharacterSelect(4);
            this.Hide();
            ch.ShowDialog();
            this.Show();
            checkWin();
        }

        private void checkWin()//sprawdza kto wygral i wyswietla odpowiedniego Form'a
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
