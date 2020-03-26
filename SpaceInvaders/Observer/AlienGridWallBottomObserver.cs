using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienGridWallBottomObserver : ColObserver
    {
        public AlienGridWallBottomObserver()
        {
            this.pAlienGrid = null;
            this.pRandom = new Random();
        }
        public AlienGridWallBottomObserver(AlienGridWallBottomObserver b)
        {
            Debug.Assert(b != null);
            this.pAlienGrid = b.pAlienGrid;
            this.pRandom = b.pRandom;
        }
        
        public override void Notify()
        {
            this.pAlienGrid = (AlienGrid)this.pSubject.pObjA;
            PlayerMan.WriteHighScores();
            SceneContext.SetState(SceneContext.Scene.Over);
        }

        public override void Execute()
        {
        }
        // -------------------------------------------
        // data:
        // -------------------------------------------
        private AlienGrid pAlienGrid;
        private Random pRandom; // for bomb spawns
    }
}

// End of File
