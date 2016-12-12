using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameProject
{
    public class Archer : Hero
    {
        public Archer(string name, bool isAI, bool isAlly)//konstruktor
        {
            this.name = name;
            health = 100;
            power = 15;
            tacticPoints = 3;
            this.isAI = !isAI;
            this.isAlly = isAlly;
        }

        public int shoot()//zwykly atak
        {
            Random rnd = new Random();
            int CritChance = rnd.Next(0, 101);
            if(CritChance % 20 == 0)//5% szans na krtyczne trafienie, które podwaja obrazenia
                return 2 * Convert.ToInt32(0.5 * power * tacticPoints * (0.01 * health));
            return Convert.ToInt32(0.5 * power * tacticPoints * (0.01 * health));
        }

        public int doubleShot()//podwojny atak
        {
            Random rnd = new Random();
            int chance = rnd.Next(0, 101);
            int CritChance = rnd.Next(0, 101);
            if (chance % 10 != 0)//10% szans ze sie nie uda podwojny strzal
            {
                if(CritChance % 20 == 0)//jak sie uda i dodatkowo 5% szans na krytyczne uderzenie
                    return 4 * Convert.ToInt32(0.5 * power * tacticPoints * (0.01 * health));//4* obrazenia
                return 2 * Convert.ToInt32(0.5 * power * tacticPoints * (0.01 * health));//jesli nie ma krytycznego 2* obrazenia
            }
            if(CritChance % 20 == 0)//jak sie nie uda podwojny atak
                return 2 * Convert.ToInt32(0.2 * power * tacticPoints * (0.01 * health));//obrazenia sa slabsze niz normalnie,
            return Convert.ToInt32(0.2 * power * tacticPoints * (0.01 * health));//ale wyszej z krytycznym uderzeniem 2*obrazenia
        }
    }
}
