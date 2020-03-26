using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteBatchMan : Manager
    {
        private static SpriteBatch pNodeCompare;
        private static SpriteBatchMan pActiveSBMan;

        public SpriteBatchMan(int _mNumReserved, int _nGrowthSize)
            : base()
        {
            this.baseInitialize(_mNumReserved, _nGrowthSize);
            SpriteBatchMan.pNodeCompare = new SpriteBatch();
            SpriteBatchMan.pActiveSBMan = null;
        }

        private SpriteBatchMan()
        : base()
        {
            SpriteBatchMan.pActiveSBMan = null;
            SpriteBatchMan.pNodeCompare = new SpriteBatch();
        }

        public static void Remove(SpriteNode pSpriteBatchNode)
        {
            SpriteNodeMan pSpriteNodeMan = pSpriteBatchNode.pBackSpriteNodeMan;
            Debug.Assert(pSpriteNodeMan != null);
            pSpriteNodeMan.Remove(pSpriteBatchNode);
        }

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new SpriteBatch();
            return pNode;
        }

        protected override bool derivedCompare(DLink nodeA, DLink nodeB)
        {
            SpriteBatch pA = (SpriteBatch) nodeA;
            SpriteBatch pB = (SpriteBatch) nodeB;
            if (pA.name == pB.name)
                return true;
            return false;
        }

        protected override void derivedWash(DLink node)
        {
            SpriteBatch pNode = (SpriteBatch) node;
            pNode.Wash();
        }

        public static void SetActive(SpriteBatchMan pSBMan)
        {
            Debug.Assert(pSBMan != null);
            SpriteBatchMan.pActiveSBMan = pSBMan;
        }

        public static SpriteBatchMan GetActive()
        {
            return SpriteBatchMan.pActiveSBMan;
        }

        public static void SetPriority(SpriteBatch.Name group, int key)
        {
            SpriteBatchMan.pNodeCompare.SetName(group);
            SpriteBatch node = (SpriteBatch)SpriteBatchMan.pActiveSBMan.baseFind(SpriteBatchMan.pNodeCompare);
            node.SetPriority(key);
            SpriteBatchMan.pActiveSBMan.PrioritySort();
        }

        private void PrioritySort()
        {
            SpriteBatch head = (SpriteBatch)SpriteBatchMan.pActiveSBMan.pActive;
            SpriteBatch next;
            SpriteNodeMan tmpNodeMan;
            int tmpKey;
            SpriteBatch.Name tmpName;
            while (head != null)
            {
                next = (SpriteBatch) head.pNext;
                if (next != null && head.key < next.key)
                {
                    tmpNodeMan = head.pSpriteNodeMan;
                    tmpKey = head.key;
                    tmpName = head.name;
                    head.pSpriteNodeMan = next.pSpriteNodeMan;
                    head.key = next.key;
                    head.name = next.name;
                    next.pSpriteNodeMan = tmpNodeMan;
                    next.key = tmpKey;
                    next.name = tmpName;
                    head = (SpriteBatch) SpriteBatchMan.pActiveSBMan.pActive;
                }
                else
                    head = (SpriteBatch)head.pNext;
            }
        }

        public static void Create(int reserved, int growth)
        {
            if (SpriteBatchMan.pActiveSBMan == null)
                SpriteBatchMan.pActiveSBMan = new SpriteBatchMan(reserved, growth);
        }

        public static SpriteBatch Add(SpriteBatch.Name name, int _key, bool _bRenderEnabled, int _mNumReserved=5, int _nGrowthSize=2)
        {
            SpriteBatch head = (SpriteBatch)SpriteBatchMan.pActiveSBMan.pActive;
            SpriteBatch batch = null;
            if (head == null)
            {
                batch = (SpriteBatch)SpriteBatchMan.pActiveSBMan.baseAdd();
            }
            else
            {
                while (head != null)
                {
                    if (head.key <= _key)
                    {
                        DLink dHead = head;
                        batch = (SpriteBatch) SpriteBatchMan.pActiveSBMan.AddBefore(ref dHead);
                        break;
                    }

                    if (head.pNext == null)
                    {
                        DLink dHead = head;
                        batch = (SpriteBatch) SpriteBatchMan.pActiveSBMan.AddAfter(ref dHead);
                        break;
                    }
                    head = (SpriteBatch)head.pNext;
                }
            }
            batch.Initialize(name, _key, _bRenderEnabled, _mNumReserved, _nGrowthSize);
            return batch;
        }

        public static SpriteBatch Find(SpriteBatch.Name name)
        {
            SpriteBatchMan.pNodeCompare.SetName(name);
            SpriteBatch sprite = (SpriteBatch) SpriteBatchMan.pActiveSBMan.baseFind(SpriteBatchMan.pNodeCompare);
            return sprite;
        }

        public static void Draw()
        {
            SpriteBatch pSpriteBatch = (SpriteBatch)SpriteBatchMan.pActiveSBMan.baseGetActive();

            while (pSpriteBatch != null)
            {
                if (pSpriteBatch.bRenderEnabled == true)
                {
                    SpriteNodeMan pSBNodeMan = pSpriteBatch.GetSpriteNodeMan();
                    Debug.Assert(pSBNodeMan != null);
                    pSBNodeMan.Draw();
                }
                pSpriteBatch = (SpriteBatch)pSpriteBatch.pNext;
            }
        }

    }
}
