using System;
using System.Collections.Generic;
using System.Text;

namespace TallerPractico
{
    class Player
    {
        //Atributos
        private List<Critter> myCritters;
        private List<Critter> deadCritters;

        public Player(List<Critter> i_myCritters)
        {
            myCritters = i_myCritters;
        }

        public List<Critter> MyCritters { get => myCritters; set => myCritters = value; }
        public List<Critter> DeadCritters { get => deadCritters; set => deadCritters = value; }


    }
}
