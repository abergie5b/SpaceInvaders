
namespace SpaceInvaders
{
    public class Image: DLink
    {
        public enum Name
        {
            BlueAlien,
            BlueAlien2,
            GreenAlien,
            GreenAlien2,
            RedAlien,
            RedAlien2,
            Default,
            BlueClub,
            RedClub,
            YellowClub,
            WhiteAlien,
            WhiteAlienSmall,
            WhiteAlienMedium,
            WhiteAlienStanding,
            GreenBird,
            Ball,
            Club,
            Hoop,
            Chainsaw,
            Ship,
            Wall,
            WallBottom,
            Missile,
            UFO,
            Explosion,
            Explosion_Ground,
            Logo,

            BombStraight,
            BombZigZag,
            BombCross,

            Brick,
            BrickLeft_Top0,
            BrickLeft_Top1,
            BrickLeft_Bottom,
            BrickRight_Top0,
            BrickRight_Top1,
            BrickRight_Bottom,

            NullObject,
            Uninitialized
        }

        public Name name;
        private Azul.Rect poRect;
        private Texture pTexture;

        public Image(): base()
        {
            poRect = null;
            pTexture = TextureMan.Find(Texture.Name.Default);
        }

        public Image(Name _name, Texture _pTexture, Azul.Rect _poRect)
        {
            name = _name;
            pTexture = _pTexture;
            poRect = _poRect;
        }

        public void Initialize(Name _name, Texture texture, Azul.Rect _poRect)
        {
            name = _name;
            pTexture = texture;
            poRect = _poRect;
        }

        public void Wash()
        {
            name = Name.Uninitialized;
            pTexture = null;
            poRect = null;
        }

        public Azul.Texture GetAzulTexture()
        {
            return pTexture.GetTexture();
        }

        public Azul.Rect GetAzulRect()
        {
            return poRect;
        }

        public Name GetName()
        {
            return name;
        }

        public Azul.Texture GetTexture()
        {
            return pTexture.GetTexture();
        }

        public Azul.Rect GetRect()
        {
            return poRect;
        }
    }

}
