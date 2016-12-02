using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameProject
{
    public class Hero
    {
        protected string name; //Imię bohatera
        protected int health; //Zywotność bohatera

        public int Health { get { return health; } } //pobranie żywotności

        protected int power; //jego power(mana,siła,zręczność) w zależności od klasy
        public int Power { get { return power; } } //pobranie power'u

        protected int tacticPoints; // punkty taktyki

        protected bool isAlly; //czy jest przyjacielem, czy wrogiem
        public bool _isAlly { get { return isAlly; } } // pobranie informacji 
        //o tym czy przyjaciel czy wrog

        protected bool isAI; //true jesli to bot, false jesli gracz
        public bool _isAI { get { return isAI; } } //pobranie informaczy czyBot.

        public void healthChange(bool heal, int change) // zmiana stanu zycia
        {
            if (heal) //czy leczenie
            {
                health += change; // zwiekszenie zycia o wartosc przekazana przez change

                if (health > 100) //sprawdza czy zycia nie przekroczyły 100
                    health = 100;
            }

            else //jesli nie leczenie, to zadanie obrazen
            {
                if (this is Warrior)
                {
                    if (((Warrior)this)._moreArmor)
                    {
                        Console.WriteLine("The Warrior takes half of the damage.");
                        health -= (int)(0.5 * change);
                    }
                    else
                        health -= change;
                }
                else
                    health -= change;//odejmuje od żyć podana jako parametr wartosc

                if (health < 0)//sprawdza czy nie nizsze niz 0
                    health = 0;
            }
        }

        public void showHero()//pokazuje informacje o danym bohaterze
        {
            string Ally; // string sluzaczy do pokazania czy przyjaciel czy nie

            if (isAlly == true)//isAlly true - to przyjaciel Ally = "Ally"
                Ally = "Ally";

            else//isAlly false - to wrog Ally = Enemy
                Ally = "Enemy";

            //Wypisuje informacje o bohaterze:
            Console.WriteLine("------------------------------");
            Console.WriteLine(Ally + " Name: " + name);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Power: " + power);
            Console.WriteLine("Tactic points: " + tacticPoints);
            if (this is Warrior)
                Console.WriteLine("War Shout Buff: " + ((Warrior)this)._moreArmor);
            Console.WriteLine("------------------------------");
        }

        public string Name { get { return name; } }//do zwracania imienia bohatera.
    }
}