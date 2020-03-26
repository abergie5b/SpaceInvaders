
namespace SpaceInvaders
{
    class BombObserver : ColObserver
    {
        public override void Notify()
        {
            Ship pShip = (Ship)this.pSubject.pObjA;
            Bomb pBomb = (Bomb)this.pSubject.pObjB;
            if (pBomb.bMarkForDeath == false)
            {
                pBomb.bMarkForDeath = true;
                pBomb.Remove();
            }

            Player pPlayer = pShip.pPlayer;
            pPlayer.nLives--;

            //---------------------------------------------------------------------------------------------------------
            // Scene Transition
            //---------------------------------------------------------------------------------------------------------
            if (pPlayer.nLives == 0 && pPlayer.n == 1 && PlayerMan.nPlayers == 2)
            {
                // Switch players
                PlayerMan.WriteHighScores();
                PlayerMan.SetCurrentPlayer(2);
                SceneContext.GetState().Initialize();
                SceneContext.SetState(SceneContext.Scene.MultiPlay);
                return;
            }
            else if (pPlayer.nLives == 0 && pPlayer.n == PlayerMan.nPlayers)
            {
                // Game OVER
                PlayerMan.WriteHighScores();
                SceneContext.SetState(SceneContext.Scene.Over);
                return;
            }

            Font pFont = FontMan.Find(Font.Name.NumLives1);
            pFont.Set(Font.Name.NumLives1, pShip.pPlayer.nLives.ToString(), Glyph.Name.Consolas20pt, 15, 15);

            Ship pShipInactive = (Ship)GameObjectMan.Find(GameObject.Name.ShipInactive);
            if (pShipInactive.bMarkForDeath == false)
            {
                pShipInactive.bMarkForDeath = true;
                pShipInactive.RemoveInactiveShip();
            }

        }

        // ------------------------------------
        // Data
        // ------------------------------------

    }
}

// End of File
