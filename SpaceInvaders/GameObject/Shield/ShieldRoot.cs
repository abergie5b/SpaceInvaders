
namespace SpaceInvaders
{
    public class ShieldRoot : Composite
    {
        public ShieldRoot(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

        ~ShieldRoot()
        {
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitShieldRoot(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(m);
            ColPair.Collide(pGameObj, this);
        }

        public override void VisitMissile(Missile m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void VisitBombRoot(BombRoot b)
        {
            ColPair.Collide((GameObject)Iterator.GetChild(b), this);
        }

        public override void VisitGrid(AlienGrid m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void VisitBomb(Bomb b)
        {
            ColPair.Collide(b, (GameObject)Iterator.GetChild(this));
        }

        public override void Update()
        {
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // ------------------------------------------
        // Data:
        // ------------------------------------------

    }
}

// End of File

