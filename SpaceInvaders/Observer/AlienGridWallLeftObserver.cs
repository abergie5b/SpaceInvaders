using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienGridWallLeftObserver : ColObserver
    {
        public AlienGridWallLeftObserver(float delta)
        {
            this.delta = delta;
            this.pAlienGrid = null;
            this.pRandom = new Random();
        }
        public AlienGridWallLeftObserver(AlienGridWallLeftObserver b)
        {
            Debug.Assert(b != null);
            this.pAlienGrid = b.pAlienGrid;
            this.pRandom = b.pRandom;
            this.delta = b.delta;
        }
        
        public override void Notify()
        {
            this.pAlienGrid = (AlienGrid)this.pSubject.pObjA;
            Debug.Assert(this.pAlienGrid != null);
            this.pAlienGrid.SetDelta(this.delta);
            this.pAlienGrid.bCollisionEnabled = !this.pAlienGrid.bCollisionEnabled;
            this.pAlienGrid.MoveGridVertical(-5.0f);
            this.pAlienGrid.bCollisionEnabled = !this.pAlienGrid.bCollisionEnabled;
        }

        public override void Execute()
        {
        }

        // -------------------------------------------
        // data:
        // -------------------------------------------
        private float delta;
        private AlienGrid pAlienGrid;
        private Random pRandom; // for bomb spawns
    }
}

// End of File
