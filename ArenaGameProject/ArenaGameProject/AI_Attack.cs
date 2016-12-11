using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameProject
{
    class AI_Attack
    {
        private static Random rnd = new Random();
        public static int Enemy;
        public static int DMG;
        public static  bool Buff;

        public static void Attack(Warrior hero, List<Hero> Enemies)
        {
            Buff = false;
            if (!hero._moreArmor)
            {
                hero.warShout();
                Buff = true;
            }
            else
            {
                if (hero.Health > 65)
                    DMG = hero.powerHit();
                else if (hero.Health > 30)
                    DMG = hero.swordHit();
                else if (hero.Health > 20)
                    DMG = hero.powerHit();
                else
                    DMG = hero.swordHit();
                Enemy = rnd.Next(0, Enemies.Count);
                Buff = false;
            }
        }
        public static void Attack(Archer hero, List<Hero> Enemies)
        {
            Buff = false;
            int choice = rnd.Next(0, 101);
            if (choice % 2 == 0)
                DMG = hero.shoot();
            else
                DMG = hero.doubleShot();
            Enemy = rnd.Next(0, Enemies.Count);

        }
        public static void Attack(Mage hero, List<Hero> Enemies)
        {
            Buff = false;
            if(hero.Power<15)
            {
                hero.regenerate();
                Buff = true;
            }
            else
            {
                if(Enemies.Count > 1)
                {
                    DMG = hero.Blizzard();
                    Enemy = -1;
                }
                else
                {
                    int choice = rnd.Next(0, 101);
                    if (choice % 2 == 0)
                        DMG = hero.lightningBolt();
                    else
                        DMG = hero.fireBall();
                }
                Buff = false;
            }
        }
        public static void Attack(Priest hero, List<Hero> Allies,List<Hero> Enemies)
        {
            Buff = false;
            if (hero.Health < 40)
            {
                DMG = -hero.heal();
                Buff = true;
                Enemy = -1;
            }
            else
            {
                DMG = hero.holyBolt();
                Enemy = rnd.Next(0, Enemies.Count);
                Buff = false;
                

                for (int i = 0; i < Allies.Count; i++)
                {
                    if (Allies[i].Health < 40)
                    {
                        DMG = -hero.heal();
                        Enemy = i;
                        Buff = true;
                    }
                }
            }
        }
    }
}
