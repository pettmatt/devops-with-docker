using System;
using System.Collections.Generic;
using System.Text;

namespace Loppuprojekti
{
    class Weapon : Equipment
    {
        public Weapon[] weaponPool = new Weapon[20];
        int damage;

        public Weapon(string tName, string tDescription, bool tRare, int tDamage)
        : base(tName, tDescription, tRare)
        {
            damage = tDamage;
        }

        public Weapon()
        {
            damage = 0;
        }

        public int TakeDam(int damageAmount, Enemy target)
        {
            target.health -= damageAmount;
            return target.health;
        }

        public void SetDamage(int tDamage)
        {
            damage = tDamage;
        }

        public int GetDamage()
        {
            return damage;
        }

        public void GenerateWeapons()
        {
            Weapon we;
            Random r = new Random();

            for (int i = 0; i < weaponPool.Length; i++)
            {
                we = new Weapon();
                int number = r.Next(101, 200);
                int type = r.Next(1, 4);

                if (type == 1)
                {
                    we.SetName("Sword n." + number);
                    we.SetDescription("Great weapon to have in sword fights.");
                    we.SetDamage(r.Next(40, 70));
                }

                else if (type == 2)
                {
                    we.SetName("Scythe n." + number);
                    we.SetDescription("Superior weapon for slicing!");
                    we.SetDamage(r.Next(20, 120));
                }

                else
                {
                    we.SetName("Mallet n." + number);
                    we.SetDescription("Useful equipment for smashing things.");
                    we.SetDamage(r.Next(60, 80));
                }

                we.SetRare(false);
                weaponPool[i] = we;
            }
        }
    }
}
