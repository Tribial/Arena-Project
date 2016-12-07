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
    public partial class Arena : Form
    {
        private List<RadioButton> Radio_Skills;
        private List<Hero> AllyTeam;
        private List<Hero> EnemyTeam;
        private int currentHero;
        private bool whichTeam;
        private int DMG;

        public Arena(List<Hero> AllyTeam, List<Hero> EnemyTeam)
        {
            this.AllyTeam = AllyTeam;
            this.EnemyTeam = EnemyTeam;
            currentHero = 0;
            whichTeam = true;
            Radio_Skills = new List<RadioButton>();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {}

        private void skill_CheckedChange(object sender, EventArgs e)
        {
            
        }

        private void Arena_Load(object sender, EventArgs e)
        {
            Radio_Skills.Add(radioButton1);
            Radio_Skills.Add(radioButton2);
            Radio_Skills.Add(radioButton3);
            first_skill();
            second_skill();
            third_skill();
            fourth_skill();
        }
        private void first_skill()
        {
            if (AllyTeam[currentHero] is Warrior)
            {
                radioButton1.Text = "Sword Hit";
            }
            if (AllyTeam[currentHero] is Mage)
            {
                radioButton1.Text = "Lightning Bolt";
            }
            if (AllyTeam[currentHero] is Priest)
            {
                radioButton1.Text = "Holy Bolt";
            }
            if (AllyTeam[currentHero] is Archer)
            {
                radioButton1.Text = "Piercing Arrow";
            }
        }
        private void second_skill()
        {
            if (AllyTeam[currentHero] is Warrior)
            {
                radioButton2.Text = "Powerful Sword Hit";
            }
            if (AllyTeam[currentHero] is Mage)
            {
                radioButton2.Text = "Fire Ball";
            }
            if (AllyTeam[currentHero] is Priest)
            {
                radioButton2.Text = "Heal";
            }
            if (AllyTeam[currentHero] is Archer)
            {
                radioButton2.Text = "Double Arrow Shot";
            }
        }
        private void third_skill()
        {
            if (AllyTeam[currentHero] is Warrior)
            {
                radioButton3.Text = "None";
                radioButton3.Enabled = false;
            }
            if (AllyTeam[currentHero] is Mage)
            {
                radioButton3.Text = "Blizzard";
            }
            if (AllyTeam[currentHero] is Priest)
            {
                radioButton3.Text = "None";
                radioButton3.Enabled = false;
            }
            if (AllyTeam[currentHero] is Archer)
            {
                radioButton3.Text = "None";
                radioButton3.Enabled = false;
            }
        }
        private void fourth_skill()
        {
            if (AllyTeam[currentHero] is Warrior)
            {
                button4.Text = "Battle Shout";
            }
            if (AllyTeam[currentHero] is Mage)
            {
                button4.Text = "Regenerate";
            }
            if (AllyTeam[currentHero] is Priest)
            {
                button4.Text = "Regenerate";
            }
            if (AllyTeam[currentHero] is Archer)
            {
                button4.Text = "None";
                button4.Enabled = false;
            }
        }

    }
}
