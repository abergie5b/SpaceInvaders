
namespace SpaceInvaders
{
    public abstract class DLink
    {
        public DLink pNext;
        public DLink pPrev;

        protected DLink()
        {
            this.Clear();
        }

        public static DLink AddToFront(ref DLink pHead, DLink pNode)
        {
            if (pHead == null)
            {
                pHead = pNode;
                pNode.pNext = null;
                pNode.pPrev = null;
            }
            else
            {
                pNode.pPrev = null;
                pNode.pNext = pHead;

                pHead.pPrev = pNode;
                pHead = pNode;
            }
            return pNode;
        }

        public void Clear()
        {
            this.pNext = null;
            this.pPrev = null;
        }

        public static void RemoveNode(ref DLink pHead, DLink pNode)
        {
            if (pNode.pPrev != null)
            {	
                pNode.pPrev.pNext = pNode.pNext;
            }

            else
            {
                pHead = pNode.pNext;
            }

            if (pNode.pNext != null)
            {
                pNode.pNext.pPrev = pNode.pPrev;
            }

            pNode.Clear();
        }
    }
}
