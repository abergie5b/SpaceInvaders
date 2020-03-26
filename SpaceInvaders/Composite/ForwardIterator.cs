using System.Diagnostics;

namespace SpaceInvaders
{
    public class ForwardIterator : Iterator
    {
        public ForwardIterator(Component pStart)
        {
            Debug.Assert(pStart != null);

            this.pCurr = pStart;
            this.pRoot = pStart;
        }

        private Component PrivNextStep(Component pNode, Component pParent, Component pChild, Component pSibling)
        {
            pNode = null;

            if (pChild != null)
            {
                pNode = pChild;
            }
            else
            {
                if ( pSibling != null )
                {
                    pNode = pSibling;
                }
                else
                {
                    while ( pParent != null )
                    {
                        pNode = GetSibling(pParent);
                        if( pNode != null )
                        {
                            break;
                        }
                        else
                        {
                            pParent = GetParent(pParent);
                        }
                    }
                }
            }

            return pNode;
        }

        override public Component First()
        {
            Debug.Assert(this.pRoot != null);
            Component pNode = this.pRoot;

            Debug.Assert(pNode != null);
            this.pCurr = pNode;

            return this.pCurr;
        }
        override public Component Next()
        {
            Debug.Assert(this.pCurr != null);

            Component pNode = this.pCurr;

            Component pChild = GetChild(pNode);
            Component pSibling = GetSibling(pNode);
            Component pParent = GetParent(pNode);

            pNode = PrivNextStep(pNode, pParent, pChild, pSibling);

            this.pCurr = pNode;

            return this.pCurr;
        }

        override public bool IsDone()
        {
            return (this.pCurr == null);
        }

        private Component pCurr;
        private readonly Component pRoot;

    }
}
