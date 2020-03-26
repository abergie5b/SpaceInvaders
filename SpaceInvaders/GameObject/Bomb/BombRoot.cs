
namespace SpaceInvaders
{
    public class BombRoot : Composite
    {
        public BombRoot(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetLineColor(1, 1, 1);
        }

        ~BombRoot()
        {
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitMissile(Missile m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitBombRoot(BombRoot b)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(b);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitShipRoot(ShipRoot b)
        {
            GameObject pGameObjA = (GameObject)Iterator.GetChild(b);
            GameObject pGameObjB = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(pGameObjA, pGameObjB);
        }

        public override void  VisitShip(Ship m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(m);
            GameObject pGameObjB = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(pGameObj, pGameObjB);
        }

        public override void Accept(ColVisitor other)
        {
      
            other.VisitBombRoot(this);
        }

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // Data: ---------------


    }
}

// End of File
