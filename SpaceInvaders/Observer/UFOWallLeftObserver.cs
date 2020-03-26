using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class UFOWallLeftObserver : ColObserver
    {
        public UFOWallLeftObserver()
        {
            this.pUFO = null;
            this.pRandom = new Random();
        }
        public UFOWallLeftObserver(UFOWallLeftObserver b)
        {
            Debug.Assert(b != null);
            this.pUFO = b.pUFO;
            this.pRandom = b.pRandom;
        }
        
        public override void Notify()
        {
            if (this.pSubject.pObjB is WallLeft) // Hacks
            {
                this.pUFO = (UFO)this.pSubject.pObjA;
                Debug.Assert(this.pUFO != null);
                this.pUFO.SetDelta(1.0f);
            }
        }

        public override void Execute()
        {
        }

        // -------------------------------------------
        // data:
        // -------------------------------------------

        private UFO pUFO;
        private Random pRandom; // for bomb spawns
    }
}

// End of File
