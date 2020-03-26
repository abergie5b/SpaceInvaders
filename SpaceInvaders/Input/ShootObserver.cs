using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShootObserver : InputObserver
    {
        public ShootObserver(Ship pShip)
        {
            this.pShip = pShip;
        }
        public override void Notify()
        {
            SoundMan.PlaySound(Sound.Name.Shoot);
            pShip.ShootMissile();
        }
        private Ship pShip;
    }
}