
namespace SpaceInvaders
{
    public class ShipReadyObserver : ColObserver
    {
        private Ship pShip;
        public ShipReadyObserver(Ship pShip)
        {
            this.pShip = pShip;
        }
        public override void Notify()
        {
            this.pShip.Handle();
        }
    }

        // data
}
