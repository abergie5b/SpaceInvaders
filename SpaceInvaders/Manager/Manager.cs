
namespace SpaceInvaders
{
    public abstract class Manager
    {
        protected int mNumActive;
        protected int nNumReserved;
        protected int nGrowthSize;
        protected int mDeltaGrow;

        protected DLink pActive;
        protected DLink pReserve;

        protected Manager()
        {
            nNumReserved = 0;
            nGrowthSize = 0;
            pReserve = null;
            pActive = null;
            mNumActive = 0;
            mDeltaGrow = 0;
            FillReserveListIfEmpty(nNumReserved);
        }

        protected Manager(int _nNumReserved, int _nGrowthSize)
        {
            nNumReserved = _nNumReserved;
            nGrowthSize = _nGrowthSize;
            pReserve = null;
            pActive = null;
            mNumActive = 0;
            mDeltaGrow = 0;
            FillReserveListIfEmpty(nNumReserved);
        }

        abstract protected DLink derivedCreateNode();
        abstract protected bool derivedCompare(DLink nodeA, DLink nodeB);
        abstract protected void derivedWash(DLink node);

        protected void FillReserveListIfEmpty(int n)
        {
            if (pReserve == null)
            {
                pReserve = this.derivedCreateNode();
                DLink head = pReserve;
                for (int x = 0; x < n - 1; x++)
                {
                    pReserve.pNext = this.derivedCreateNode();
                    pReserve.pNext.pPrev = pReserve;
                    pReserve = pReserve.pNext;
                }
                pReserve = head;
                nNumReserved = n;
            }
        }

        public DLink AddAfter(ref DLink node)
        {
            if (node == null)
            {
                return null;
            }

            FillReserveListIfEmpty(nGrowthSize);
            if (pReserve != null)
                pReserve.pPrev = null;

            DLink nNode = pReserve;
            pReserve = pReserve.pNext;

            DLink head = pActive;
            if (node == pActive)
            {
                nNode.pNext = pActive.pNext;
                if (pActive.pNext != null)
                {
                    pActive.pNext.pPrev = nNode;
                }

                nNode.pPrev = pActive;
                pActive.pNext = nNode;
            }

            else if (node.pNext == null)
            {
                node.pNext = nNode;
                nNode.pPrev = node;
                nNode.pNext = null;
            }

            else
            {
                node.pNext.pPrev = nNode;
                nNode.pNext = node.pNext;
                node.pNext = nNode;
                nNode.pPrev = node;
            }

            pActive = head;
            ++mNumActive;
            --nNumReserved;
            return nNode;
        }

        public DLink AddBefore(ref DLink node)
        {
            if (node == null || baseFind(node) == null)
            {
                return null;
            }

            FillReserveListIfEmpty(nGrowthSize);
            if (pReserve != null)
                pReserve.pPrev = null;

            DLink nNode = pReserve;
            pReserve = pReserve.pNext;

            DLink head = pActive;
            if (node == pActive)
            {
                return AddToFront();
            }

            else
            {
                node.pPrev.pNext = nNode;
                nNode.pPrev = node.pPrev;
                node.pPrev = nNode;
                nNode.pNext = node;
                ++mNumActive;
                --nNumReserved;
            }

            pActive = head;
            return nNode;
        }

        public DLink AddToBack()
        {
            FillReserveListIfEmpty(nGrowthSize);
            if (pReserve != null)
                pReserve.pPrev = null;

            DLink node = pReserve;
            pReserve = pReserve.pNext;

            DLink head = pActive;
            while (pActive.pNext != null)
            {
                pActive = pActive.pNext;
            }

            node.pPrev = pActive;
            node.pNext = null;
            pActive.pNext = node;
            pActive = head;
            ++mNumActive;
            --nNumReserved;
            return node;
        }

        public DLink baseAdd()
        {
            return AddToFront();
        }

        public DLink AddToFront()
        {
            FillReserveListIfEmpty(nGrowthSize);
            if (pReserve != null)
                pReserve.pPrev = null;

            DLink node = pReserve;
            this.derivedWash(node);

            pReserve = pReserve.pNext;
            node.pNext = null;
            node.pPrev = null;

            node = DLink.AddToFront(ref pActive, node);
            pActive = node;

            ++mNumActive;
            --nNumReserved;
            return node;
        }

        public DLink baseFind(DLink pTarget)
        {
            DLink head = pActive;
            while (head != null)
            {
                if (this.derivedCompare(head, pTarget))
                {
                    return head;
                }
                head = head.pNext;
            }
            return null;
        }

        public void baseInitialize(int _nNumReserved, int _nGrowthSize)
        {
            nNumReserved = _nNumReserved;
            nGrowthSize = _nGrowthSize;
            pReserve = null;
            pActive = null;
            mNumActive = 0;
            mDeltaGrow = 0;
            FillReserveListIfEmpty(nNumReserved);
        }

        protected void baseSetReserve(int reserveNum, int reserveGrow)
        {
            this.mDeltaGrow = reserveGrow;

            if (reserveNum > this.nNumReserved)
            {
                // Preload the reserve
                this.FillReserveListIfEmpty(reserveNum - this.nNumReserved);
            }
        }

        public DLink baseGetActive()
        {
            return pActive;
        }

        public DLink baseRemove(DLink node)
        {
            if (node == null)
                return null;
            if (pActive is null)
                return null;

            DLink.RemoveNode(ref pActive, node);
            this.derivedWash(node);

            --mNumActive;
            ++nNumReserved;
            return node;
        }
    }
}

