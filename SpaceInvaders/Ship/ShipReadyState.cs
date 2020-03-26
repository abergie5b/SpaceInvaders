
namespace SpaceInvaders
{
    class ShipStateReady : ShipState
    {
        public override void Handle(Ship pShip)
        {
            pShip.SetState(ShipMan.State.MissileFlying);
        }

        public override void MoveRight(Ship pShip)
        {
            if (pShip.x < 800)
                pShip.x += pShip.shipSpeed;
        }

        public override void MoveLeft(Ship pShip)
        {
            if (pShip.x > 0)
                pShip.x -= pShip.shipSpeed;
        }

        public override void ShootMissile(Ship pShip)
        {

            pShip.SetMissile(new Missile(GameObject.Name.Missile, GameSprite.Name.Missile, 400, 100));
            Missile pMissile = ShipMan.ActivateMissile(pShip);

            pMissile.SetPos(pShip.x, pShip.y+20);

            // switch states
            this.Handle(pShip);
        }

    }
}
