
namespace SpaceInvaders
{
    public class Explosion : Leaf
    {

        public Explosion(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
        : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

        // Data: ---------------
        ~Explosion()
        {

        }

        public override void Accept(ColVisitor other)
        {
            other.VisitExplosion(this);
        }

        public override void Remove()
        {
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();
            base.Remove();
        }

    }
}
