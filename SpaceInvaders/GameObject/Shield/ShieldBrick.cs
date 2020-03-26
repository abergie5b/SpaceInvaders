
namespace SpaceInvaders
{
    public class ShieldBrick : ShieldCategory
    {
        public ShieldBrick(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName, ShieldCategory.Type.Brick)
        {
            this.x = posX;
            this.y = posY;

            this.SetCollisionColor(1.0f, 1.0f, 1.0f);
        }

        ~ShieldBrick()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitShieldBrick(this);
        }

        public override void VisitMissile(Missile m)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(m, this);
            pColPair.NotifyListeners();
        }

        public override void VisitBomb(Bomb b)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(b, this);
            pColPair.NotifyListeners();
        }

        public override void VisitGrid(AlienGrid g)
        {
            ColPair pColPair = ColPairMan.GetActiveColPair();
            pColPair.SetCollision(g, this);
            pColPair.NotifyListeners();
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void VisitBombRoot(BombRoot b)
        {
            ColPair.Collide(b, (GameObject)Iterator.GetChild(this));
        }

        public override void Update()
        {
            base.Update();
        }

        // ---------------------------------
        // Data: 
        // ---------------------------------

    }
}

// End of File
