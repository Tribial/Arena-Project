using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameProject
{
    public class Warrior : Hero
    {
        private bool moreArmor;//czy dodatkowy armor jest właczony, umiejetność która zmiejsza obrazenia
        private int countDown;//odliczanie umiejetnosci moreArmor

        public Warrior(string name, bool isAI, bool isAlly)//konstruktor
        {
            this.name = name;
            health = 100;
            power = 15;
            tacticPoints = 1;
            this.isAI = !isAI;
            this.isAlly = isAlly;
            moreArmor = false;
        }

        public int swordHit()
        {
            if (health <= 30)
                return Convert.ToInt32(2 * 1.5 * power * tacticPoints);//gdy Warrior ma mniej niż 30 zyć zadanie podwójne obrazenia

            return Convert.ToInt32(1.5 * power * tacticPoints * (0.01 * health));
        }

        public int powerHit()
        {
            if (health <= 30 & health > 10)//tutaj sprawdza czy ma mniejsz niz 30 i wiecej niz 10
            {//poniewaz silne uderzenie, odejmuje Warrior'owi 10 żyć
                health -= 10;
                return Convert.ToInt32(3 * 1.5 * power * tacticPoints);
            }

            if (health <= 10)// jesli ma mniej niz 10 to zadaje normalne uderzenie
                return Convert.ToInt32(1.5 * power * tacticPoints * (0.01 * health));

            health -= 10;
            return Convert.ToInt32(3 * power * tacticPoints * (0.01 * (health + 10)));
        }

        public void checkWarShout()//sprawdza czy moreArmor
        {
            if (moreArmor && countDown == 0)
                moreArmor = false;
            countDown--;
        }

        public void warShout()//wlaczenie skilla moreArmor
        {
            countDown = 3;
            moreArmor = true;
        }

        public int _countDown { get { return countDown; } }//do zwracania wartosci countDown i moreArmor
        public bool _moreArmor { get { return moreArmor; } }
    }
}
