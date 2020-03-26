
namespace SpaceInvaders
{
    public class Ship : ShipCategory
    {

       public Ship(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
        : base(name, spriteName, ShipCategory.Type.Ship)
        {
            this.x = posX;
            this.y = posY;

            this.shipSpeed = 1.0f;
            this.state = null;
            this.pPlayer = null;
            this.pMissile = null;
        }

        public void SetPlayer(Player pPlayer)
        {
            this.pPlayer = pPlayer;
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Accept(ColVisitor other)
        {
            other.VisitShip(this);
        }

        public void MoveRight()
        {
            this.state.MoveRight(this);
        }

        public void MoveLeft()
        {
            this.state.MoveLeft(this);
        }

        public void ShootMissile()
        {
            this.state.ShootMissile(this);
        }

        public void SetState(ShipMan.State inState)
        {
            this.state = ShipMan.GetState(inState);
        }
        public void Handle()
        {
            this.state.Handle(this);
        }
        public ShipState GetState()
        {
            return this.state;
        }
        public Missile GetMissile()
        {
            return pMissile;
        }
        public void SetMissile(Missile missile)
        {
            this.pMissile = missile;
        }
        public void RemoveInactiveShip()
        {
            SpriteNode pSpriteNode = this.pProxySprite.GetSpriteNode();
            SpriteBatchMan.Remove(pSpriteNode);
        }

        // Data: --------------------
        public float shipSpeed;
        private ShipState state;
        public Player pPlayer;
        private Missile pMissile;
    }
}
