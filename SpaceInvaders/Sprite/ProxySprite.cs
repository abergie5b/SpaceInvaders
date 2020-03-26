using System.Diagnostics;

namespace SpaceInvaders
{
    public class ProxySprite: SpriteBase
    {
        public enum Name
        {
            Proxy,
            Uninitialized
        }

        // Create a single sprite and all dynamic objects ONCE and ONLY ONCE (OOO- tm)
        public ProxySprite()
            : base()
        {
            this.name = ProxySprite.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;

            this.pSprite = null;
        }

        ~ProxySprite()
        {

        }

        public ProxySprite(GameSprite.Name name)
        {
            this.name = ProxySprite.Name.Proxy;

            this.x = 0.0f;
            this.y = 0.0f;

            this.pSprite = GameSpriteMan.Find(name);
            Debug.Assert(this.pSprite != null);
        }

        public void Set(GameSprite.Name name)
        {
            this.name = ProxySprite.Name.Proxy;

            this.x = 0.0f;
            this.y = 0.0f;

            this.pSprite = GameSpriteMan.Find(name);
            Debug.Assert(this.pSprite != null);
        }

        public override void Update()
        {
            // push the data from proxy to Real GameSprite
            this.PrivPushToReal();
            this.pSprite.Update();
        }

        public new void Clear()   // the "new" is there to shut up warning - overriding at derived class
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.name = Name.Uninitialized;
            this.pSprite = null;
        }

        public void Wash()
        {
            // Wash - clear the entire hierarchy
            base.Clear();
            this.Clear();
        }

        private void PrivPushToReal()
        {
            // push the data from proxy to Real GameSprite
            Debug.Assert(this.pSprite != null);

            this.pSprite.x = this.x;
            this.pSprite.y = this.y;
        }

        public override void Render()
        {
            this.PrivPushToReal();

            this.pSprite.Update();
            this.pSprite.Render();
        }

        public void SetName(Name inName)
        {
            this.name = inName;
        }

        public Name GetName()
        {
            return this.name;
        }

        public ProxySprite.Name name;
        public float x;
        public float y;
        public GameSprite pSprite;
    }
}
