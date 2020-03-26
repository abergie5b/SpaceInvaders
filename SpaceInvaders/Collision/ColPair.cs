using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class ColPair_Link : DLink
    {
    }
    public class ColPair : ColPair_Link
    {
        public enum Name
        {
            Alien_Missile,
            Alien_Wall,
            Missile_Wall,
            Bomb_Wall,
            Bomb_Shield1,
            Bomb_Shield2,
            Bomb_Shield3,
            Bomb_Shield4,
            Missile_Shield1,
            Missile_Shield2,
            Missile_Shield3,
            Missile_Shield4,
            AlienGrid_WallLeft,
            AlienGrid_WallRight,
            AlienGrid_WallBottom,
            Bomb_Missile,
            ShipBomb,
            UFOMissile,
            AlienGrid_Shield1,
            AlienGrid_Shield2,
            AlienGrid_Shield3,
            AlienGrid_Shield4,
            UFO_WallLeft,
            UFO_WallRight,

            NullObject,
            Not_Initialized
        }
        public ColPair()
            : base()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;

            this.poSubject = new ColSubject();
            Debug.Assert(this.poSubject != null);
        }
        ~ColPair()
        {
        }
        public void Set(ColPair.Name colpairName, GameObject pTreeRootA, GameObject pTreeRootB)
        {
            Debug.Assert(pTreeRootA != null);
            Debug.Assert(pTreeRootB != null);

            this.treeA = pTreeRootA;
            this.treeB = pTreeRootB;
            this.name = colpairName;
        }
        public void Wash()
        {
            this.treeA = null;
            this.treeB = null;
            this.name = ColPair.Name.Not_Initialized;
        }
        public ColPair.Name GetName()
        {
            return this.name;
        }
        public void Process()
        {
            if (this.treeA.bCollisionEnabled && this.treeB.bCollisionEnabled)
                Collide(this.treeA, this.treeB);
        }

        static public void Collide(GameObject pSafeTreeA, GameObject pSafeTreeB)
        {
            GameObject pNodeA = pSafeTreeA;
            GameObject pNodeB = pSafeTreeB;

            while (pNodeA != null)
            {
                pNodeB = pSafeTreeB;

                while (pNodeB != null)
                {

                    ColRect rectA = pNodeA.GetColObject().poColRect;
                    ColRect rectB = pNodeB.GetColObject().poColRect;

                    if (ColRect.Intersect(rectA, rectB))
                    {
                        pNodeA.Accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)Iterator.GetSibling(pNodeB);
                }

                pNodeA = (GameObject)Iterator.GetSibling(pNodeA);
            }
        }
        public void SetName(ColPair.Name inName)
        {
            this.name = inName;
        }
        public void Attach(ColObserver observer)
        {
            this.poSubject.Attach(observer);
        }
        public void NotifyListeners()
        {
            this.poSubject.Notify();
        }
        public void SetCollision(GameObject pObjA, GameObject pObjB)
        {
            Debug.Assert(pObjA != null);
            Debug.Assert(pObjB != null);

            this.poSubject.pObjA = pObjA;
            this.poSubject.pObjB = pObjB;
        }
        public void Dump()
        {
            // TO DO ...
        }

        // Data: ---------------
        public ColPair.Name name;
        public GameObject treeA;
        public GameObject treeB;
        public ColSubject poSubject;
    }
}

// End of File
