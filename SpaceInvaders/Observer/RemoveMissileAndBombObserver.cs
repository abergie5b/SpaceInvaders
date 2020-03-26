using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveMissileAndBombObserver : ColObserver
    {
        public RemoveMissileAndBombObserver()
        {
            this.pBomb = null;
            this.pMissile = null;
        }
        public RemoveMissileAndBombObserver(Bomb pBomb, Missile pMissile)
        {
            this.pBomb = pBomb;
            this.pMissile = pMissile;
        }
        public RemoveMissileAndBombObserver(RemoveMissileAndBombObserver b)
        {
            this.pBomb = b.pBomb;
            this.pMissile = b.pMissile;
        }
        public override void Notify()
        {
            this.pBomb = (Bomb)this.pSubject.pObjA;

            MissileGroup pMissileGroup = (MissileGroup)this.pSubject.pObjB;
            this.pMissile = (Missile)Iterator.GetChild(pMissileGroup);
            Debug.Assert(this.pMissile != null);

            if (this.pBomb.bMarkForDeath == false)
            {
                this.pBomb.bMarkForDeath = true;
            }

            if (this.pMissile.bMarkForDeath == false)
            {
                this.pBomb.bMarkForDeath = true;
            }

            //   Delay
            RemoveMissileAndBombObserver pObserver = new RemoveMissileAndBombObserver((Bomb)this.pBomb, (Missile)this.pMissile);
            DelayedObjectMan.Attach(pObserver);

            //---------------------------------------------------------------------------------------------------------
            // Sound
            //---------------------------------------------------------------------------------------------------------
            SoundMan.PlaySound(Sound.Name.InvaderKilled);
            TimeEvent pTimeEvent = TimerMan.Find(TimeEvent.Name.ScenePlaySound);

            //---------------------------------------------------------------------------------------------------------
            // Explosion
            //---------------------------------------------------------------------------------------------------------
            Explosion explosion = new Explosion(GameObject.Name.Explosion, GameSprite.Name.Explosion, this.pBomb.x, this.pBomb.y);
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            explosion.ActivateGameSprite(pSB_Aliens);
            GameObjectMan.Attach(explosion);
            TimerMan.Add(TimeEvent.Name.RemoveExplosion, new RemoveExplosionCommand(explosion), 0.25f);

        }

        public override void Execute()
        {
            this.pBomb.Remove();
            this.pMissile.Remove();
        }

        // --------------------------------------
        // data:
        // --------------------------------------
        private GameObject pBomb;
        private GameObject pMissile;
    }
}

// End of File

