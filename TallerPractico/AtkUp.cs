using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class AtkUp : SupportSkill
    {
        //Constructor
        public AtkUp(string i_name, string i_affinity)
        {
            name = i_name;
            affinity = i_affinity;
            skillPower = 0;
        }
    }
}
