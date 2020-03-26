﻿using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveBrickObserver : ColObserver
    {
        public RemoveBrickObserver()
        {
            this.pBrick = null;
        }
        public RemoveBrickObserver(RemoveBrickObserver b)
        {
            Debug.Assert(b != null);
            this.pBrick = b.pBrick;
        }
        
        public override void Notify()
        {

            this.pBrick = (ShieldBrick)this.pSubject.pObjB;
            Debug.Assert(this.pBrick != null);

            if (pBrick.bMarkForDeath == false)
            {
                pBrick.bMarkForDeath = true;
                //   Delay
                RemoveBrickObserver pObserver = new RemoveBrickObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }
        public override void Execute()
        {
            GameObject pA = (GameObject)this.pBrick;
            GameObject pB = (GameObject)Iterator.GetParent(pA);

            pA.Remove();

            if (privCheckParent(pB) == true)
            {
                GameObject pC = (GameObject)Iterator.GetParent(pB);
                pB.Remove();

                if (privCheckParent(pC) == true)
                {
                    //        pC.Remove();
                }

            }
        }
        private bool privCheckParent(GameObject pObj)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(pObj);
            if (pGameObj == null)
            {
                return true;
            }

            return false;
        }

        // -------------------------------------------
        // data:
        // -------------------------------------------

        private GameObject pBrick;
    }
}

// End of File
