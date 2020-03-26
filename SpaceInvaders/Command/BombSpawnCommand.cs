using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BombSpawnEvent : Command
    {
        public BombSpawnEvent(int nCurrLevel, Random pRandom)
        {
            this.nCurrLevel = nCurrLevel;

            this.pBombRoot = GameObjectMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(this.pBombRoot != null);

            this.pSB_Bombs = SpriteBatchMan.Find(SpriteBatch.Name.Bombs);
            Debug.Assert(this.pSB_Bombs != null);

            this.pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            Debug.Assert(this.pSB_Boxes != null);

            this.pRandom = pRandom;
        }

        override public void Execute(float deltaTime)
        {
            int pFreq = pRandom.Next(1, 10) / this.nCurrLevel;

            AlienGrid pGrid = (AlienGrid)GameObjectMan.Find(GameObject.Name.AlienGrid);
            AlienCategory pAlien = pGrid.GetRandomAlien();
            // HACK don't crash pleease
            if (pAlien == null)
            {
                TimerMan.Add(TimeEvent.Name.BombSpawn, this, pFreq);
                return;
            }

            int type = pRandom.Next(0, 2);
            FallStrategy pFallStrategy = null;
            switch (type)
            {
                case (0):
                    pFallStrategy = new FallZigZag();
                    break;
                case (1):
                    pFallStrategy = new FallDagger();
                    break;
                case (2):
                    pFallStrategy = new FallStraight();
                    break;
            }
            type = pRandom.Next(0, 2);
            GameSprite.Name pGameSpriteName = GameSprite.Name.Uninitialized;
            switch (type)
            {
                case (0):
                    pGameSpriteName = GameSprite.Name.BombZigZag;
                    break;
                case (1):
                    pGameSpriteName = GameSprite.Name.BombDagger;
                    break;
                case (2):
                    pGameSpriteName = GameSprite.Name.BombStraight;
                    break;
            }

            Bomb pBomb = new Bomb(GameObject.Name.Bomb, pGameSpriteName, pFallStrategy, pAlien.x, pAlien.y);
            pBomb.ActivateCollisionSprite(this.pSB_Boxes);
            pBomb.ActivateGameSprite(this.pSB_Bombs);

            GameObject pBombRoot = GameObjectMan.Find(GameObject.Name.BombRoot);
            Debug.Assert(pBombRoot != null);

            pBombRoot.Add(pBomb);
            TimerMan.Add(TimeEvent.Name.BombSpawn, this, pFreq);
        }

        GameObject pBombRoot;
        SpriteBatch pSB_Bombs;
        SpriteBatch pSB_Boxes;
        Random pRandom;
        int nCurrLevel;
    }
}

// End of File

