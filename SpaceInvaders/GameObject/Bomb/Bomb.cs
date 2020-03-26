
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Bomb : BombCategory
    {
        public Bomb(GameObject.Name name, GameSprite.Name spriteName, FallStrategy strategy, float posX, float posY)
            : base(name, spriteName, BombCategory.Type.Bomb)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 1.0f;

            Debug.Assert(strategy != null);
            this.pStrategy = strategy;

            this.pStrategy.Reset(this.y);

            this.poColObj.pColSprite.SetLineColor(1, 1, 0);
        }

        public void Reset()
        {
            this.y = 700.0f;
            this.pStrategy.Reset(this.y);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitShipRoot(ShipRoot b)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(b);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitMissile(Missile m)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        public override void VisitShip(Ship s)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(s, this);
            pColPair.NotifyListeners();
        }

        public override void Remove()
        {
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();

            base.Remove();
        }

        public override void Update()
        {
            this.y -= delta;
            this.pStrategy.Fall(this);
            base.Update();
        }

        public float GetBoundingBoxHeight()
        {
            return this.poColObj.poColRect.height;
        }

        ~Bomb()
        {
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitBomb(this);
        }

        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        public void MultiplyScale(float sx, float sy)
        {
            Debug.Assert(this.pProxySprite != null);

            // Why
            this.pProxySprite.pSprite.sx *= sx;
            this.pProxySprite.pSprite.sy *= sy;
        }

        // Data
        public float delta;
        private FallStrategy pStrategy;
    }
}

// End of File
