
namespace SpaceInvaders
{
    class MoveRightObserver : InputObserver
    {
        public MoveRightObserver(Ship pShip)
        {
            this.pShip = pShip;
        }
        public override void Notify()
        {
            this.pShip.MoveRight();
        }
        private Ship pShip;
    }
}
