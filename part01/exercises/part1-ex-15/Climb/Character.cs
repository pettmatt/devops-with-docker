using System;
using System.Collections.Generic;
using System.Text;

namespace Loppuprojekti
{
    class Character
    {
        public string name;
        public string race;
        public int health;
        public int damage;
        public int maxHealth;

        public Character(string pName, string pRace, int pHealth, int pDamage)
        {
            name = pName;
            race = pRace;
            health = pHealth;
            damage = pDamage;
            maxHealth = pHealth;
        }

        public Character()
        {
            name = "";
            race = "";
            health = 0;
            damage = 0;
            maxHealth = 0;
        }

        public int LoseHealth(int hitpoints)
        {
            return health -= hitpoints;
        }

        public void SetDamage(int dmg)
        {
            damage = dmg;
        }

        public int SetDamage()
        {
            return damage;
        }

    }
}
