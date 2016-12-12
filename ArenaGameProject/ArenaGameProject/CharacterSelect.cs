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
        private List<Hero> AllyTeam;//Listy druzyn
        private List<Hero> EnemyTeam;

        private static bool whichTeam;//boolean który definiuje dla ktorej druzyny wybieramy
        private static int teamSize;//maksymalny rozmiar druzyny
        private static int currentTeamSize;//obecny rozmiar druzyny
        

        public CharacterSelect(int size)//konstruktor w ktorym przekazujemy rozmiar druzyn
        {
            AllyTeam = new List<Hero>();
            EnemyTeam = new List<Hero>();
            teamSize = size;
            currentTeamSize = 0;
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();//wychodzi z wyboru bohatera
        }

        private void Warrior_MouseEnter(object sender, EventArgs e)//przy najechaniu myszka pokazuje sie obrazek
        {
            warrior_box2.Visible = true;
        }

        private void Warrior_MouseLeave(object sender, EventArgs e)//przy zjechaniu myszki
        {
            if (Warrior.Enabled == true)
                warrior_box2.Visible = false;//jesli nie jest zanaczony to znika obrazek
            else
                warrior_box2.Visible = true;//jesli jest zaznaczony to zostaje obrazek
        }

        private void Mage_MouseEnter(object sender, EventArgs e)//przy najechaniu myszka pokazuje sie obrazek
        {
            mage_box2.Visible = true;
        }

        private void Mage_MouseLeave(object sender, EventArgs e)//przy zjechaniu myszki
        {
            if (Mage.Enabled == true)
                mage_box2.Visible = false;//jesli nie jest zanaczony to znika obrazek
            else
                mage_box2.Visible = true;//jesli jest zaznaczony to zostaje obrazek
        }

        private void Archer_MouseEnter(object sender, EventArgs e)//przy najechaniu myszka pokazuje sie obrazek
        {
            archer_box2.Visible = true;
        }

        private void Archer_MouseLeave(object sender, EventArgs e)//przy zjechaniu myszki
        {
            if (Archer.Enabled == true)
                archer_box2.Visible = false;//jesli nie jest zanaczony to znika obrazek
            else
                archer_box2.Visible = true;//jesli jest zaznaczony to zostaje obrazek
        }

        private void Priest_MouseEnter(object sender, EventArgs e)//przy najechaniu myszka pokazuje sie obrazek
        {
            priest_box2.Visible = true;
        }

        private void Priest_MouseLeave(object sender, EventArgs e)//przy zjechaniu myszki
        {
            if (Priest.Enabled == true)
                priest_box2.Visible = false;//jesli nie jest zanaczony to znika obrazek
            else
                priest_box2.Visible = true;//jesli jest zaznaczony to zostaje obrazek
        }

        private void CharacterSelect_Load(object sender, EventArgs e)//przy wczytaniu Form'a
        {
            checkState();
        }

        private void Warrior_Click(object sender, EventArgs e)//kliekniecie na ikonke postaci
        {
            if (ch_name.Text != "" && ch_name.Text != "Name")//jesli nazwa zostala zmieniona
            {
                this.UseWaitCursor = true;//wlacza kursor wczytywania
                if (whichTeam)
                    AllyTeam.Add(new Warrior(ch_name.Text, AI.Checked, true));//dodaje do listy nowy obiekt
                else
                    EnemyTeam.Add(new Warrior(ch_name.Text, AI.Checked, false));//do odpowiedniej druzny w zaleznosci od whichTeam
                Warrior.Enabled = false;//wylacza przycisk 
                currentTeamSize++;//zwieksza obecny rozmiar druzyny
                checkState();//sprawdza stan
                this.UseWaitCursor = false;//wylacza kursor wczytywania
            }
            else//jesli nie zostala nazwa zmieniona, pokazuje nizej widoczny komunikat
                MessageBox.Show("You have to set a name! And don't forget to choose other options below.");
        }//to samo jest dla pozostalych Mage_Click, Archer_Click i Priest_Click

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

        private void checkState()//sprawdza
        {
            if (currentTeamSize < teamSize)//dla ktorej druzyny wybierasz
            {
                whichTeam = true;
                WhichTeam.Text = "You are chosing for team: 'The Brothers of Vethelot'";
            }
            if (currentTeamSize == teamSize)//resetuje pictureBoxy jest wybralo sie juz wystarczająco postaci
                reset();
            if (currentTeamSize >= teamSize)//dla ktorej druzyny wybierasz
            {
                whichTeam = false;
                WhichTeam.Text = "You are chosing for team: 'The Conquerors Order'";
            }
            if (currentTeamSize == 2 * teamSize)//jesli juz dla obu druzyn zostało wybrane
            {
                Arena fight = new Arena(AllyTeam, EnemyTeam);
                fight.ShowDialog();//wlacza sie arena i zaczyna walka
                this.Close();
            }

            ch_name.Text = "Name";//ustawia nazwe na domyslna "name"
        }

        private void reset()//resetuje picturyBoxy
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

        private void random_name_Click(object sender, EventArgs e)//ustawia losowa nazwa dla postaci
        {
            string[] names = { "Solhar", "Traanun", "Vepteurun", "Fleeran", "Perduhr", "Leyrah", "Pauldon", "Carwald", "Soncuth"};
            Random rnd = new Random();
            ch_name.Text = names[rnd.Next(0, 9)];
        }
    }
}
