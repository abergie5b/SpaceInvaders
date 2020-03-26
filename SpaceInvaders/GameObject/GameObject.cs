using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameObject : Component
    {
        public enum Name
        {
            RedAlien,
            BlueAlien,
            WhiteAlien,
            GreenAlien,
            YellowAlien,
            AlienGrid,
            AlienColumn,
            UFO,

            WallGroup,
            WallRight,
            WallLeft,
            WallTop,
            WallBottom,

            ShieldRoot1,
            ShieldRoot2,
            ShieldRoot3,
            ShieldRoot4,
            ShieldGrid,
            ShieldColumn_0,
            ShieldColumn_1,
            ShieldColumn_2,
            ShieldColumn_3,
            ShieldColumn_4,
            ShieldColumn_5,
            ShieldColumn_6,
            ShieldBrick,

            Ship,
            ShipRoot,
            ShipInactive,

            Missile,
            MissileGroup,

            Bomb,
            BombRoot,

            Explosion,
            Explosion_Ground,

            Logo,
            NullObject,
            Uninitialized
        }

        protected GameObject(GameObject.Name gameName, GameSprite.Name spriteName)
        : base()
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.bMarkForDeath = false;
            this.bCollisionEnabled = true;
            this.pProxySprite = ProxySpriteMan.Add(spriteName);

            this.poColObj = new ColObject(this.pProxySprite);
            Debug.Assert(this.poColObj != null);
        }

        ~GameObject()
        {

        }

        public virtual void Remove()
        {
            Debug.WriteLine("REMOVE: {0}", this);

            // Remove from SpriteBatch
            // Find the SpriteNode
            Debug.Assert(this.pProxySprite != null);
            SpriteNode pSpriteNode = this.pProxySprite.GetSpriteNode();

            // Remove it from the manager
            Debug.Assert(pSpriteNode != null);
            SpriteBatchMan.Remove(pSpriteNode);

            // Remove collision sprite from spriteBatch
            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);
            pSpriteNode = this.poColObj.pColSprite.GetSpriteNode();

            Debug.Assert(pSpriteNode != null);
            SpriteBatchMan.Remove(pSpriteNode);

            // Remove from GameObjectMan
            GameObjectMan.Remove(this);

            //GhostMan.Add(this);
        }

        protected void BaseUpdateBoundingBox(Component pStart)
        {
            GameObject pNode = (GameObject)pStart;
            ColRect ColTotal = this.poColObj.poColRect;

            pNode = (GameObject)Iterator.GetChild(pNode);

            if (pNode != null)
            {
                ColTotal.Set(pNode.poColObj.poColRect);
                while (pNode != null)
                {
                    ColTotal.Union(pNode.poColObj.poColRect);
                    pNode = (GameObject)Iterator.GetSibling(pNode);
                }

                this.x = this.poColObj.poColRect.x;
                this.y = this.poColObj.poColRect.y;
            }
        }

        public virtual void Update()
        {
            Debug.Assert(this.pProxySprite != null);
            this.pProxySprite.x = this.x;
            this.pProxySprite.y = this.y;

            Debug.Assert(this.poColObj != null);
            this.poColObj.UpdatePos(this.x, this.y);
            Debug.Assert(this.poColObj.pColSprite != null);
            this.poColObj.pColSprite.Update();
        }

        public void ActivateCollisionSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            Debug.Assert(this.poColObj != null);
            pSpriteBatch.Attach(this.poColObj.pColSprite);
        }

        public void ActivateGameSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            pSpriteBatch.Attach(this.pProxySprite);
        }

        public void SetCollisionColor(float red, float green, float blue)
        {
            Debug.Assert(this.poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);

            this.poColObj.pColSprite.SetLineColor(red, green, blue);
        }

        public ColObject GetColObject()
        {
            Debug.Assert(this.poColObj != null);
            return this.poColObj;
        }

        public GameObject.Name GetName()
        {
            return this.name;
        }

        // --------------------------------------
        // Data: 
        // --------------------------------------
        public GameObject.Name name;

        public float x;
        public float y;
        
        public bool bMarkForDeath;
        public bool bCollisionEnabled;

        public ProxySprite pProxySprite;
        public ColObject poColObj;


    }
}
