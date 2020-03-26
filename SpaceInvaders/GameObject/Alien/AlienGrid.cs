using System;

namespace SpaceInvaders
{
    public class AlienGrid : Composite
    {

        public AlienGrid(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
            this.nNumActive = 0;
            this.nTotalAliens = 55;
            this.pRandom = new Random();

            this.poColObj.pColSprite.SetLineColor(1, 1, 1);
            this.delta = 0.2f;
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitGrid(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void VisitMissile(Missile m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void VisitWallLeft(WallLeft l)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(l, this);
            pColPair.NotifyListeners();
        }

        public override void VisitWallRight(WallRight r)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(r, this);
            pColPair.NotifyListeners();
        }

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            this.MoveGridHorizontal();

            base.Update();
        }

        public void MoveGridHorizontal()
        {
            ForwardIterator pFor = new ForwardIterator(this);
            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.x += this.delta;
                pNode = pFor.Next();
            }
        }

        public void MoveGridVertical(float _delta)
        {
            ForwardIterator pFor = new ForwardIterator(this);
            Component pNode = pFor.First();
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                pGameObj.y += _delta;
                pNode = pFor.Next();
            }
        }

        public AlienCategory GetRandomAlien()
        {
            AlienCategory pAlien = null;
            ForwardIterator pFor = new ForwardIterator(this);
            Component pNode = pFor.First();
            int pCount = pRandom.Next(1, this.nTotalAliens-1);
            int x = 0;
            while (!pFor.IsDone())
            {
                GameObject pGameObj = (GameObject)pNode;
                if (!pGameObj.bMarkForDeath && x >= pCount && pGameObj is AlienCategory)
                {
                    pAlien = (AlienCategory)pGameObj;
                    break;
                }
                pNode = pFor.Next();
                x++;
            }
            return pAlien;
        }

        public void SetDelta(float delta)
        {
            this.delta = delta;
        }

        // Data: ---------------
        new private float delta;
        public int nNumActive;
        public int nTotalAliens;
        private Random pRandom;
    }
}

