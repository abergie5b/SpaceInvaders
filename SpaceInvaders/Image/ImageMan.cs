
namespace SpaceInvaders
{
    class ImageMan: Manager
    {
        private static ImageMan instance;
        private Image pNodeCompare;

        private ImageMan(int _nNumReserved, int _nGrowthSize)
            : base(_nNumReserved, _nGrowthSize)
        {
            this.pNodeCompare = new Image();
        }

        protected override DLink derivedCreateNode()
        {
            Image image = new Image();
            return image;
        }

        protected override bool derivedCompare(DLink nodeA, DLink nodeB)
        {
            Image pA = (Image) nodeA;
            Image pB = (Image) nodeB;
            if (pA.name == pB.name)
                return true;
            return false;
        }

        protected override void derivedWash(DLink node)
        {

            Image image = (Image) node;
            image.Wash();
        }

        public static void Create(int reserved, int growth)
        {
            if (instance == null)
                instance = new ImageMan(reserved, growth);
        }

        public static Image Add(Image.Name name, Texture.Name texture, Azul.Rect poRect)
        {
            Image image = (Image) instance.AddToFront();
            Texture pTexture = TextureMan.Find(texture);
            image.Initialize(name, pTexture, poRect);
            return image;
        }

        public static Image Find(Image.Name name)
        {
            instance.pNodeCompare.name = name;
            Image image = (Image) instance.baseFind(instance.pNodeCompare);
            return image;
        }

    }
}
