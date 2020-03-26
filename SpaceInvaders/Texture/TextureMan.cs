
using System;

namespace SpaceInvaders
{
    class TextureMan: Manager
    {
        private static TextureMan instance;
        private Texture pNodeCompare;

        private TextureMan(int _nNumReserved, int _nGrowthSize)
            : base(_nNumReserved, _nGrowthSize)
        {
            this.pNodeCompare = new Texture();
        }

        protected override DLink derivedCreateNode()
        {
            Texture texture = new Texture();
            return texture;
        }

        protected override bool derivedCompare(DLink nodeA, DLink nodeB)
        {
            Texture pA = (Texture) nodeA;
            Texture pB = (Texture) nodeB;
            if (pA.name == pB.name)
                return true;
            return false;
        }

        protected override void derivedWash(DLink node)
        {
            Texture texture = (Texture) node;
            texture.Wash();
        }

        public static void Create(int reserved, int growth)
        {
            if (instance == null)
                instance = new TextureMan(reserved, growth);
        }

        public static Texture Add(Texture.Name name, string filename)
        {
            Texture texture = (Texture) instance.AddToFront();
            texture.Initialize(name, new Azul.Texture(filename));
            return texture;
        }

        public static Texture Find(Texture.Name name)
        {
            instance.pNodeCompare.name = name;
            Texture texture = (Texture) instance.baseFind(instance.pNodeCompare);
            return texture;
        }

    }
}
