using System;
using System.Collections.Generic;
using System.Text;

namespace Loppuprojekti
{
    class Armour : Equipment
    {
        public Armour[] armourPool = new Armour[20];
        int armour;

        public Armour(int tArmour, string tName, string tDescription, bool tRare)
        : base(tName, tDescription, tRare)
        {
            armour = tArmour;
        }

        public Armour()
        {
            armour = 0;
        }

        public void SetArmor(int tArmour)
        {
            armour = tArmour;
        }

        public int GetArmour()
        {
            return armour;
        }

        public void GenerateArmours()
        {
            Armour ar;
            Random r = new Random();

            for(int i = 0; i < armourPool.Length; i++)
            {
                ar = new Armour();
                int number = r.Next(101, 500);
                int type = r.Next(1, 4);

                if (type == 1)
                {
                    ar.SetName("Heavy Armor n." +  number);
                    ar.SetDescription("Heavy armour. Can take more hit than averige armor.");
                    ar.SetArmor(r.Next(150, 250));
                }

                else if (type == 2)
                {
                    ar.SetName("Light Armor n." + number);
                    ar.SetDescription("Average armor used by peasants.");
                    ar.SetArmor(r.Next(150, 200));
                }

                else
                {
                    ar.SetName("Void Scale n." + number);
                    ar.SetDescription("Scale forged from void power which makes this scale the toughest thing in the world.");
                    ar.SetArmor(r.Next(200, 300));
                }

                ar.SetRare(false);
                armourPool[i] = ar;
            }
        }
    }
}
