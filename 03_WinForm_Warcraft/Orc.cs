using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_WinForm_Warcraft
{
    class Orc
    {
        private Orc()
        {
            this.Health = 100;
            this.Damage = 15;
            this.Councilor = false;
        }
        public Orc(uint Id, string Name)
            : this()
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Orc(uint Id, string Name, int Health,
            int Damage, bool Councilor)
            : this(Id, Name)
        {
            this.Health = Health;
            this.Damage = Damage;
            this.Councilor = Councilor;
        }

        public uint Id { get; private set; }
        //Legalább 2 tagból áll
        //A név mentése "név" formátumban történjen
        private string name;
        public string Name
        {
            set
            {
                if (!value.Contains(' '))
                    throw new Exception("Hibás formátum!");
                string[] tagok = value.Split(' ');
                StringBuilder sb = new StringBuilder();
                int t = 0;
                foreach (string tag in tagok)
                {
                    sb.Append(tag[0].ToString().ToUpper());
                    for (int i = 1; i < tag.Length; i++)
                        sb.Append(tag[i].ToString().ToLower());
                    if (t != tagok.Length - 1)
                        sb.Append(' ');
                    t++;
                }
                name = sb.ToString();
            }
            get
            {
                return name;
            }
        }

        //Legfeljebb 100
        //Ha kisebb érték jön, mint 0, akkor is 0-t mentsen el
        public int Health { get; set; }

        public bool Dead
        {
            get
            {
                return this.Health <= 0;
            }
        }
        //[15, 45]
        public int Damage { get; set; }
        //Ha valaki egyszer bekerül ide, az 
        //örökre itt marad

        private bool councilor;
        public bool Councilor
        {
            set
            {
                if (councilor)
                    throw new Exception("Ő már tanácstag, hagyd békén!");

                if (!councilor)
                    councilor = value;
            }
            get
            {
                return councilor;
            }
        }
    }
}
