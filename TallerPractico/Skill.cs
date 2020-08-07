using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class Skill
    {
        //Atributos
        protected string name, affinity;
        protected float skillPower;

        //Propiedades de los Atributos
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Affinity
        {
            get { return affinity; }
            set { affinity = value; }
        }
    }
}
