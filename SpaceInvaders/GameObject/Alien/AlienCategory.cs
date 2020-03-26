
namespace SpaceInvaders
{
    abstract public class AlienCategory : Leaf
    {
        protected int nPoints;

        public enum Type
        {
            // temporary location --> move this
            Red,
            Yellow,
            Green,
            White,
            Blue,

            Column,
            Grid,

            Unitialized
        }

        public AlienCategory(GameObject.Name name, GameSprite.Name spriteName)
            : base(name, spriteName)
        {

        }

        public int GetPoints()
        {
            return nPoints;
        }

        public override void Remove()
        {
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();

            // Update the parent (alien root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.Update();

            // Now remove it
            base.Remove();
        }

    }
}
