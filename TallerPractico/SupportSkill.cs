using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class SupportSkill : Skill
    {
        const int skilLimit = 3;

        private EType type;
        private int skillCount;

        public enum EType
        {
            SpdDwn,
            DefUp,
            AtkUp
        }

        //Propiedades de los Atributos
        public SupportSkill
            (string i_name, string i_afinity, EType i_type) : base(i_name, 0f, i_afinity)
        {
            type = i_type;    
        }

        public EType Type { get => type; }

        public float ActiveSkill()
        {
            float bonus = 0f;
            int atkSkillCount = 0, defSkillCount = 0, spdSkillCount = 0;

            if (type.Equals(EType.AtkUp) && atkSkillCount != skillCount)
            {
                bonus = 0.2f;
                atkSkillCount += 1;
            }
            else if (type.Equals(EType.DefUp) && defSkillCount != skillCount)
            {
                bonus = 0.2f;
                defSkillCount += 1;
            }
            else if (type.Equals(EType.SpdDwn) && spdSkillCount != skillCount)
            {
                bonus = -0.3f;
                spdSkillCount += 1;
            }

            return bonus;
        }
    }
}
