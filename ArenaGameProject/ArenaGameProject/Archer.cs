using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameProject
{
    public class Archer : Hero
    {
        public Archer(string name, bool isAI, bool isAlly)
        {
            this.name = name;
            health = 100;
            power = 15;
            tacticPoints = 3;
            this.isAI = !isAI;
            this.isAlly = isAlly;
        }

        public int shoot()
        {
            Random rnd = new Random();
            int CritChance = rnd.Next(0, 101);
            if(CritChance % 20 == 0)
                return 2 * Convert.ToInt32(0.5 * power * tacticPoints * (0.01 * health));
            return Convert.ToInt32(0.5 * power * tacticPoints * (0.01 * health));
        }

        public int doubleShot()
        {
            Random rnd = new Random();
            int chance = rnd.Next(0, 101);
            int CritChance = rnd.Next(0, 101);
            if (chance % 10 != 0)
            {
                if(CritChance % 20 == 0)
                    return 4 * Convert.ToInt32(0.5 * power * tacticPoints * (0.01 * health));
                return 2 * Convert.ToInt32(0.5 * power * tacticPoints * (0.01 * health));
            }
            if(CritChance % 20 == 0)
                return 2 * Convert.ToInt32(0.2 * power * tacticPoints * (0.01 * health));
            return Convert.ToInt32(0.2 * power * tacticPoints * (0.01 * health));
        }
    }
}
