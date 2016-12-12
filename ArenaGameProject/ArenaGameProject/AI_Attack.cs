using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameProject
{
    class AI_Attack
    {
        private static Random rnd = new Random();//obietk klasy random
        public static int Enemy;//indeks postaci do atakowania
        public static int DMG;//obrazenia do zadania
        public static  bool Buff;//czy jest to umiejetnosc czy atak

        public static void Attack(Warrior hero, List<Hero> Enemies)//dla warriora
        {
            Buff = false;//ustawia ze jest to atak
            if (!hero._moreArmor)//jesli nie ma wlaczonego buff'u moreArmor
            {
                hero.warShout();//to go aktywuje
                Buff = true;//zaznacza ze to nie atak
            }
            else//w przeciwnym wypadku
            {
                if (hero.Health > 65)//decyduje kogo chce zaatakowac
                    DMG = hero.powerHit();
                else if (hero.Health > 30)
                    DMG = hero.swordHit();
                else if (hero.Health > 20)
                    DMG = hero.powerHit();
                else
                    DMG = hero.swordHit();
                Enemy = rnd.Next(0, Enemies.Count);//wybiera wroga w sposob losowy
                Buff = false;
            }
        }
        public static void Attack(Archer hero, List<Hero> Enemies)
        {
            Buff = false;
            int choice = rnd.Next(0, 101);
            if (choice % 2 == 0)//losowo wybiera czym atakuje
                DMG = hero.shoot();
            else
                DMG = hero.doubleShot();
            Enemy = rnd.Next(0, Enemies.Count);// i losowo kogo atakuje

        }
        public static void Attack(Mage hero, List<Hero> Enemies)
        {
            Buff = false;
            if(hero.Power<15)//jesli mana mniejsza od 15 to regeneruje
            {
                hero.regenerate();
                Buff = true;
            }
            else//jesli nie atakuje
            {
                if(Enemies.Count > 1)//jak jest wrogow iecej niz 1 
                {
                    DMG = hero.Blizzard();//to atakuje wszystkich
                    Enemy = -1;//ustawia indeks wroga na -1 co oznacza, ze chodzi o wszystkich
                }
                else
                {
                    int choice = rnd.Next(0, 101);
                    if (choice % 2 == 0)//losowo wybiera atack
                        DMG = hero.lightningBolt();
                    else
                        DMG = hero.fireBall();
                    Enemy = 0;//wybiera pierwszego wroga poniewaz jest tylko jeden
                }
                Buff = false;//oznacza ze atakuje
            }
        }
        public static void Attack(Priest hero, List<Hero> Allies,List<Hero> Enemies)
        {
            Buff = false;
            if (hero.Health < 40)//w pierwszej kolejnosci sprawdza czy nie leczyc siebie
            {
                DMG = -hero.heal();
                Buff = true;
                Enemy = -1;
            }
            else//jesli nie to
            {
                DMG = hero.holyBolt();
                Enemy = rnd.Next(0, Enemies.Count);//wybiera losowego wroga
                Buff = false;
                

                for (int i = 0; i < Allies.Count; i++)//potem sprawdza czy nie wylczyc sojusznika
                {
                    if (Allies[i].Health < 40)//jesli trzeba kogos wyleczyc
                    {
                        DMG = -hero.heal();//to ustawia obrazenia na -DMG poniewaz wtedy bedą leczyc
                        Enemy = i;//jako obiekt do "ataku" wybiera danego sojusznika
                        Buff = true;//oznacza, ze to nie atak
                    }
                }
            }
        }
    }
}
