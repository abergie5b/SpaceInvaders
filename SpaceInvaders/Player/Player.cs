
namespace SpaceInvaders
{
    public class Player : DLink
    {
        public Ship pShip;
        public int nPoints;
        public int nLives;
        public int nCurrLevel;
        public int n;

        public Player(int n, Ship pShip): base()
        {
            this.n = n;
            this.pShip = pShip;
            this.pShip.SetPlayer(this);
            this.nPoints = 0;
            this.nLives = 3;
            this.nCurrLevel = 1;
        }

    }
}
