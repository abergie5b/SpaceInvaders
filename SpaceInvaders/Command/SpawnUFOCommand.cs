using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpawnUFOCommand : Command
    {
        public SpawnUFOCommand(Random pRandom, WallLeft pWallLeft, WallRight pWallRight)
        {
            this.pUFO = GameObjectMan.Find(GameObject.Name.UFO);
            Debug.Assert(this.pUFO != null);

            this.pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            Debug.Assert(this.pSB_Aliens != null);

            this.pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            Debug.Assert(this.pSB_Boxes != null);

            this.pRandom = pRandom;
            this.pWallLeft = pWallLeft;
            this.pWallRight = pWallRight;
        }

        override public void Execute(float deltaTime)
        {
            float value = pRandom.Next(10, 60);
            UFO pUFO = new UFO(GameObject.Name.UFO, GameSprite.Name.UFO, 100, 515);

            ColPair pColPair = ColPairMan.Add(ColPair.Name.UFO_WallLeft, pUFO, this.pWallLeft);
            pColPair.Attach(new UFOWallLeftObserver());

            pColPair = ColPairMan.Add(ColPair.Name.UFO_WallRight, pUFO, this.pWallRight);
            pColPair.Attach(new UFOWallRightObserver());

            MissileGroup pMissile = (MissileGroup)GameObjectMan.Find(GameObject.Name.MissileGroup);
            pColPair = ColPairMan.Add(ColPair.Name.UFOMissile, pUFO, pMissile);
            pColPair.Attach(new RemoveUFOObserver());

            pUFO.ActivateCollisionSprite(this.pSB_Boxes);
            pUFO.ActivateGameSprite(this.pSB_Aliens);
            GameObjectMan.Attach(pUFO);

            Sound.Name pSoundName = Sound.Name.Uninitialized;
            switch (pRandom.Next(0, 1))
            {
                case (0):
                    pSoundName = Sound.Name.UFOLow;
                    break;
                case (1):
                    pSoundName = Sound.Name.UFOHigh;
                    break;
            }
            SoundMan.PlaySound(pSoundName);
            TimerMan.Add(TimeEvent.Name.UFO, this, value);
        }

        GameObject pUFO;
        SpriteBatch pSB_Aliens;
        SpriteBatch pSB_Boxes;
        WallLeft pWallLeft;
        WallRight pWallRight;
        Random pRandom;
    }
}

// End of File

