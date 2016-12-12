using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace ArenaGameProject
{
    public partial class Arena : Form
    {
        private List<RadioButton> Radio_Skills;//umiejetnosci
        private List<Hero> AllyTeam;//przyjazna druzyna
        private List<Hero> EnemyTeam;//druzyna wrogow
        private Hero current;//obecnie wybierajacy bohater
        private int currentAlly;//indeks obecnie wybierajcego przyjaciela
        private int currentEnemy;//indeks obecnie wybierajacego wroga
        private bool whichTeam;//boolean któy mówi nam która drużyna teraz gra
        private int DMG;//zadawanie obrazenia
        private bool skill_checked;//czy zaznaczony jest skill(RadioButton)
        private bool damage_added_correctly;//czy obrazenia zostaly zadane
        SoundPlayer arenaSound;


        public Arena(List<Hero> AllyTeam, List<Hero> EnemyTeam)//konstruktor
        {
            this.AllyTeam = AllyTeam;//przypisujemy listy
            this.EnemyTeam = EnemyTeam;

            currentAlly = 0;//obecnie wybrani bohaterowie
            currentEnemy = 0;
            whichTeam = true;//true - przyjazna druzyna;false - wroga druzyna
            Radio_Skills = new List<RadioButton>();
            skill_checked = false;//zaznaczony skill false
            damage_added_correctly = false;

            

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();//wychodzimy z gry
        }

        private void skill_CheckedChange(object sender, EventArgs e)//gdy zostanie zmieniony radiobutton(skill)
        {//to w zależności od klasy wybieramy metodę
            if (current is Warrior)
                warrior_attack((Warrior)current, false);//do czego jest false zostanie wyjasnione przy metodzie
            if (current is Mage)
                mage_attack((Mage)current, false);
            if (current is Archer)
                archer_attack((Archer)current);
            if (current is Priest)
                priest_attack((Priest)current, false);
            skill_checked = true;//radiobutton(skill) zostal zaznaczony
        }

        private void Arena_Load(object sender, EventArgs e)//przy wczytaniu Form'a
        {
            string path = Directory.GetCurrentDirectory() + "\\Resources\\Sounds\\Arena.wav";
            arenaSound = new SoundPlayer(@path);
            arenaSound.Play();

            Radio_Skills.Add(radioButton1);
            Radio_Skills.Add(radioButton2);
            Radio_Skills.Add(radioButton3);//dodajemy radioButton'y do listy

            current = AllyTeam[0];// zaczyna pierszy wybrany bohater druzyny przyjaciol

            skill_check();//sprawdzamy umiejetnosci postaci

            set();//ustawiamy zycia i imiona
            set_marker();//ustawiamy znacznik
        }
        private void skill_check()//w zaleznosci od klasy, po kolei kazda umiejętność jest ustawiana
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
                radioButton3.Text = "None";//jesli ktos danej umiejetnosci nie posiada jest nazwana ona None
                radioButton3.Enabled = false;//oraz wylaczona
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
            if (current is Warrior)//czwarty przycik jest zwykłym buttonem
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
        private void warrior_attack(Warrior hero, bool fourthSkill)//atakuje Warrior
        {
            hero.checkWarShout();//sprawdza umiejetnosc moreArmor
            if (fourthSkill)//jesli czwarty skill: to jest booleam z paramteru który mówi nam czy został uzyty
                hero.warShout();//czwarty skill, jesli nie został to sprawdza radiobutton'y
            else if (radioButton1.Checked)
                DMG = hero.swordHit();
            else if (radioButton2.Checked)
                DMG = hero.powerHit();
        }
        private void mage_attack(Mage hero, bool fourthSkill)//tak samo tutaj oraz w przypadku priest_attack i archer_attack
        {
            if (fourthSkill)
                hero.regenerate();
            else if (radioButton1.Checked)
                DMG = hero.lightningBolt();
            else if (radioButton2.Checked)
                DMG = hero.fireBall();
            else if (radioButton3.Checked)
            {
                DMG = hero.Blizzard();//z tą różnicą, że tutaj Blizzard zadaje obrazenia wszystkim wrogom
                if(whichTeam)//jesli jest kolej przyjaciol
                {
                    for(int i = 0; i < EnemyTeam.Count; i++)
                    {
                        EnemyTeam[i].healthChange(DMG);//wrogowie otrzymuja obrazenia
                    }
                }
                else//jesli nie
                {
                    for (int i = 0; i < AllyTeam.Count; i++)
                    {
                        AllyTeam[i].healthChange(DMG);//to przyjaciele otrzymuja
                    }
                }
                //nizej jest zestaw metod które zostaną lepiej wyjaśnione niżej
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

        private void set_marker()//ustawia marker który pokazuje nam która postać ma swoją turę
        {
            if(current is Warrior)//najpierw sprawdza kalse
            {
                if (whichTeam)// a potem która druzyna
                    AllyTurn1.Visible = true;//aktywuje odpowieni znacznik
                else
                    EnemyTurn1.Visible = true;//aktywuje odpowieni znacznik
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

        private void set()//ustawia paski, zyc, many i nazwy bohaterow
        {
            foreach(var hero in AllyTeam)//dla kazdego z druzyny przyjaciol
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

            foreach (var hero in EnemyTeam)//i dla kazdego z druzyny wrogow
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
        }//jesli w której druzynie nie ma np Archera, to wówczas jego nazwa zostaje None a po kliknieciu na pictureBoxa nic sięnie dzieje
        //oraz omijana jest jego kolejka
        private void PictureBox_Click(object sender, EventArgs e)//przy kliknieciu na postać która chce się atakowac/leczyc
        {
            if (skill_checked)//sprawdza czy jakiś skill jest wybrany
            {
                for (int i = 0; i < AllyTeam.Count; i++)
                {
                    if (AllyTeam[i] is Warrior && sender.Equals(Ally_Warrior) && AllyTeam[i] != current)//sprawdza po kolei
                    {//czy dana postac z for'a jest Warriorem i czy przeslany object jest pictureBox'em Warriora i czy nie atakuje sie samą postać
                        AllyTeam[i].healthChange(DMG);
                        damage_added_correctly = true;//zaznacza, ze obrazenia zostaly zadane poprawnie
                    }
                    else if (AllyTeam[i] is Mage && sender.Equals(Ally_Mage) && AllyTeam[i] != current)//tak samo jak w poprzenim
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
                    {//tutaj dodatkowo sprawdza czy chodzi o leczenie, jesli tak to moze uzyc tego na sobie
                        AllyTeam[i].healthChange(DMG);
                        damage_added_correctly = true;
                    }
                }

                for (int i = 0; i < EnemyTeam.Count; i++)//tak samo sprawdza dla druzyny wrogów
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
                if(damage_added_correctly)//jesli udalo sie zadac obrazenia, nie udalo by się gdyby
                {//np dany pictureBox nie "istniał" czyli nie został wybrany Archer, ale kliknięto na PictureBox Archer'a 
                    uncheck_buttons_and_markers();//odznacza radiobuttony oraz znacznik, który pokazuje czyja się tura
                    damage_added_correctly = false;//zmienia poprawnie zadano obrazenia na false
                    set();//ustawia pasi zyc i many
                    check_dead();// sprawdza czy ktos nie umarł i zaraz czy nie koniec gry
                    if (ArenaGameProject.Menu.AllyWin | ArenaGameProject.Menu.EnemyWin)//to zostanie wyjasnione nizej
                        Close();//zamyka sie Form
                    else
                    {
                        next_turn();//przechodzi do nastepnej tury
                        skill_check();//sprawdza skille i pokazje je na ekranie dla kolejnej postaci
                        set_marker();//ustawia znacznik na kolejnej psotaci
                    }
                }
            }
            
        }
        private void uncheck_buttons_and_markers()//odznaczanie
        {
            for(int i = 0; i < Radio_Skills.Count; i++)
            {
                Radio_Skills[i].Checked = false;//kazdy radiobutton jest deaktywowany
            }
            skill_checked = false;//zaznacza ze skill nie jest zaznaczony

            AllyTurn1.Visible = false;//odznacza znaczniki dla kazdej postaci
            AllyTurn2.Visible = false;
            AllyTurn3.Visible = false;
            AllyTurn4.Visible = false;

            EnemyTurn1.Visible = false;
            EnemyTurn2.Visible = false;
            EnemyTurn3.Visible = false;
            EnemyTurn4.Visible = false;
        }
        private void next_turn()//nastepna tura
        {
            if (whichTeam)//jesli kolej przyjaciol
            {
                currentAlly++;//zwiekszamy indeks obecnego przyjaciela
                if (currentAlly > AllyTeam.Count - 1)// jesli indeks doszedl do konca listy
                    currentAlly = 0;//ustawiamy na zero
                whichTeam = false;//zmieniamy druzyne na wrogow
            }
            else//jesli nie kolej przyjaciol
            {
                currentEnemy++;//zwiekszamy indeks obecnego wroga
                if (currentEnemy > EnemyTeam.Count - 1)//jesli indeks doszedl do konca lsity
                    currentEnemy = 0;//ustawiamy na zero
                whichTeam = true;//zmieniamy druzyne na przyajciół
            }
            if (ArenaGameProject.Menu.EnemyWin || ArenaGameProject.Menu.AllyWin)
                Close();//kolejny raz to, poniewaz byl problem gdy Mage zabijał blizzardem
            else
            {
                if (whichTeam)//w zaleznosci od obecnie grająćej druzyny
                    current = AllyTeam[currentAlly];//jest ustawiany obecny bohater
                else
                    current = EnemyTeam[currentEnemy];
            }
            if (current._isAI)//jesli obecny bohater jest komputere
                bot_Attack();//komputer atakuje
        }

        private void bot_Attack()//atak komputera
        {
            if(whichTeam)//jesli druzyna przyajciol
            {
                if(AllyTeam[currentAlly] is Warrior)//jesli warrior
                {
                    AI_Attack.Attack((Warrior)current, EnemyTeam);//metoda losujaca/wybierajaca
                    if(AI_Attack.Buff)//jesli nie byl to atak
                    {
                        Warrior tmp = (Warrior)AllyTeam[currentAlly];//tutaj tak troche
                        tmp.warShout();//byle jak, uzywanie skilla,
                        AllyTeam[currentAlly] = tmp;//oraz nowe przypisywanie do obecnie grajacej psotaci
                        MessageBox.Show(current._Name + " used War Shout.");//wiadomosc pokazujaca co sie stalo
                    }
                    else//jesli to byl atack
                    {
                        EnemyTeam[AI_Attack.Enemy].healthChange(AI_Attack.DMG);//odejmuje wybranemu wrogowi obliczone obrazenia
                        MessageBox.Show(current._Name + " hit " + EnemyTeam[AI_Attack.Enemy]._Name + " for " + AI_Attack.DMG + " damage.");
                    }//wiadomosc pokazujaca co sie stalo
                }
                if (AllyTeam[currentAlly] is Mage)//reszta na tej samej zasadzie
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
                        else//z tym wyjatkiem, ze jesli indeks wroga jest -1 to jest uzywany blizzard
                        {//na wszystkich wrogow
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
                        {//tak samo jesli indeks jest na -1 to leczy samego sieibe 
                            AllyTeam[currentAlly].healthChange(AI_Attack.DMG);
                            MessageBox.Show(current._Name + " healed himself for "+(-AI_Attack.DMG));
                        }
                        else//jesli nie jest na -1 ale nie jest to rowniez atak to leczy
                        {//przyajciela o wskazanym indeksie
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
            else//tak samo dal druzyny wrogow
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
            uncheck_buttons_and_markers();//i tutaj tak samo, odznaczanie
            damage_added_correctly = false;
            set();//ustawianie paskow zyc i many
            check_dead();//sprawdza czy ktos umarl
            if (ArenaGameProject.Menu.AllyWin | ArenaGameProject.Menu.EnemyWin)//sprawdza czy czy ktos wygrał czy nie
                Close();
            else//poniewaz musi dokonczyc metode zamin zamknie Form'a, dlatego jest tu else
            {
                next_turn();//nastepna tura
                skill_check();//ustawia skille,
                set_marker();//ustawia znacznik
            }
        }

        private void check_dead()//sprawdza czy ktos umarl
        {
            ArenaGameProject.Menu.AllyWin = true;//ustawia wygrane na true
            ArenaGameProject.Menu.EnemyWin = true;
            for(int i = 0; i < AllyTeam.Count; i++)
            {
                if (AllyTeam[i].Health <= 0)//jesli ktos z przyjaciol ma zycia mniejsze od 1 
                {
                    AllyTeam.Remove(AllyTeam[i]);//to wyrzuca go z listy
                    i--;//i cofa sie o jeden indeks przy sprawdzaniu
                }
                else
                    ArenaGameProject.Menu.EnemyWin = false;//jesli ktos zyje to ustawia, zw wrogowie wygrali na false
            }
            for (int i = 0; i < EnemyTeam.Count; i++)//tak samo dal wrogow
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

        private void button4_Click(object sender, EventArgs e)//czwart skill, czyli nie radiobutton a zwykły
        {
            if (whichTeam)//w zaleznosci od druzyny
            {
                if (AllyTeam[currentAlly] is Warrior)//wlacza odpowiednia metode
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
            uncheck_buttons_and_markers();//w ten sam sposob sprawdza paski i odznacza
            set();//postacie, ponieważ czwarty skill również końcy turę
            next_turn();
            skill_check();
            set_marker();
        }
    }
}
