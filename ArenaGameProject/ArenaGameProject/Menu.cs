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
            CharacterSelect ch = new CharacterSelect();
            this.Hide();
            ch.ShowDialog();
            this.Show();
        }
    }
}
