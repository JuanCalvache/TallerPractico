using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class Critter
    {
        //Atributos
        private string name, afinity; //Fire, Wind, Water, Earth, Dark, Light
        private float baseAttack, currentAttack, baseDefense, currentDefense, baseSpeed, currentSpeed, hp;
        private List<Skill> moveset;

        //Constructor
        public Critter(string i_name, string i_afinity, float i_baseAttack, float i_baseDefense, float i_baseSpeed, float i_hp,
            Skill skill1, Skill skill2, Skill skill3)
        {
            name = i_name;
            afinity = i_afinity;
            if (i_baseAttack >= 10 && i_baseAttack <= 100)
            {
                baseAttack = i_baseAttack;
                currentAttack = baseAttack;
            }

            if (i_baseDefense >= 10 && i_baseDefense <= 100)
            {
                baseDefense = i_baseDefense;
                currentDefense = baseDefense;
            }

            if (i_baseSpeed >= 1 && i_baseSpeed <= 50)
            {
                baseSpeed = i_baseSpeed;
                currentSpeed = baseSpeed; 
            }

            hp = i_hp;
        }

        //Propiedades de los atributos
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Afinity
        {
            get { return afinity; }
            set { afinity = value; }
        }

        public float CurrentAttack
        {
            get { return currentAttack; }
            set { currentAttack = value; }
        }

        public float CurrentDefense
        {
            get { return currentDefense; }
            set { currentDefense = value; }
        }

        public float CurrentSpeed
        {
            get { return currentSpeed; }
            set { currentSpeed = value; }
        }

        public float HP
        {
            get { return hp; }
            set { hp = value; }
        }

    }
}
