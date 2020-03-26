using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GridObserver : ColObserver
    {
        public GridObserver()
        {
             
        }
        public override void Notify()
        {
            AlienGrid pGrid = (AlienGrid)this.pSubject.pObjA;

            WallCategory pWall = (WallCategory)this.pSubject.pObjB;
            if (pWall.GetCategoryType() == WallCategory.Type.Right)
            {
                pGrid.SetDelta(-2.0f);
            }
            else if (pWall.GetCategoryType() == WallCategory.Type.Left)
            {
                pGrid.SetDelta(2.0f);
            }
            else
            {
                Debug.Assert(false);
            }

        }
    }
}
