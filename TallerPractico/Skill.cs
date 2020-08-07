using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class Skill
    {
        const int skillLimit = 3;

        //Atributos
        private EType type;
        private ESubtype subtype;
        private float affinityMultiplier;
        private int skillCount;
        protected string name;
        protected float power;
        protected string afinity;       

        //Enumeradores
        public enum EType
        {
            AttackSkill,
            SupportSkill
        }

        public enum ESubtype
        {
            SpdDwn,
            DefUp,
            AtkUp,
            None
        }

        //Constructor
        public Skill(EType i_type, ESubtype i_subtype, string i_name, float i_power, string i_afinity)
        {
            type = i_type;
            subtype = i_subtype;
            name = i_name;
            afinity = i_afinity;
            skillCount = 0;

            if (i_type.Equals(EType.AttackSkill))
            {
                if (i_power >= 1 && i_power <= 10)
                {
                    power = i_power;
                }

                subtype = ESubtype.None;
            }
            else if (i_type.Equals(EType.SupportSkill))
            {
                power = 0;
                subtype = i_subtype;
            }
        }

        //Propiedades de los Atributos
        public string Name { get => name; }
        public string Afinity { get => afinity; }
        public float Power { get => power;  }
        public EType Type { get => type; }
        public ESubtype Subtype { get => subtype; }
        public int SkillCount { get => skillCount; set => skillCount = value; }


        //Sobrecargar para Calcular:

        //Al realizar un ataque calcula el daño.
        public float Calculate(Critter critter, float baseAttack)
        {
            float DamageValue = 0;

            if (type.Equals(EType.AttackSkill))
            {
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
                else 
                {
                    affinityMultiplier = 1.0f;
                }

                DamageValue = (baseAttack + Power) * affinityMultiplier;
            }
            return DamageValue;
        }

        //Al reducir la velocidad del enemigo, calcula el porcentaje
        public float Calculate(Critter critter)
        {
            float debuff = 0;

            if(type.Equals(EType.SupportSkill) && subtype.Equals(ESubtype.SpdDwn))
            {
                debuff = 0.3f;
                skillCount += 1;
            }

            return debuff;
        }

        //Al aumentar el ataque o la defensa, cacula el porcentaje.
        public float Calculate()
        {
            float bonus = 0;

            if(type.Equals(EType.SupportSkill) && (subtype.Equals(ESubtype.AtkUp) || subtype.Equals(ESubtype.DefUp)))
            {
                bonus = 0.2f;
                skillCount += 1;
            }

            return bonus;
        }
    }
}
