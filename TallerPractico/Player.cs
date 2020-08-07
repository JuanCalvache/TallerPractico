using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class Player
    {
        //Atributos
        private List<Critter> myCritters;
        private List<Critter> stolenCritters;

        public Player(List<Critter> i_myCritters)
        {
            myCritters = i_myCritters;
            stolenCritters = new List<Critter>();
        }

        public List<Critter> MyCritters { get => myCritters; set => myCritters = value; }
        internal List<Critter> StolenCritters { get => stolenCritters; set => stolenCritters = value; }
        
        //Un metodo que permite entregar critters a la lista de Critters Robados
        public void ObtainCritter(Critter myNewCritter)
        {
            stolenCritters.Add(myNewCritter);
        }

        //Un metodo que elimina un critter muerto, y lo devuelve para que el otro Player lo pueda obtener.
        public Critter LoseCritter(Critter i_deadCritter)
        {
            Critter deadCritter = i_deadCritter;

            if (myCritters.Contains(i_deadCritter))
            {
                myCritters.Remove(i_deadCritter); 
            }

            return deadCritter;
        }

        //Ambos metodos LoseCritter, y ObtainCritter, trabajan el uno para el otro.
    }
}
