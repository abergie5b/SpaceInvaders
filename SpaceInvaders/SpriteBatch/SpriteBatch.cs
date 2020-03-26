
namespace SpaceInvaders
{
    abstract public class SpriteBatch_Link : DLink
    {

    }
    public class SpriteBatch : DLink
    {

        public bool bRenderEnabled;
        public SpriteNodeMan pSpriteNodeMan;
        public int key;

        public enum Name
        {
            Boxes,
            Birds,
            Texts,
            Shields,
            Aliens,
            Bombs,
            Balls,
            Clubs,
            Props,
            Uninitialized
        }
        public Name name;

        public void Wash()
        {
            name = Name.Uninitialized;
            pSpriteNodeMan = null;
        }

        public SpriteBatch()
            : base()
        {
            this.name = Name.Uninitialized;
            this.pSpriteNodeMan = new SpriteNodeMan();
            this.key = -1;
            this.bRenderEnabled = true;
        }

        public void SetPriority(int _key)
        {
            this.key = _key;
        }

        public void Attach(GameSprite.Name name)
        {
            pSpriteNodeMan.Attach(name);
        }

        public SpriteBatch.Name GetName()
        {
            return this.name;
        }

        public void SetName(SpriteBatch.Name name)
        {
            this.name = name;
        }

        public SpriteNode Attach(ProxySprite pNode)
        {
            return pSpriteNodeMan.Attach(pNode);
        }

        public SpriteNodeMan GetSpriteNodeMan()
        {
            return this.pSpriteNodeMan;
        }
        public void Attach(SpriteBase pNode)
        {
            // Go to Man, get a node from reserve, add to active, return it
            SpriteNode pSpriteNode = (SpriteNode)this.pSpriteNodeMan.Attach(pNode);

            // Initialize SpriteBatchNode
            pSpriteNode.Set(pNode, this.pSpriteNodeMan);

            // Back pointer
            this.pSpriteNodeMan.SetSpriteBatch(this);
        }

        public void Set(SpriteBatch.Name name, int reserveNum = 3, int reserveGrow = 1)
        {
            this.name = name;
            this.pSpriteNodeMan.Set(name, reserveNum, reserveGrow);
        }

        public void Initialize(SpriteBatch.Name _name, int _key, bool _bRenderEnabled, int _mNumReserved=5, int _nGrowthSize=2)
        {
            this.name = _name;
            this.key = _key;
            this.bRenderEnabled = _bRenderEnabled;
            this.pSpriteNodeMan = new SpriteNodeMan();
            this.pSpriteNodeMan.Initialize(_mNumReserved, _nGrowthSize);
        }

    }
}
