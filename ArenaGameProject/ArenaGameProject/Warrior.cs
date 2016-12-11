using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameProject
{
    public class Warrior : Hero
    {
        private bool moreArmor;
        private int countDown;

        public Warrior(string name, bool isAI, bool isAlly)
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
                return Convert.ToInt32(2 * 1.5 * power * tacticPoints);

            return Convert.ToInt32(1.5 * power * tacticPoints * (0.01 * health));
        }

        public int powerHit()
        {
            if (health <= 30 & health > 10)
            {
                health -= 10;
                return Convert.ToInt32(3 * 1.5 * power * tacticPoints);
            }

            if (health <= 10)
                return Convert.ToInt32(1.5 * power * tacticPoints * (0.01 * health));

            health -= 10;
            return Convert.ToInt32(3 * power * tacticPoints * (0.01 * (health + 10)));
        }

        public void checkWarShout()
        {
            if (moreArmor && countDown == 0)
                moreArmor = false;
            countDown--;
        }

        public void warShout()
        {
            countDown = 3;
            moreArmor = true;
        }

        public int _countDown { get { return countDown; } }
        public bool _moreArmor { get { return moreArmor; } }
    }
}
