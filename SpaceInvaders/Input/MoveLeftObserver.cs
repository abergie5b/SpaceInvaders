
namespace SpaceInvaders
{
    class MoveLeftObserver : InputObserver
    {
        public MoveLeftObserver(Ship pShip)
        {
            this.pShip = pShip;
        }
        public override void Notify()
        {
            pShip.MoveLeft();
        }
        private Ship pShip;
    }
}
