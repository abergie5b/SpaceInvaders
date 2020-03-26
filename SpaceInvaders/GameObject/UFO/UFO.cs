using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFO : UFOCategory
    {
        public UFO(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
        : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 1.0f;
            this.pRandom = new Random();
        }

        public void SetDelta(float _delta)
        {
            this.delta = _delta;
        }

        // Data: ---------------
        ~UFO()
        {

        }
        public override void Accept(ColVisitor other)
        {
            other.VisitUFO(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitMissile(Missile m)
        {
            ColPair cp = ColPairMan.GetActiveColPair();
            cp.SetCollision(m, this);
            cp.NotifyListeners();
        }

        public override void Update()
        {
            this.x += this.delta;
            base.Update();
        }

        public int GetPoints()
        {
            int points = 0;
            switch (pRandom.Next(0, 2))
            {
                case (0):
                    points = 50;
                    break;
                case (1):
                    points = 100;
                    break;
                case (2):
                    points = 150;
                    break;
            }
            return points;
        }
        private Random pRandom;
        new private float delta;

    }
}
