
namespace SpaceInvaders
{
    public class Missile : MissileCategory
    {
        public Player pPlayer;
        public Missile(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 6.5f;
            this.pPlayer = null;
        }

        public override void Update()
        {
            base.Update();
            this.y += delta;
        }

        ~Missile()
        {

        }
        
        public override void VisitMissile(Missile m)
        {
            ColPair cp = ColPairMan.GetActiveColPair();
            cp.SetCollision(m, this);
            cp.NotifyListeners();
        }
        public override void VisitUFO(UFO u)
        {
            ColPair cp = ColPairMan.GetActiveColPair();
            cp.SetCollision(u, this);
            cp.NotifyListeners();
        }


        public override void VisitBomb(Bomb b)
        {
            ColPair cp = ColPairMan.GetActiveColPair();
            cp.SetCollision(b, this);
            cp.NotifyListeners();
        }

        public override void VisitBombRoot(BombRoot b)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(b);
            ColPair.Collide(pGameObj, this);
        }

        public override void Remove()
        {
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();

            base.Remove();
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitMissile(this);
        }

        public void SetPos(float xPos, float yPos)
        {
            this.x = xPos;
            this.y = yPos;
        }

        // Data -------------------------------------
        public float delta;
    }
}