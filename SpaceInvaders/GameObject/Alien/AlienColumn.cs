using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienColumn : Composite
    {
        public AlienColumn(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poColObj.pColSprite.SetLineColor(0, 0, 1);
        }

        public override void Accept(ColVisitor other)
        {
            // Important: at this point we have an AlienColumn
            // Call the appropriate collision reaction            
            other.VisitColumn(this);
        }

        public override void VisitMissileGroup(MissileGroup m)
        {
            // AlienColumn vs MissileGroup
            Debug.WriteLine("         collide:  {0} <-> {1}", m.name, this.name);

            // MissileGroup vs Columns
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            ColPair.Collide(m, pGameObj);
        }

        public override void Update()
        {
            // Debug.WriteLine("update: {0}", this);
            // Go to first child
            base.BaseUpdateBoundingBox(this);
            base.Update();
        }

        // Data

    }
}

