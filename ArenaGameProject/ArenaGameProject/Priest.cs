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
            tacticPoints = 1;
            health = 100;
            this.isAI = isAI;
            this.isAlly = isAlly;
        }

        public int holyBolt()
        {
            power -= 1;
            return Convert.ToInt32((power) * tacticPoints * (0.01 * health));
        }

        public int heal()
        {
            power -= 1;
            return Convert.ToInt32(0.5 * power * tacticPoints * (0.1 * health));
        }

        public void regenerate()
        {
            power = maxPower;
        }
    }
}
