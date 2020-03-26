using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    //---------------------------------------------------------------------------------------------------------
    // Design Notes:
    //---------------------------------------------------------------------------------------------------------
    abstract public class GameObjectMan_MLink : Manager
    {
        public GameObjectNode_Link poActive;
        public GameObjectNode_Link poReserve;
    }
    public class GameObjectMan : GameObjectMan_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public GameObjectMan(int reserveNum = 3, int reserveGrow = 1)
        : base() // <--- Kick the can (delegate)
        {
            // At this point ImageMan is created, now initialize the reserve
            this.baseInitialize(reserveNum, reserveGrow);

            // initialize derived data here
            this.poNodeCompare = new GameObjectNode();
            this.poNullGameObject = new NullGameObject();
            GameObjectMan.pActiveGOMan = null;

            this.poNodeCompare.poGameObj = this.poNullGameObject; ;
        }


        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static GameObjectMan Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(GameObjectMan.pActiveGOMan == null);

            // Do the initialization
            if (GameObjectMan.pActiveGOMan == null)
            {
                GameObjectMan.pActiveGOMan = new GameObjectMan(reserveNum, reserveGrow);
            }
            return GameObjectMan.pActiveGOMan;
        }

        public static GameObjectMan GetActive()
        {
            return GameObjectMan.pActiveGOMan;
        }

        public static void SetActive(GameObjectMan pGOMan)
        {
            Debug.Assert(pGOMan != null);
            GameObjectMan.pActiveGOMan = pGOMan;
        }

        public static void Destroy()
        {

        }

        public static GameObjectNode Attach(GameObject pGameObject)
        {
            GameObjectMan pMan = GameObjectMan.privGetInstance();
            Debug.Assert(pMan != null);

            GameObjectNode pNode = (GameObjectNode)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(pGameObject);
            return pNode;
        }

        public static GameObject Find(GameObject.Name name)
        {
            GameObjectMan pMan = GameObjectMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes
            pMan.poNodeCompare.poGameObj.name = name;

            GameObjectNode pNode = (GameObjectNode)pMan.baseFind(pMan.poNodeCompare);
            Debug.Assert(pNode != null);

            return pNode.poGameObj;
        }

        public static void Remove(GameObject pNode)
        {
            Debug.Assert(pNode != null);
            GameObjectMan pMan = GameObjectMan.privGetInstance();

            GameObject pSafetyNode = pNode;

            GameObject pTmp = pNode;
            GameObject pRoot = null;
            while (pTmp != null)
            {
                pRoot = pTmp;
                pTmp = (GameObject)Iterator.GetParent(pTmp);
            }

            GameObjectNode pTree = (GameObjectNode)pMan.baseGetActive();

            while (pTree != null)
            {
                if (pTree.poGameObj == pRoot)
                {
                    break;
                }
                pTree = (GameObjectNode)pTree.pNext;
            }

            Debug.Assert(pTree != null);
            Debug.Assert(pTree.poGameObj != null);

            if (pTree.poGameObj == pNode)
                return;
            Debug.Assert(pTree.poGameObj != pNode);

            GameObject pParent = (GameObject)Iterator.GetParent(pNode);
            Debug.Assert(pParent != null);

            GameObject pChild = (GameObject)Iterator.GetChild(pNode);
            Debug.Assert(pChild == null);

            pParent.Remove(pNode);
            pParent.Update();

            // TODO - Recycle pNode
        }

        public static void Update()
        {
            GameObjectMan pMan = GameObjectMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Debug.WriteLine("---------------");

            GameObjectNode pGameObjectNode = (GameObjectNode)pMan.baseGetActive();

            while (pGameObjectNode != null)
            {
                ReverseIterator pRev = new ReverseIterator(pGameObjectNode.poGameObj);

                Component pNode = pRev.First();
                while (!pRev.IsDone())
                {
                    GameObject pGameObj = (GameObject)pNode;

                    pGameObj.Update();
                    pNode = pRev.Next();
                }

                pGameObjectNode = (GameObjectNode)pGameObjectNode.pNext;
            }

        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new GameObjectNode();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected Boolean derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            GameObjectNode pDataA = (GameObjectNode)pLinkA;
            GameObjectNode pDataB = (GameObjectNode)pLinkB;

            Boolean status = false;

            if (pDataA.poGameObj.GetName() == pDataB.poGameObj.GetName() && !pDataB.poGameObj.bMarkForDeath && !pDataA.poGameObj.bMarkForDeath)
            {
                status = true;
            }

            return status;
        }
        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameObjectNode pNode = (GameObjectNode)pLink;
            pNode.Wash();
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static GameObjectMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(GameObjectMan.pActiveGOMan != null);

            return GameObjectMan.pActiveGOMan;
        }

        //----------------------------------------------------------------------
        // Data - unique data for this manager 
        //----------------------------------------------------------------------
        private GameObjectNode poNodeCompare;
        private readonly NullGameObject poNullGameObject;
        private static GameObjectMan pActiveGOMan;
    }
}
