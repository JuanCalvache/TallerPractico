using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class Critter
    {
        //Atributos
        private string name, afinity; //Fire, Wind, Water, Earth, Dark, Light
        private float baseAttack, currentAttack, baseDefense, currentDefense, baseSpeed, currentSpeed, hp, currentHp;
        private List<Skill> moveset;

        //Constructor
        public Critter(string i_name, float i_baseAttack, float i_baseDefense, float i_baseSpeed, float i_hp, string i_afinity, List<Skill> i_skills)
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

            if (i_skills.Count <= 3)
            {
                moveset = i_skills;
            }

            hp = i_hp;
            currentHp = hp;
        }

        //Propiedades de los atributos
        public string Name { get => name; }

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
        public float CurrentHp { get => currentHp; set => currentHp = value; }

        public float HP { get => hp; }
        public string Afinity { get; }
        public float BaseAttack { get => baseAttack; }
        public float BaseDefense { get => baseDefense; }
        public float BaseSpeed { get => baseSpeed; }
        public List<Skill> Moveset { get => moveset; }
    }
}
