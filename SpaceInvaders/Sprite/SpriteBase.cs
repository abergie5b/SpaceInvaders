
namespace SpaceInvaders
{
    public abstract class SpriteBase : DLink
    {
        protected Azul.Rect poRect;
        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;
        private SpriteNode pBackSpriteNode;

        public SpriteBase() : base()
        {
            poRect = null;
            pBackSpriteNode = null;
        }
        public abstract void Render();
        public abstract void Update();

        public float GetX() { return x; }
        public float GetY() { return y; }
        public float GetSX() {  return sx; }
        public float GetSY() {  return x; }
        public float GetAngle() { return angle; }

        public SpriteNode GetSpriteNode()
        {
            return this.pBackSpriteNode;
        }
        public void SetSpriteNode(SpriteNode pSpriteBatchNode)
        {
            this.pBackSpriteNode = pSpriteBatchNode;
        }

    }
}
