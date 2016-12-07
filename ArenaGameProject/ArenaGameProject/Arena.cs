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
        private Hero current;
        private int currentHero;
        private bool whichTeam;
        private int DMG;

        private static int HP;
        private static int Power;

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
            if (whichTeam)
                current = AllyTeam[currentHero];
            else
                current = EnemyTeam[currentHero];

            if (current is Warrior)
                warrior_attack((Warrior)current);
            if (current is Mage)
                mage_attack((Mage)current);
            if (current is Archer)
                archer_attack((Archer)current);
            if (current is Priest)
                priest_attack((Priest)current);
            label1.Text = DMG.ToString();
            AllyTeam[0].Health = AllyTeam[0].Health - DMG;
            label2.Text = AllyTeam[0].Health.ToString();
            progressBar1.Value = AllyTeam[0].Health;
        }

        private void Arena_Load(object sender, EventArgs e)
        {
            Radio_Skills.Add(radioButton1);
            Radio_Skills.Add(radioButton2);
            Radio_Skills.Add(radioButton3);

            progressBar1.Value = AllyTeam[0].Health;
            label2.Text = AllyTeam[0].Health.ToString();
            progressBar7.Value = 77;

            current = AllyTeam[0];
            remeber();

            skill_check();
        }
        private void skill_check()
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
        private void warrior_attack(Warrior hero)
        {
            paste();
            remeber();
            if (radioButton1.Checked)
                DMG = hero.swordHit();
            if (radioButton2.Checked)
                DMG = hero.powerHit();
        }
        private void mage_attack(Mage hero)
        {
            paste();
            remeber();
            if (radioButton1.Checked)
            {
                DMG = hero.lightningBolt();
                pictureBox7.Visible = true;
            }
            if (radioButton2.Checked)
                DMG = hero.fireBall();
            if (radioButton3.Checked)
            {
                DMG = hero.Blizzard();
                //there will be more
            }
        }
        private void archer_attack(Archer hero)
        {
            paste();
            remeber();
            if (radioButton1.Checked)
                DMG = hero.shoot();
            if (radioButton2.Checked)
                DMG = hero.doubleShot();
        }
        private void priest_attack(Priest hero)
        {
            paste();
            remeber();
            if (radioButton1.Checked)
                DMG = hero.holyBolt();
            if (radioButton2.Checked)
                DMG = hero.heal();
        }

        private void remeber()
        {
            HP = current.Health;
            Power = current.Power;
        }
        private void paste()
        {
            if(whichTeam)
            {
                AllyTeam[currentHero].Health = HP;
                AllyTeam[currentHero].Power = Power;
            }
            if (!whichTeam)
            {
                EnemyTeam[currentHero].Health = HP;
                EnemyTeam[currentHero].Power = Power;
            }
        }
    }
}
