using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class AttackSkill : Skill
    {
        //Constructor
        public AttackSkill(string i_name, string i_affinity, float i_power)
        {
            name = i_name;
            affinity = i_affinity;
            if (i_power >= 1)
            {
                skillPower = i_power;
            }

        }
        //propiedad es de los atributos
        public float SkillPower
        {
            get { return skillPower; }
        }
    }
}
