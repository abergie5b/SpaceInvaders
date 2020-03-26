
namespace SpaceInvaders
{
    abstract public class UFOCategory : Leaf
    {
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

        public UFOCategory(GameObject.Name name, GameSprite.Name spriteName)
            : base(name, spriteName)
        {

        }

        public override void Remove()
        {
            this.poColObj.poColRect.Set(0, 0, 0, 0);
            base.Update();
            base.Remove();
        }

        public void Explode()
        {
            //this.pProxySprite.pSprite.SwapImage(ImageMan.Find(Image.Name.WhiteUFO));
        }
    }
}
