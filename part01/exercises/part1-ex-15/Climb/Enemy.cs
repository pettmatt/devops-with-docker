using System;
using System.Collections.Generic;
using System.Text;

namespace Loppuprojekti
{
    class Enemy : Character
    {
        public Enemy(string tName, string tRace, int tHealth, int tDamage)
        : base(tName, tRace, tHealth, tDamage) { }

        public Enemy() : base()
        { }

        public string Stats()
        {
            return name + "\n" + race + "\n" + health + "\n" + damage;
        }

        public int GetHealth()
        {
            return health;
        }

        public Enemy Generate()
        {
            Random r = new Random();
            string[] names = new string[] { "Soldier", "Knight", "General", "Peasant", "Worker", "Ghost", "Master" };
            string[] races = new string[] { "Animal", "Skeleton", "Lizzard", "Ghoul", "Demon", "Elf", "Orc", "Fish" };

            name = names[r.Next(0, names.Length)];
            race = races[r.Next(0, races.Length)];

            if (race == races[0]) health = r.Next(50, 100);         // Animal
            else if (race == races[1]) health = r.Next(10, 30);     // Skeleton
            else if (race == races[2]) health = r.Next(60, 120);    // Lizzard
            else if (race == races[3]) health = r.Next(20, 60);     // Ghoul
            else if (race == races[4]) health = r.Next(100, 300);   // Demon
            else if (race == races[5]) health = r.Next(70, 200);    // Elf
            else if (race == races[6]) health = r.Next(150, 200);   // Orc
            else if (race == races[7]) health = r.Next(1, 350);     // Fish

            // Soldier, Knight, General
            if (name == names[0] || name == names[1] || name == names[2])
            {
                damage = r.Next(20, 40);
                health *= 4;

                if (name == names[1])
                {
                    damage *= 2;
                }

                else if (name == names[2])
                {
                    damage *= 4;
                }
            }

            // Peasant, worker
            else if (name == names[3] || name == names[4])
            {
                damage = r.Next(10, 20);

                if (name == names[4])
                {
                    health *= 3;
                }
            }

            // Ghost
            else if (name == names[5])
            {
                health *= 7;
                damage = r.Next(1, 200);
            }

            // Master
            else if (name == names[6])
            {
                health *= 6;
                damage = r.Next(150, 200);
            }

            Enemy newEnemy = new Enemy(name, race, health, damage);
            return newEnemy;
        }

        public string GetName()
        {
            return name + " " + race;
        }

        public int DealDamage(Hero player)
        {
            int modifiedDamage = damage - (player.GetArmourPoints() / 13);
            if (modifiedDamage < 0)
            {
                modifiedDamage = 0;
            }
            return modifiedDamage;
        }
    }
}
