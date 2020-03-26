using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ProxySpriteMan : Manager
    {
        private ProxySpriteMan(int reserveNum = 3, int reserveGrow = 1)
        : base() // <--- Kick the can (delegate)
        {
            // At this point ImageMan is created, now initialize the reserve
            this.baseInitialize(reserveNum, reserveGrow);

            // initialize derived data here
            this.poNodeCompare = new ProxySprite();
        }

        ~ProxySpriteMan()
        {

        }

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new ProxySpriteMan(reserveNum, reserveGrow);
            }
        }

        public static void Destroy()
        {

        }

        public static ProxySprite Add(GameSprite.Name name)
        {
            ProxySpriteMan pMan = ProxySpriteMan.privGetInstance();
            Debug.Assert(pMan != null);

            ProxySprite pNode = (ProxySprite)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.Set(name);

            return pNode;
        }

        public static ProxySprite Find(ProxySprite.Name name)
        {
            ProxySpriteMan pMan = ProxySpriteMan.privGetInstance();
            Debug.Assert(pMan != null);

            // Compare functions only compares two Nodes

            // So:  Use the Compare Node - as a reference
            //      use in the Compare() function
            pMan.poNodeCompare.SetName(name);

            ProxySprite pData = (ProxySprite)pMan.baseFind(pMan.poNodeCompare);
            return pData;
        }

        public static void Remove(GameSprite pNode)
        {
            ProxySpriteMan pMan = ProxySpriteMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
        }

        override protected DLink derivedCreateNode()
        {
            DLink pNode = new ProxySprite();
            Debug.Assert(pNode != null);

            return pNode;
        }

        override protected Boolean derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            // This is used in baseFind() 
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            ProxySprite pDataA = (ProxySprite)pLinkA;
            ProxySprite pDataB = (ProxySprite)pLinkB;

            Boolean status = false;

            if (pDataA.GetName() == pDataB.GetName())
            {
                status = true;
            }

            return status;
        }

        override protected void derivedWash(DLink pLink)
        {
            Debug.Assert(pLink != null);
            ProxySprite pNode = (ProxySprite)pLink;
            pNode.Wash();
        }

        private static ProxySpriteMan privGetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        private static ProxySpriteMan pInstance = null;
        private ProxySprite poNodeCompare;
    }

}
