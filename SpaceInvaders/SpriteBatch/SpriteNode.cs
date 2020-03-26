
using Azul;

namespace SpaceInvaders
{
    public class SpriteNode : DLink
    {
        public SpriteBase pSpriteBase;
        public SpriteNodeMan pBackSpriteNodeMan;

        public SpriteNode()
            : base()
        {
            this.pSpriteBase = null;
            this.pBackSpriteNodeMan = null;
        }
        public void Set(SpriteBase pNode, SpriteNodeMan _pSpriteNodeMan)
        {
            this.pSpriteBase = pNode;

            // Set the back pointer
            // Allows easier deletion in the future
            this.pSpriteBase.SetSpriteNode(this);

            this.pBackSpriteNodeMan = _pSpriteNodeMan;
        }

        public void Set(SpriteBase pNode)
        {
            this.pSpriteBase = pNode;
        }

        public void Set(ProxySprite pNode)
        {
            this.pSpriteBase = pNode;
        }

        public void Initialize(GameSprite.Name name)
        {
            pSpriteBase = GameSpriteMan.Find(name);
        }

        public void Initialize(BoxSprite.Name name, int _key)
        {
            pSpriteBase = BoxSpriteMan.Find(name);
        }

        public void Wash()
        {
            this.pSpriteBase = null;
            this.pBackSpriteNodeMan = null;
        }
    }
}
