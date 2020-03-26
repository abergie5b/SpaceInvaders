
namespace SpaceInvaders
{
    public class SpriteNodeMan : Manager
    {
        private SpriteNode pNodeCompare;
        private SpriteBatch pBackSpriteBatch;
        private SpriteBatch.Name name;

        public SpriteNodeMan()
            :base()
        {
            pNodeCompare = new SpriteNode();
        }

        public SpriteNode Find(SpriteNode node)
        {
            return (SpriteNode)this.baseFind(node);
        }

        public SpriteNodeMan(int _mNumReserved, int _nGrowthSize)
            : base()
        {
            baseInitialize(_mNumReserved, _nGrowthSize);
            pNodeCompare = new SpriteNode();
        }

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new SpriteNode();
            return pNode;
        }

        protected override bool derivedCompare(DLink nodeA, DLink nodeB)
        {
            SpriteNode pA = (SpriteNode) nodeA;
            SpriteNode pB = (SpriteNode) nodeB;
            if (pA == pB)
                return true;
            return false;
        }

        protected override void derivedWash(DLink node)
        {
            SpriteNode pNode = (SpriteNode) node;
            pNode.Wash();
        }

        public static void Destroy()
        {
        }

        public void Set(SpriteBatch.Name name, int reserveNum, int reserveGrow)
        {
            this.name = name;

            this.baseSetReserve(reserveNum, reserveGrow);
        }

        public void Remove(SpriteNode pNode)
        {
            baseRemove(pNode);
        }

        public void Initialize(int _mNumReserved=5, int _nGrowthSize=2)
        {
            baseInitialize(_mNumReserved, _nGrowthSize);
        }

        public SpriteNode Attach(GameSprite.Name name)
        {
            SpriteNode spriteNode = (SpriteNode) baseAdd();
            spriteNode.Initialize(name);
            return spriteNode;
        }

        public SpriteNode Attach(SpriteBase pNode)
        {
            // Go to Man, get a node from reserve, add to active, return it
            SpriteNode pSBNode = (SpriteNode) this.baseAdd();

            // Initialize SpriteBatchNode
            pSBNode.Set(pNode);

            return pSBNode;
        }

        public void SetSpriteBatch(SpriteBatch _pSpriteBatch)
        {
            this.pBackSpriteBatch = _pSpriteBatch;
        }

        public SpriteNode Attach(ProxySprite pNode)
        {
            SpriteNode pSpriteNode = (SpriteNode)this.baseAdd();
            pSpriteNode.Set(pNode, this);
            return pSpriteNode;
        }

        public void Draw()
        {
            SpriteNode pNode = (SpriteNode) baseGetActive();
            while (pNode != null)
            {
                pNode.pSpriteBase.Render();
                pNode = (SpriteNode)pNode.pNext;
            }
        }
    }
}
