using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissileGroup : Composite
    {
        public MissileGroup(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
          : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetLineColor(0, 0, 1);
        }

        ~MissileGroup()
        {

        }
        public override void VisitBombRoot(BombRoot b)
        {
            GameObject pGameObj = (GameObject)Iterator.GetChild(b);
            ColPair.Collide(pGameObj, this);
        }
        public override void VisitUFO(UFO u)
        {
            ColPair cp = ColPairMan.GetActiveColPair();
            cp.SetCollision(u, this);
            cp.NotifyListeners();
        }
        public override void VisitBomb(Bomb u)
        {
            ColPair cp = ColPairMan.GetActiveColPair();
            cp.SetCollision(u, this);
            cp.NotifyListeners();
        }


        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an MissileGroup
            // Call the appropriate collision reaction            
            other.VisitMissileGroup(this);
        }

        public override void Update()
        {
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }



        // Data: ---------------


    }
}