using System.Diagnostics;

namespace SpaceInvaders
{
    public class Logo : GameObject
    {
        public Logo(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }

        override public void Add(Component c)
        {
            Debug.Assert(false);
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitLogo(this);
        }

        override public void Remove(Component c)
        {
           Debug.Assert(false);
        }

        override public void Print()
        {
           // Debug.WriteLine(" GameObject Name: {0} ({1})  parent:{2}", this.GetName(), this.GetHashCode(), Iterator.GetParent(this).GetHashCode());
        }

        override public Component GetFirstChild()
        {
            Debug.Assert(false);
            return null;
        }

    }
}
