using System;
using System.Collections.Generic;
using System.Text;

namespace Loppuprojekti
{
    class Equipment
    {
        string name;
        string description;
        bool rare;

        public Equipment(string pName, string pDescription, bool tRare)
        {
            name = pName;
            description = pDescription;
            rare = tRare;
        }

        public Equipment()
        {
            name = "";
            description = "";
            rare = false;
        }

        public string GetStats()
        {
            return name + "\n" + description + "\n" + rare + "\n";
        }

        public bool GetRarity()
        {
            return rare;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string tName)
        {
            name = tName;
        }

        public void SetDescription(string tDescription)
        {
            description = tDescription;
        }

        public void SetRare(bool tRare)
        {
            rare = tRare;
        }
    }
}
