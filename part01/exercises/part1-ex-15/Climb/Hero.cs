using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Loppuprojekti
{
    class Hero : Character
    {
        private string weapon;
        private string armour;
        private int armourPoints;
        public string roomName;
        public string[] roomsVisited;
        public int visitedRoomsCount;
        public Inventory inv;

        public Hero(string tName, string tRace, int tHealth, int tDamage, int tArmour)
        : base(tName, tRace, tHealth, tDamage)
        {

        }

        public Hero()
        {
            weapon = "";
            armour = "";
            armourPoints = 0;
            roomName = null;
            visitedRoomsCount = 0;
            inv = new Inventory();
        }

        public void Heal(int heal)
        {
            if (health + heal > maxHealth)
            {
                health = maxHealth;
            }

            else
            {
                health += heal;
            }
        }

        public string[] GetVisitedRooms()
        {
            return roomsVisited;
        }

        public void SetMaxVisitedRooms(int maxAmount)
        {
            roomsVisited = new string[maxAmount];
        }

        public void AddVisitedRoom()
        {
            try
            {
                roomsVisited[roomsVisited.Length] = roomName;
            }

            catch(IndexOutOfRangeException e)
            {
                roomsVisited[0] = roomName;
            }
        }

        public string GetName()
        {
            return name;
        }

        public string GetStats()
        {
            return "Name: " + name + "\n" +
                "Race: " + race + "\n" +
                "Health: " + health + "\n" +
                "Weapon: " + weapon + "\n" +
                "Armour: " + armour + "\n";
        }

        public string GetRoom()
        {
            return roomName;
        }

        public string GetWeapon()
        {
            return weapon;
        }

        public string GetArmour()
        {
            return armour;
        }

        public int GetArmourPoints()
        {
            return armourPoints;
        }

        public void SetName(string tname)
        {
            name = tname;
        }

        public void SetRace(string tRace)
        {
            race = tRace;
        }

        public void SetHealth(int tHealth)
        {
            health = tHealth;
        }

        public void SetMaxHealth(int tMHealth)
        {
            maxHealth = tMHealth;
        }

        public void SetWeapon(string tWeapon)
        {
            weapon = tWeapon;
        }

        public void SetArmour(string tArmour)
        {
            armour = tArmour;
        }

        public void SetArmourPoints(int aPoints)
        {
            armourPoints = aPoints;
        }

        public void SetRoom(string tRoomName)
        {
            roomName = tRoomName;
        }

        internal class Inventory : Program
        {
            public Armour[] aEment = new Armour[3];
            public Weapon[] wEment = new Weapon[3];
            internal Weapon wEquiped;
            internal Armour aEquiped;

            internal Inventory()
            {
                wEquiped = new Weapon();
                aEquiped = new Armour();
            }

            internal void EquipWeapon(Weapon wep, Hero player)
            {
                try
                {
                    if (wEment.Contains(wep))
                    {
                        wEquiped = wep;
                        player.weapon = wEquiped.GetName();
                        player.SetDamage(wEquiped.GetDamage());
                    }
                }

                catch (NullReferenceException e)
                {
                    Console.WriteLine("You can't equip... nothingness!\nYou lost your turn.");
                    Continue();
                    wEquiped = player.inv.wEment[0];
                    player.weapon = wEquiped.GetName();
                    player.SetDamage(wEquiped.GetDamage());
                }
            }

            internal void EquipArmour(Armour ar, Hero player)
            {
                try
                {
                    if (aEment.Contains(ar))
                    {
                        aEquiped = ar;
                        player.armour = aEquiped.GetName();
                        player.SetArmourPoints(aEquiped.GetArmour());
                    }
                }

                catch (NullReferenceException e)
                {
                    Console.WriteLine("You can't equip... nothingness!\nYou lost your turn.\n");
                    Continue();
                    aEquiped = player.inv.aEment[0];
                    player.armour = aEquiped.GetName();
                    player.SetArmourPoints(aEquiped.GetArmour());
                }
            }

            internal void TakeArmour(Armour ar)
            {
                // Put armour in to first empty slot in inventory.
                for (int i = 0; i < aEment.Length; i++)
                {
                    if (aEment[i] == null)
                    {
                        aEment[i] = ar;
                        break;
                    }
                }
            }

            internal void TakeWeapon(Weapon wep)
            {
                // Put weapon in to first empty slot in inventory.
                for (int i = 0; i < wEment.Length; i++)
                {
                    if (wEment[i] == null)
                    {
                        wEment[i] = wep;
                        break;
                    }
                }
            }

            internal string LookAtInventory()
            {
                string inventory = "";
                
                    for(int i = 0; i < wEment.Length; i++)
                    {
                        try
                        {
                            if (wEment[i] == wEquiped)
                            {
                                inventory += " " + (i + 1) + " " + wEment[i].GetName() + " (Equiped)\n";
                            }

                            else
                            {
                                inventory += " " + (i + 1) + " " + wEment[i].GetName() + "\n";
                            }
                        }
                        catch (NullReferenceException e)
                        {
                            inventory += " " + (i + 1) + " Empty" + "\n";
                        }
                    }

                    for (int i = 0; i < aEment.Length; i++)
                    {
                        try
                        {
                            if (aEment[i] == aEquiped)
                            {
                                inventory += " " + (i + 1 + wEment.Length) + " " + aEment[i].GetName() + " (Equiped)\n";
                            }

                            else
                            {
                                inventory += " " + (i + 1 + wEment.Length) + " " + aEment[i].GetName() + "\n";
                            }
                        }
                        catch (NullReferenceException e)
                        {
                            inventory += " " + (i + 1 + wEment.Length) + " Empty" + "\n";
                        }
                    }

                return inventory;
            }
        }
    }
}
