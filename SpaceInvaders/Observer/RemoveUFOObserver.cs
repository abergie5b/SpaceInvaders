using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveUFOObserver : ColObserver
    {
        public RemoveUFOObserver()
        {
            this.pUFO = null;
            this.pGameObj = null;
        }
        public RemoveUFOObserver(RemoveUFOObserver b)
        {
            Debug.Assert(b != null);
            this.pUFO = b.pUFO;
            this.pGameObj = b.pGameObj;
        }
        
        public override void Notify()
        {
            this.pUFO = (UFO)this.pSubject.pObjA;
            this.pGameObj = (GameObject)this.pSubject.pObjB;
            Debug.Assert(this.pUFO != null);

            if (pUFO.bMarkForDeath == false)
            {
                pUFO.bMarkForDeath = true;
                //   Delay
                RemoveUFOObserver pObserver = new RemoveUFOObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            GameObject pA = (GameObject)this.pUFO;
            GameObject pB = (GameObject)Iterator.GetParent(pA);

            float x = this.pUFO.x;
            float y = this.pUFO.y;

            pA.Remove();

            // Hacks
            if (this.pGameObj is MissileGroup)
            {
                Missile pMissile = (Missile)Iterator.GetChild(this.pGameObj);

                 // bug but don't crash please
                if (pMissile == null) return;

                Player pPlayer = pMissile.pPlayer;
                pPlayer.nPoints += this.pUFO.GetPoints();
                Font.Name pFontName = Font.Name.Uninitialized;
                if (pPlayer.n == 1)
                    pFontName = Font.Name.Score1Value;
                if (pPlayer.n == 2)
                    pFontName = Font.Name.Score2Value;
                Font pScore = FontMan.Find(pFontName);
                pScore.Set(pFontName,
                    pPlayer.nPoints.ToString(), 
                    Glyph.Name.Consolas20pt, 
                    pScore.pFontSprite.x, 
                    pScore.pFontSprite.y);
            }

            SoundMan.PlaySound(Sound.Name.InvaderKilled);

            Explosion explosion = new Explosion(GameObject.Name.Explosion, GameSprite.Name.Explosion, x, y);
            SpriteBatch pSB_UFOs = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            explosion.ActivateGameSprite(pSB_UFOs);
            GameObjectMan.Attach(explosion);
            TimerMan.Add(TimeEvent.Name.RemoveExplosion, new RemoveExplosionCommand(explosion), 0.25f);
        }

        // -------------------------------------------
        // data:
        // -------------------------------------------
        private UFO pUFO;
        private GameObject pGameObj;
    }
}

// End of File
