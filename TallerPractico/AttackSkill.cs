using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class AttackSkill : Skill
    {
        private float affinityMultiplier;
        //Constructor
        public AttackSkill(string i_name, float i_power, string i_afinity) : base(i_name, i_power, i_afinity) 
        {
            if (i_power >= 1 && i_power <= 10)
            {
                power = i_power;
            }

            affinityMultiplier = 0f;
        }

        public float CalculateDamage(Critter critter, float baseAttack)
        {
            float DamageValue;

            if 
                (afinity.Equals(critter.Afinity) || 
                (afinity.Equals("Water") && critter.Afinity.Equals("Fire")) ||
                (afinity.Equals("Wind") && critter.Afinity.Equals("Water")) ||
                (afinity.Equals("Wind") && critter.Afinity.Equals("Earth")))
            {
                affinityMultiplier = 0.5f;
            }
            else if 
                ((afinity.Equals("Dark") && critter.Afinity.Equals("Light")) ||
                (afinity.Equals("Ligth") && critter.Afinity.Equals("Dark")) ||
                (afinity.Equals("Fire") && critter.Afinity.Equals("Water")) ||
                (afinity.Equals("Water") && critter.Afinity.Equals("Wind")) ||
                (afinity.Equals("Earth") && critter.Afinity.Equals("Wind")))
            {
                affinityMultiplier = 2.0f;
            }
            else if 
                (afinity.Equals("Fire") && critter.Afinity.Equals("Earth"))
            {
                affinityMultiplier = 0.0f;
            }
            else if 
                ((afinity.Equals("Dark") && (critter.Equals("Fire") || critter.Equals("Water") || critter.Equals("Wind") || critter.Equals("Earth"))) ||
                (afinity.Equals("Light") && (critter.Equals("Fire") || critter.Equals("Water") || critter.Equals("Wind") || critter.Equals("Earth"))) ||
                (afinity.Equals("Fire") && (critter.Equals("Dark") || critter.Equals("Light") || critter.Equals("Wind"))) ||
                (afinity.Equals("Water") && (critter.Equals("Dark") || critter.Equals("Light") || critter.Equals("Earth"))) ||
                (afinity.Equals("Wind") && (critter.Equals("Fire") || critter.Equals("Dark") || critter.Equals("Light"))) ||
                (afinity.Equals("Earth") && (critter.Equals("Dark") || critter.Equals("Light") || critter.Equals("Fire") || critter.Equals("Water"))))
            {
                affinityMultiplier = 1.0f;
            }
            else
            {
                affinityMultiplier = 0f;
            }

            DamageValue = (baseAttack + Power) * affinityMultiplier;
            return DamageValue;
        }
    }
}
