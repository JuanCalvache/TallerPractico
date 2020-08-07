using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    abstract class Skill
    {
        //Atributos
        protected string name;
        protected float power;
        protected string afinity;

        protected Skill(string i_name, float i_power, string i_afinity)
        {
            name = i_name;
            power = i_power;
            afinity = i_afinity;
        }

        //Propiedades de los Atributos
        public string Name { get => name; }

        public string Afinity { get => afinity; }
        public float Power { get => power;  }
    }
}
