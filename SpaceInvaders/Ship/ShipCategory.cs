
namespace SpaceInvaders
{
    abstract public class ShipCategory : Leaf
    {
        public enum Type
        {
            Ship,
            ShipRoot,
            Unitialized
        }

        protected ShipCategory(GameObject.Name name, GameSprite.Name spriteName, ShipCategory.Type shipType)
            : base(name, spriteName)
        {
            this.type = shipType;
        }

        // Data: ---------------
        ~ShipCategory()
        {
        }

        protected ShipCategory.Type type;

    }
}