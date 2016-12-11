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
    public partial class CharacterSelect : Form
    {
        private List<Hero> AllyTeam;
        private List<Hero> EnemyTeam;

        private static bool whichTeam;
        private static int teamSize;
        private static int currentTeamSize;
        private static bool[] isTaken;

        public CharacterSelect(int size)
        {
            AllyTeam = new List<Hero>();
            EnemyTeam = new List<Hero>();
            teamSize = size;
            currentTeamSize = 0;
            isTaken = new bool[4];
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Warrior_MouseEnter(object sender, EventArgs e)
        {
            warrior_box2.Visible = true;
        }

        private void Warrior_MouseLeave(object sender, EventArgs e)
        {
            if (Warrior.Enabled == true)
                warrior_box2.Visible = false;
            else
                warrior_box2.Visible = true;
        }

        private void Mage_MouseEnter(object sender, EventArgs e)
        {
            mage_box2.Visible = true;
        }

        private void Mage_MouseLeave(object sender, EventArgs e)
        {
            if (Mage.Enabled == true)
                mage_box2.Visible = false;
            else
                mage_box2.Visible = true;
        }

        private void Archer_MouseEnter(object sender, EventArgs e)
        {
            archer_box2.Visible = true;
        }

        private void Archer_MouseLeave(object sender, EventArgs e)
        {
            if (Archer.Enabled == true)
                archer_box2.Visible = false;
            else
                archer_box2.Visible = true;
        }

        private void Priest_MouseEnter(object sender, EventArgs e)
        {
            priest_box2.Visible = true;
        }

        private void Priest_MouseLeave(object sender, EventArgs e)
        {
            if (Priest.Enabled == true)
                priest_box2.Visible = false;
            else
                priest_box2.Visible = true;
        }

        private void CharacterSelect_Load(object sender, EventArgs e)
        {
            checkState();
        }

        private void Warrior_Click(object sender, EventArgs e)
        {
            if (ch_name.Text != "" && ch_name.Text != "Name")
            {
                this.UseWaitCursor = true;
                if (whichTeam)
                    AllyTeam.Add(new Warrior(ch_name.Text, AI.Checked, true));
                else
                    EnemyTeam.Add(new Warrior(ch_name.Text, AI.Checked, false));
                Warrior.Enabled = false;
                currentTeamSize++;
                checkState();
                this.UseWaitCursor = false;
            }
            else
                MessageBox.Show("You have to set a name! And don't forget to choose other options below.");
        }

        private void Mage_Click(object sender, EventArgs e)
        {
            if (ch_name.Text != "" && ch_name.Text != "Name")
            {
                this.UseWaitCursor = true;
                if (whichTeam)
                    AllyTeam.Add(new Mage(ch_name.Text, AI.Checked, true));
                else
                    EnemyTeam.Add(new Mage(ch_name.Text, AI.Checked, false));
                Mage.Enabled = false;
                currentTeamSize++;
                checkState();
                this.UseWaitCursor = false;
            }
            else
                MessageBox.Show("You have to set a name! And don't forget to choose other options below.");
        }

        private void Archer_Click(object sender, EventArgs e)
        {
            if (ch_name.Text != "" && ch_name.Text != "Name")
            {
                this.UseWaitCursor = true;
                if (whichTeam)
                    AllyTeam.Add(new Archer(ch_name.Text, AI.Checked, true));
                else
                    EnemyTeam.Add(new Archer(ch_name.Text, AI.Checked, false));
                Archer.Enabled = false;
                currentTeamSize++;
                checkState();
                this.UseWaitCursor = false;
            }
            else
                MessageBox.Show("You have to set a name! And don't forget to choose other options below.");
        }

        private void Priest_Click(object sender, EventArgs e)
        {
            if (ch_name.Text != "" && ch_name.Text != "Name")
            {
                this.UseWaitCursor = true;
                if (whichTeam)
                    AllyTeam.Add(new Priest(ch_name.Text, AI.Checked, true));
                else
                    EnemyTeam.Add(new Priest(ch_name.Text, AI.Checked, false));
                Priest.Enabled = false;
                currentTeamSize++;
                checkState();
                this.UseWaitCursor = false;
            }
            else
                MessageBox.Show("You have to set a name! And don't forget to choose other options below.");
        }

        private void checkState()
        {
            if (currentTeamSize < teamSize)
            {
                whichTeam = true;
                WhichTeam.Text = "You are chosing for team: 'The Brothers of Vethelot'";
            }
            if (currentTeamSize == teamSize)
                reset();
            if (currentTeamSize >= teamSize)
            {
                whichTeam = false;
                WhichTeam.Text = "You are chosing for team: 'The Conquerors Order'";
            }
            if (currentTeamSize == 2 * teamSize)
            {
                Arena fight = new Arena(AllyTeam, EnemyTeam);
                fight.ShowDialog();
                this.Close();
            }

            ch_name.Text = "Name";
        }

        private void reset()
        {
            Priest.Enabled = true;
            priest_box2.Visible = false;
            Warrior.Enabled = true;
            warrior_box2.Visible = false;
            Mage.Enabled = true;
            mage_box2.Visible = false;
            Archer.Enabled = true;
            archer_box2.Visible = false;
        }

        private void random_name_Click(object sender, EventArgs e)
        {
            string[] names = { "Solhar", "Traanun", "Vepteurun", "Fleeran", "Perduhr", "Leyrah", "Pauldon", "Carwald", "Soncuth"};
            Random rnd = new Random();
            ch_name.Text = names[rnd.Next(0, 9)];
        }
    }
}
