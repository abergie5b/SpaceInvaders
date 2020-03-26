using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveBombObserver : ColObserver
    {
        public RemoveBombObserver()
        {
            this.pBomb = null;
        }
        public RemoveBombObserver(Bomb pBomb)
        {
            this.pBomb = pBomb;
        }
        public RemoveBombObserver(RemoveBombObserver b)
        {
            this.pBomb = b.pBomb;
        }
        public override void Notify()
        {
            this.pBomb = (Bomb)this.pSubject.pObjA;
            Debug.Assert(this.pBomb != null);

            if (pBomb.bMarkForDeath == false)
            {
                pBomb.bMarkForDeath = true;
                //   Delay
                RemoveBombObserver pObserver = new RemoveBombObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }

            if (this.pSubject.pObjB is WallBottom)
            {
                //---------------------------------------------------------------------------------------------------------
                // Explosion
                //---------------------------------------------------------------------------------------------------------
                Explosion explosion = new Explosion(GameObject.Name.Explosion_Ground, GameSprite.Name.Explosion_Ground, this.pBomb.x, this.pBomb.y);
                SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
                explosion.ActivateGameSprite(pSB_Aliens);
                GameObjectMan.Attach(explosion);
                TimerMan.Add(TimeEvent.Name.RemoveExplosion, new RemoveExplosionCommand(explosion), 0.25f);
            }

        }
        public override void Execute()
        {
            // Let the gameObject deal with this... 
            this.pBomb.Remove();
        }

        // --------------------------------------
        // data:
        // --------------------------------------

        private GameObject pBomb;
    }
}

// End of File

