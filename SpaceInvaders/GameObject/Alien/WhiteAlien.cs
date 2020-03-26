
namespace SpaceInvaders
{
    public class WhiteAlien : AlienCategory
    {
        public WhiteAlien(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
    : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

        // Data: ---------------
        ~WhiteAlien()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitWhiteAlien(this);
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
            base.Update();
        }


    }
}
