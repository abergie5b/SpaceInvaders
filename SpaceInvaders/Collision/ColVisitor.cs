using System.Diagnostics;

namespace SpaceInvaders
{

    abstract public class ColVisitor : DLink
    {
        public virtual void VisitExplosion(Explosion e)
        {
            Debug.WriteLine("Visit by Explosion not implemented");
            Debug.Assert(false);
        }

        public virtual void VisitShieldGrid(ShieldGrid s)
        {
            Debug.WriteLine("Visit by ShieldGrid not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitShieldRoot(ShieldRoot s)
        {
            Debug.WriteLine("Visit by ShieldRoot not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitShieldColumn(ShieldColumn s)
        {
            Debug.WriteLine("Visit by ShieldColumn not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitShieldBrick(ShieldBrick s)
        {
            Debug.WriteLine("Visit by ShieldBrick not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitGrid(AlienGrid b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienGroup not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitColumn(AlienColumn b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by AlienColumn not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitRedAlien(RedAlien b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by RedAlien not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitBlueAlien(BlueAlien b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by BlueAlien not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitYellowAlien(YellowAlien b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by YellowAlien not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitGreenAlien(GreenAlien b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by GreenAlien not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWhiteAlien(WhiteAlien b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by WhiteAlien not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitUFO(UFO u)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by UFO not implemented");
            Debug.Assert(false);
        }


        public virtual void VisitMissile(Missile m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Missile not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitMissileGroup(MissileGroup m)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by MissileGroup not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitNullGameObject(NullGameObject n)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by NullGameObject not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallGroup(WallGroup w)
        {
            Debug.WriteLine("Visit by WallGroup not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallBottom(WallBottom w)
        {
            Debug.WriteLine("Visit by WallBottom not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallRight(WallRight w)
        {
            Debug.WriteLine("Visit by WallRight not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallLeft(WallLeft w)
        {
            Debug.WriteLine("Visit by WallLeft not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitWallTop(WallTop w)
        {
            Debug.WriteLine("Visit by WallTop not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitBomb(Bomb b)
        {
            // no differed to subcass
            Debug.WriteLine("Visit by Bomb not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitBombRoot(BombRoot b)
        {
            Debug.WriteLine("Visit by BombRoot not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitShip(Ship s)
        {
            Debug.WriteLine("Visit by Ship not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitShipRoot(ShipRoot s)
        {
            Debug.WriteLine("Visit by ShipRoot not implemented");
            Debug.Assert(false);
        }
        public virtual void VisitLogo(Logo l)
        {
            Debug.WriteLine("Visit by Logo not implemented");
            Debug.Assert(false);
        }

        abstract public void Accept(ColVisitor other);
    }

}