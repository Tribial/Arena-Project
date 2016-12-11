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
        private int currentAlly;
        private int currentEnemy;
        private bool whichTeam;
        private int DMG;
        private bool skill_checked;
        private bool damage_added_correctly;


        public Arena(List<Hero> AllyTeam, List<Hero> EnemyTeam)
        {
            this.AllyTeam = AllyTeam;
            this.EnemyTeam = EnemyTeam;

            currentAlly = 0;
            currentEnemy = 0;
            whichTeam = true;
            Radio_Skills = new List<RadioButton>();
            skill_checked = false;
            damage_added_correctly = false;

            if (whichTeam)
                current = AllyTeam[currentAlly];
            else
                current = EnemyTeam[currentAlly];

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void skill_CheckedChange(object sender, EventArgs e)
        {
            if (current is Warrior)
                warrior_attack((Warrior)current, false);
            if (current is Mage)
                mage_attack((Mage)current, false);
            if (current is Archer)
                archer_attack((Archer)current);
            if (current is Priest)
                priest_attack((Priest)current, false);
            skill_checked = true;
        }

        private void Arena_Load(object sender, EventArgs e)
        {
            Radio_Skills.Add(radioButton1);
            Radio_Skills.Add(radioButton2);
            Radio_Skills.Add(radioButton3);

            current = AllyTeam[0];

            skill_check();

            set();
            set_marker();
        }
        private void skill_check()
        {
            #region First button
            if (current is Warrior)
            {
                radioButton1.Text = "Sword Hit";
            }
            if (current is Mage)
            {
                radioButton1.Text = "Lightning Bolt";
            }
            if (current is Priest)
            {
                radioButton1.Text = "Holy Bolt";
            }
            if (current is Archer)
            {
                radioButton1.Text = "Piercing Arrow";
            }
            #endregion
            #region Second button
            if (current is Warrior)
            {
                radioButton2.Text = "Powerful Sword Hit";
            }
            if (current is Mage)
            {
                radioButton2.Text = "Fire Ball";
            }
            if (current is Priest)
            {
                radioButton2.Text = "Heal";
            }
            if (current is Archer)
            {
                radioButton2.Text = "Double Arrow Shot";
            }
            #endregion
            #region Third button
            if (current is Warrior)
            {
                radioButton3.Text = "None";
                radioButton3.Enabled = false;
            }
            if (current is Mage)
            {
                radioButton3.Text = "Blizzard";
                radioButton3.Enabled = true;
            }
            if (current is Priest)
            {
                radioButton3.Text = "None";
                radioButton3.Enabled = false;
            }
            if (current is Archer)
            {
                radioButton3.Text = "None";
                radioButton3.Enabled = false;
            }
            #endregion
            #region Fourth button
            if (current is Warrior)
            {
                button4.Text = "Battle Shout";
                button4.Enabled = true;
            }
            if (current is Mage)
            {
                button4.Text = "Regenerate";
                button4.Enabled = true;
            }
            if (current is Priest)
            {
                button4.Text = "Regenerate";
                button4.Enabled = true;
            }
            if (current is Archer)
            {
                button4.Text = "None";
                button4.Enabled = false;
            }
            #endregion
        }
        private void warrior_attack(Warrior hero, bool fourthSkill)
        {
            hero.checkWarShout();
            if (fourthSkill)
                hero.warShout();
            else if (radioButton1.Checked)
                DMG = hero.swordHit();
            else if (radioButton2.Checked)
                DMG = hero.powerHit();
        }
        private void mage_attack(Mage hero, bool fourthSkill)
        {
            if (fourthSkill)
                hero.regenerate();
            else if (radioButton1.Checked)
                DMG = hero.lightningBolt();
            else if (radioButton2.Checked)
                DMG = hero.fireBall();
            else if (radioButton3.Checked)
            {
                DMG = hero.Blizzard();
                if(whichTeam)
                {
                    for(int i = 0; i < EnemyTeam.Count; i++)
                    {
                        EnemyTeam[i].healthChange(DMG);
                    }
                }
                else
                {
                    for (int i = 0; i < AllyTeam.Count; i++)
                    {
                        AllyTeam[i].healthChange(DMG);
                    }
                }
                uncheck_buttons_and_markers();
                damage_added_correctly = false;
                set();
                check_dead();
                if (ArenaGameProject.Menu.AllyWin | ArenaGameProject.Menu.EnemyWin)
                    Close();
                else
                {
                    next_turn();
                    skill_check();
                    set_marker();
                }
            }
        }
        private void archer_attack(Archer hero)
        {
            if (radioButton1.Checked)
                DMG = hero.shoot();
            if (radioButton2.Checked)
                DMG = hero.doubleShot();
        }
        private void priest_attack(Priest hero, bool fourthSkill)
        {
            if (fourthSkill)
                hero.regenerate();
            else if (radioButton1.Checked)
                DMG = hero.holyBolt();
            else if (radioButton2.Checked)
                DMG = -hero.heal();
        }

        private void set_marker()
        {
            if(current is Warrior)
            {
                if (whichTeam)
                    AllyTurn1.Visible = true;
                else
                    EnemyTurn1.Visible = true;
            }
            if (current is Mage)
            {
                if (whichTeam)
                    AllyTurn2.Visible = true;
                else
                    EnemyTurn2.Visible = true;
            }
            if (current is Archer)
            {
                if (whichTeam)
                    AllyTurn3.Visible = true;
                else
                    EnemyTurn3.Visible = true;
            }
            if (current is Priest)
            {
                if (whichTeam)
                    AllyTurn4.Visible = true;
                else
                    EnemyTurn4.Visible = true;
            }
        }

        private void set()
        {
            foreach(var hero in AllyTeam)
            {
                if(hero is Warrior)
                {
                    progressBar1.Value = hero.Health;
                    name1.Text = hero._Name;
                }
                if (hero is Mage)
                {
                    progressBar2.Value = hero.Health;
                    name2.Text = hero._Name;
                    manaBar1.Value = hero.Power;
                }
                if (hero is Archer)
                {
                    progressBar3.Value = hero.Health;
                    name3.Text = hero._Name;
                }
                if (hero is Priest) 
                {
                    progressBar4.Value = hero.Health;
                    name4.Text = hero._Name;
                    manaBar2.Value = hero.Power;
                }
            }

            foreach (var hero in EnemyTeam)
            {
                if (hero is Warrior)
                {
                    progressBar5.Value = hero.Health;
                    name5.Text = hero._Name;
                }
                if (hero is Mage)
                {
                    progressBar6.Value = hero.Health;
                    name6.Text = hero._Name;
                    manaBar3.Value = hero.Power;
                }
                if (hero is Archer)
                {
                    progressBar7.Value = hero.Health;
                    name7.Text = hero._Name;
                }
                if (hero is Priest)
                {
                    progressBar8.Value = hero.Health;
                    name8.Text = hero._Name;
                    manaBar4.Value = hero.Power;
                }
            }
        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            if (skill_checked)
            {
                for (int i = 0; i < AllyTeam.Count; i++)
                {
                    if (AllyTeam[i] is Warrior && sender.Equals(Ally_Warrior) && AllyTeam[i] != current)
                    {
                        AllyTeam[i].healthChange(DMG);
                        damage_added_correctly = true;
                    }
                    else if (AllyTeam[i] is Mage && sender.Equals(Ally_Mage) && AllyTeam[i] != current)
                    {
                        AllyTeam[i].healthChange(DMG);
                        damage_added_correctly = true;
                    }
                    else if (AllyTeam[i] is Archer && sender.Equals(Ally_Archer) && AllyTeam[i] != current)
                    {
                        AllyTeam[i].healthChange(DMG);
                        damage_added_correctly = true;
                    }
                    else if (AllyTeam[i] is Priest && sender.Equals(Ally_Priest) && (AllyTeam[i] != current || radioButton2.Checked))
                    {
                        AllyTeam[i].healthChange(DMG);
                        damage_added_correctly = true;
                    }
                }

                for (int i = 0; i < EnemyTeam.Count; i++)
                {
                    if (EnemyTeam[i] is Warrior && sender.Equals(Enemy_Warrior) && EnemyTeam[i] != current)
                    {
                        EnemyTeam[i].healthChange(DMG);
                        damage_added_correctly = true;
                    }
                    else if (EnemyTeam[i] is Mage && sender.Equals(Enemy_Mage) && EnemyTeam[i] != current)
                    {
                        EnemyTeam[i].healthChange(DMG);
                        damage_added_correctly = true;
                    }
                    else if (EnemyTeam[i] is Archer && sender.Equals(Enemy_Archer) && EnemyTeam[i] != current)
                    {
                        EnemyTeam[i].healthChange(DMG);
                        damage_added_correctly = true;
                    }
                    else if (EnemyTeam[i] is Priest && sender.Equals(Enemy_Priest) && (EnemyTeam[i] != current || radioButton2.Checked))
                    {
                        EnemyTeam[i].healthChange(DMG);
                        damage_added_correctly = true;
                    }
                }
                if(damage_added_correctly)
                {
                    uncheck_buttons_and_markers();
                    damage_added_correctly = false;
                    set();
                    check_dead();
                    if (ArenaGameProject.Menu.AllyWin | ArenaGameProject.Menu.EnemyWin)
                        Close();
                    else
                    {
                        next_turn();
                        skill_check();
                        set_marker();
                    }
                }
            }
            
        }
        private void uncheck_buttons_and_markers()
        {
            for(int i = 0; i < Radio_Skills.Count; i++)
            {
                Radio_Skills[i].Checked = false;
            }
            skill_checked = false;

            AllyTurn1.Visible = false;
            AllyTurn2.Visible = false;
            AllyTurn3.Visible = false;
            AllyTurn4.Visible = false;

            EnemyTurn1.Visible = false;
            EnemyTurn2.Visible = false;
            EnemyTurn3.Visible = false;
            EnemyTurn4.Visible = false;
        }
        private void next_turn()
        {
            if(whichTeam)
            {
                currentAlly++;
                if(currentAlly > AllyTeam.Count - 1)
                    currentAlly = 0;
                whichTeam = false;
            }
            else
            {
                currentEnemy++;
                if (currentEnemy > EnemyTeam.Count - 1)
                    currentEnemy = 0;
                whichTeam = true;
            }
            
            if (whichTeam)
                current = AllyTeam[currentAlly];
            else
                current = EnemyTeam[currentEnemy];
            
            if (current._isAI)
                bot_Attack();
        }

        private void bot_Attack()
        {
            if(whichTeam)
            {
                if(AllyTeam[currentAlly] is Warrior)
                {
                    AI_Attack.Attack((Warrior)current, EnemyTeam);
                    if(AI_Attack.Buff)
                    {
                        Warrior tmp = (Warrior)AllyTeam[currentAlly];
                        tmp.warShout();
                        AllyTeam[currentAlly] = tmp;
                        MessageBox.Show(current._Name + " used War Shout.");
                    }
                    else
                    {
                        EnemyTeam[AI_Attack.Enemy].healthChange(AI_Attack.DMG);
                        MessageBox.Show(current._Name + " hit " + EnemyTeam[AI_Attack.Enemy]._Name + " for " + AI_Attack.DMG + " damage.");
                    }
                }
                if (AllyTeam[currentAlly] is Mage)
                {
                    AI_Attack.Attack((Mage)current, EnemyTeam);
                    if(AI_Attack.Buff)
                    {
                        Mage tmp = (Mage)AllyTeam[currentAlly];
                        tmp.regenerate();
                        AllyTeam[currentAlly] = tmp;
                        MessageBox.Show(AllyTeam[currentAlly]._Name + " regenerated mana.");
                    }
                    else
                    {
                        if(AI_Attack.Enemy != -1)
                        {
                            EnemyTeam[AI_Attack.Enemy].healthChange(AI_Attack.DMG);
                            MessageBox.Show(current._Name + " hit " + EnemyTeam[AI_Attack.Enemy]._Name + " for " + DMG + " damage.");
                        }
                        else
                        {
                            for(int i =0; i<EnemyTeam.Count;i++)
                            {
                                EnemyTeam[i].healthChange(AI_Attack.DMG);
                                MessageBox.Show(current._Name + " used Blizzard and hit every enemy for "+ AI_Attack.DMG+" damage.");
                            }
                        }
                    }
                }
                if (AllyTeam[currentAlly] is Archer)
                {
                    AI_Attack.Attack((Archer)current, EnemyTeam);
                    EnemyTeam[AI_Attack.Enemy].healthChange(AI_Attack.DMG);
                    MessageBox.Show(current._Name + " hit " + EnemyTeam[AI_Attack.Enemy]._Name + " for " + AI_Attack.DMG + " damage.");
                }
                if (AllyTeam[currentAlly] is Priest)
                {
                    AI_Attack.Attack((Priest)current, AllyTeam,EnemyTeam);
                    if(AI_Attack.Buff)
                    {
                        if(AI_Attack.Enemy == -1)
                        {
                            AllyTeam[currentAlly].healthChange(AI_Attack.DMG);
                            MessageBox.Show(current._Name + " healed himself for "+(-AI_Attack.DMG));
                        }
                        else
                        {
                            AllyTeam[AI_Attack.Enemy].healthChange(AI_Attack.DMG);
                            MessageBox.Show(current._Name+" healed "+AllyTeam[AI_Attack.Enemy]._Name+" for "+(-AI_Attack.DMG));
                              
                        }
                    }
                    else
                    {
                        EnemyTeam[AI_Attack.Enemy].healthChange(AI_Attack.DMG);
                        MessageBox.Show(current._Name + " hit " + EnemyTeam[AI_Attack.Enemy]._Name + " for " + DMG + " damage.");
                    }
                }
            }
            else
            {
                if(EnemyTeam[currentAlly] is Warrior)
                {
                    AI_Attack.Attack((Warrior)current, AllyTeam);
                    if(AI_Attack.Buff)
                    {
                        Warrior tmp = (Warrior)EnemyTeam[currentAlly];
                        tmp.warShout();
                        EnemyTeam[currentAlly] = tmp;
                        MessageBox.Show(current._Name + " used War Shout.");
                    }
                    else
                    {
                        AllyTeam[AI_Attack.Enemy].healthChange(AI_Attack.DMG);
                        MessageBox.Show(current._Name+" hit "+AllyTeam[AI_Attack.Enemy]._Name+" for "+AI_Attack.DMG+" damage.");
                    }

                }
                if (EnemyTeam[currentAlly] is Mage)
                {
                    AI_Attack.Attack((Mage)current, AllyTeam);
                    if(AI_Attack.Buff)
                    {
                        Mage tmp = (Mage)EnemyTeam[currentAlly];
                        tmp.regenerate();
                        EnemyTeam[currentAlly] = tmp;
                        MessageBox.Show(EnemyTeam[currentAlly]._Name + " regenerated mana.");
                    }
                    else
                    {
                        if(AI_Attack.Enemy != -1)
                        {
                            AllyTeam[AI_Attack.Enemy].healthChange(AI_Attack.DMG);
                            MessageBox.Show(current._Name + " hit " + AllyTeam[AI_Attack.Enemy]._Name + " for " + DMG + " damage.");
                        }
                        else
                        {
                            for(int i =0; i<AllyTeam.Count;i++)
                            {
                                AllyTeam[i].healthChange(AI_Attack.DMG);
                                MessageBox.Show(current._Name + " used Blizzard and hit every enemy for "+ AI_Attack.DMG+" damage.");
                            }
                        }
                    }
                }
                if (EnemyTeam[currentAlly] is Archer)
                {
                    AI_Attack.Attack((Archer)current, AllyTeam);
                    AllyTeam[AI_Attack.Enemy].healthChange(AI_Attack.DMG);
                    MessageBox.Show(current._Name + " hit " + AllyTeam[AI_Attack.Enemy]._Name + " for " + AI_Attack.DMG + " damage.");
                }
                if (EnemyTeam[currentAlly] is Priest)
                {
                    AI_Attack.Attack((Priest)current, EnemyTeam, AllyTeam);
                    if (AI_Attack.Buff)
                    {
                        if (AI_Attack.Enemy == -1)
                        {
                            EnemyTeam[currentAlly].healthChange(AI_Attack.DMG);
                            MessageBox.Show(current._Name + " healed himself for " + (-AI_Attack.DMG));
                        }
                        else
                        {
                            EnemyTeam[AI_Attack.Enemy].healthChange(AI_Attack.DMG);
                            MessageBox.Show(current._Name + " healed " + EnemyTeam[AI_Attack.Enemy]._Name + " for " + (-AI_Attack.DMG));

                        }
                    }
                    else
                    {
                        AllyTeam[AI_Attack.Enemy].healthChange(AI_Attack.DMG);
                        MessageBox.Show(current._Name + " hit " + AllyTeam[AI_Attack.Enemy]._Name + " for " + DMG + " damage.");
                    }
                }
            }
            uncheck_buttons_and_markers();
            damage_added_correctly = false;
            set();
            check_dead();
            if (ArenaGameProject.Menu.AllyWin | ArenaGameProject.Menu.EnemyWin)
                Close();
            else
            {
                next_turn();
                skill_check();
                set_marker();
            }
        }

        private void check_dead()
        {
            ArenaGameProject.Menu.AllyWin = true;
            ArenaGameProject.Menu.EnemyWin = true;
            for(int i = 0; i < AllyTeam.Count; i++)
            {
                if (AllyTeam[i].Health <= 0)
                {
                    AllyTeam.Remove(AllyTeam[i]);
                    i--;
                }
                else
                    ArenaGameProject.Menu.EnemyWin = false;
            }
            for (int i = 0; i < EnemyTeam.Count; i++)
            {
                if (EnemyTeam[i].Health <= 0)
                {
                    EnemyTeam.Remove(EnemyTeam[i]);
                    i--;
                }
                else
                    ArenaGameProject.Menu.AllyWin = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (whichTeam)
            {
                if (AllyTeam[currentAlly] is Warrior)
                    warrior_attack((Warrior)AllyTeam[currentAlly], true);
                if (AllyTeam[currentAlly] is Mage)
                    mage_attack((Mage)AllyTeam[currentAlly], true);
                if (AllyTeam[currentAlly] is Priest)
                    priest_attack((Priest)AllyTeam[currentAlly], true);
            }
            else
            {
                if (EnemyTeam[currentEnemy] is Warrior)
                    warrior_attack((Warrior)EnemyTeam[currentEnemy], true);
                if (EnemyTeam[currentEnemy] is Mage)
                    mage_attack((Mage)EnemyTeam[currentEnemy], true);
                if (EnemyTeam[currentEnemy] is Priest)
                    priest_attack((Priest)EnemyTeam[currentEnemy], true);
            }
            uncheck_buttons_and_markers();
            set();
            next_turn();
            skill_check();
            set_marker();
        }
    }
}
