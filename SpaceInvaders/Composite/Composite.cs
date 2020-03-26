using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Composite : GameObject
    {
        public Composite(GameObject.Name gameName, GameSprite.Name spriteName)
            : base(gameName, spriteName)
        {
            this.holder = Container.COMPOSITE;
            this.poHead = null;
            this.poLast = null;
        }

        override public Component GetFirstChild()
        {
            DLink pNode = this.poHead;

            // Sometimes it returns null... that's ok
            // Scenario - we have a group without a child
            // i.e. composite with no children
            // Debug.Assert(pNode != null);

            return (Component)pNode;
        }

        override public void Add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            DLink.AddToFront(ref this.poHead, pComponent);
            pComponent.pParent = this;
        }

        override public void Remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            DLink.RemoveNode(ref this.poHead, pComponent);
        }

        public override void Print()
        {
            DLink pNode = this.poHead;

            while (pNode != null)
            {
                Component pComponent = (Component)pNode;
                pComponent.Print();

                pNode = pNode.pNext;
            }

        }

        public DLink poHead;
        public DLink poLast;

    }
}
