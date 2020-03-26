
namespace SpaceInvaders
{
    class RemoveExplosionCommand : Command
    {
        public RemoveExplosionCommand(Explosion pExplosion)
        {
            this.pExplosion = pExplosion;
        }

        public override void Execute(float deltaTime)
        {
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            SpriteNodeMan pNodeMan = pSB_Aliens.GetSpriteNodeMan();
            pNodeMan.Remove(this.pExplosion.pProxySprite.GetSpriteNode());
        }

        // Data: ---------------
        private readonly Explosion pExplosion;
    }

}
