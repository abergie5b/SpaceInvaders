using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveAlienObserver : ColObserver
    {
        public RemoveAlienObserver()
        {
            this.pAlien = null;
            this.pGameObj = null;
        }
        public RemoveAlienObserver(RemoveAlienObserver b)
        {
            Debug.Assert(b != null);
            this.pAlien = b.pAlien;
            this.pGameObj = b.pGameObj;
        }
        
        public override void Notify()
        {
            this.pGameObj = (GameObject)this.pSubject.pObjA;
            this.pAlien = (AlienCategory)this.pSubject.pObjB;
            Debug.Assert(this.pAlien != null);

            if (pAlien.bMarkForDeath == false)
            {
                pAlien.bMarkForDeath = true;
                //   Delay
                RemoveAlienObserver pObserver = new RemoveAlienObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            GameObject pA = (GameObject)this.pAlien;
            GameObject pB = (GameObject)Iterator.GetParent(pA);

            float x = this.pAlien.x;
            float y = this.pAlien.y;

            AlienGrid pGrid = (AlienGrid)this.pAlien.pParent.pParent;
            pGrid.nNumActive--;

            pA.Remove();

            // TODO: Need a better way... 
            if (privCheckParent(pB) == true)
            {
                GameObject pC = (GameObject)Iterator.GetParent(pB);
                pB.Remove();

                if (privCheckParent(pC) == true)
                {
                    pC.Remove();
                }
            }

            Missile pMissile = (Missile)this.pGameObj;
            Player pPlayer = pMissile.pPlayer;

            // 
            Font.Name pFontName = Font.Name.Uninitialized;
            if (this.pGameObj is MissileCategory)
            {
                pPlayer.nPoints += this.pAlien.GetPoints();
                Font pScore = null;
                if (pPlayer.n == 1)
                {
                    pScore = FontMan.Find(Font.Name.Score1Value);
                    pFontName = Font.Name.Score1Value;
                }
                if (pPlayer.n == 2)
                {
                    pScore = FontMan.Find(Font.Name.Score2Value);
                    pFontName = Font.Name.Score2Value;
                }
                pScore.Set(pFontName, 
                    pPlayer.nPoints.ToString(), 
                    Glyph.Name.Consolas20pt, 
                    pScore.pFontSprite.x, 
                    pScore.pFontSprite.y);
            }

            //---------------------------------------------------------------------------------------------------------
            // Sound
            //---------------------------------------------------------------------------------------------------------
            SoundMan.PlaySound(Sound.Name.InvaderKilled);
            TimeEvent pTimeEvent = TimerMan.Find(TimeEvent.Name.ScenePlaySound);
            pTimeEvent.deltaTime -= 0.01f;

            //---------------------------------------------------------------------------------------------------------
            // Explosion
            //---------------------------------------------------------------------------------------------------------
            Explosion explosion = new Explosion(GameObject.Name.Explosion, GameSprite.Name.Explosion, x, y);
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            explosion.ActivateGameSprite(pSB_Aliens);
            GameObjectMan.Attach(explosion);
            TimerMan.Add(TimeEvent.Name.RemoveExplosion, new RemoveExplosionCommand(explosion), 0.25f);

            //---------------------------------------------------------------------------------------------------------
            // Scene Transition
            //---------------------------------------------------------------------------------------------------------
            if (pGrid.nNumActive == 0 && pPlayer.nCurrLevel == 1)
            {
                PlayerMan.WriteHighScores();
                pPlayer.nCurrLevel++;
                SceneContext.GetState().Initialize();
                if (SceneContext.bMultiplayer)
                    SceneContext.SetState(SceneContext.Scene.MultiPlay);
                else
                    SceneContext.SetState(SceneContext.Scene.SinglePlay);
            }
            else if (pGrid.nNumActive == 0 && pPlayer.nCurrLevel == 2)
            {
                PlayerMan.WriteHighScores();
                SceneContext.SetState(SceneContext.Scene.Credits);
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
        private AlienCategory pAlien;
        private GameObject pGameObj;
    }
}

// End of File
