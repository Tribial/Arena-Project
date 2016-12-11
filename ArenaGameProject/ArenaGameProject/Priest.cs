using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameProject
{
    public class Priest : Hero
    {
        private int maxPower;

        public Priest(string name, bool isAI, bool isAlly)
        {
            this.name = name;
            power = 25;
            maxPower = power;
            tacticPoints = 2;
            health = 100;
            this.isAI = isAI;
            this.isAlly = isAlly;
        }

        public int holyBolt()
        {
            power -= 1;
            return Convert.ToInt32(0.75 * power * tacticPoints);
        }

        public int heal()
        {
            power -= 1;
            return Convert.ToInt32(1.2 * power * tacticPoints);
        }

        public void regenerate()
        {
            power = maxPower;
        }
    }
}
