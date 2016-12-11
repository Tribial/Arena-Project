using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
namespace ArenaGameProject
{
    public class Mage : Hero
    {
        private int maxPower;

        public Mage(string name, bool isAI, bool isAlly)
        {
            this.name = name;
            power = 25;
            maxPower = power;
            health = 100;
            tacticPoints = 2;
            this.isAI = isAI;
            this.isAlly = isAlly;
        }

        public int fireBall()
        {
            power -= 3;
            return Convert.ToInt32((power + 3) * 0.75 * tacticPoints * 0.9);
        }

        public int Blizzard()
        {
            power -= 5;
            return Convert.ToInt32((power + 5) * 0.6 * tacticPoints * 0.9);
        }

        public int lightningBolt()
        {
            power -= 1;
            return Convert.ToInt32((power + 1) * 0.5 * tacticPoints * 0.9);
        }

        public void regenerate()
        {
            power = maxPower;
        }
    }
}