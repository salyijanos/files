using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_WinForm_Warcraft
{
    class Horde
    {
        private static uint Id = 1;

        public Horde()
        {
            this.orcs = new List<Orc>();
        }

        private List<Orc> orcs;
        public List<Orc> Orcs
        {
            get
            {
                return new List<Orc>(orcs);
            }
        }

        public void AddOrc(string Name)
        {
            this.orcs.Add(new Orc(Id, Name));
            Id++;
        }
        public void AddOrc(string Name, int Health,
            int Damage, bool Councilor)
        {
            this.orcs.Add(new Orc(Id, Name, Health, Damage,
                Councilor));
            Id++;
        }
    }
}
