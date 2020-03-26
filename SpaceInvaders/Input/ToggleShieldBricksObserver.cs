
namespace SpaceInvaders
{
    class ToggleShieldBricksObserver: InputObserver
    {
        override public void Notify()
        {
            // toggle rendering
            SpriteBatch sb_Shields = SpriteBatchMan.Find(SpriteBatch.Name.Shields);
            sb_Shields.bRenderEnabled = !sb_Shields.bRenderEnabled;

            // toggle collisions
            GameObject pShieldRoot = GameObjectMan.Find(GameObject.Name.ShieldRoot1);
            pShieldRoot.bCollisionEnabled = !pShieldRoot.bCollisionEnabled;

            // toggle collisions
            pShieldRoot = GameObjectMan.Find(GameObject.Name.ShieldRoot2);
            pShieldRoot.bCollisionEnabled = !pShieldRoot.bCollisionEnabled;

            // toggle collisions
            pShieldRoot = GameObjectMan.Find(GameObject.Name.ShieldRoot3);
            pShieldRoot.bCollisionEnabled = !pShieldRoot.bCollisionEnabled;

            // toggle collisions
            pShieldRoot = GameObjectMan.Find(GameObject.Name.ShieldRoot4);
            pShieldRoot.bCollisionEnabled = !pShieldRoot.bCollisionEnabled;
        }
    }
}
