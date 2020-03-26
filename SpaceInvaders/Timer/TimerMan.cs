using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TimerMan : Manager
    {
        public TimerMan(int reserveNum = 3, int reserveGrow = 1)
        : base()
        {
            this.baseInitialize(reserveNum, reserveGrow);
            this.poNodeCompare = new TimeEvent();
        }

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            Debug.Assert(pInstance == null);

            if (pInstance == null)
            {
                pInstance = new TimerMan(reserveNum, reserveGrow);
            }
        }
        public static TimeEvent Add(TimeEvent.Name timeName, Command pCommand, float deltaTimeToTrigger)
        {
            TimerMan pMan = TimerMan.privGetInstance();
            Debug.Assert(pMan != null);

            TimeEvent pNode = (TimeEvent)pMan.baseAdd();
            Debug.Assert(pNode != null);

            Debug.Assert(pCommand != null);
            Debug.Assert(deltaTimeToTrigger >= 0.0f);

            pNode.Set(timeName, pCommand, deltaTimeToTrigger);
            return pNode;
        }
        public static TimeEvent Find(TimeEvent.Name name)
        {
            TimerMan pMan = TimerMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pMan.poNodeCompare != null);
            pMan.poNodeCompare.Wash();
            pMan.poNodeCompare.SetName(name);

            TimeEvent pData = (TimeEvent)pMan.baseFind(pMan.poNodeCompare);
            return pData;
        }

        public static void Remove(TimeEvent pNode)
        {
            TimerMan pMan = TimerMan.privGetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
        }

        public static void Update(float totalTime)
        {
            TimerMan pMan = TimerMan.privGetInstance();
            Debug.Assert(pMan != null);

            pMan.mCurrTime = totalTime;

            TimeEvent pEvent = (TimeEvent)pMan.baseGetActive();
            TimeEvent pNextEvent = null;

            while (pEvent != null)// && (pMan.mCurrTime >= pEvent.triggerTime))
            {
                pNextEvent = (TimeEvent)pEvent.pNext;

                if (pMan.mCurrTime >= pEvent.triggerTime)
                {
                    pEvent.Process();

                    pMan.baseRemove(pEvent);
                }

                pEvent = pNextEvent;
            }
        }

        public static float GetCurrTime()
        {
            TimerMan pTimerMan = TimerMan.privGetInstance();

            return pTimerMan.mCurrTime;
        }

        override protected DLink derivedCreateNode()
        {
            DLink pNode = new TimeEvent();
            Debug.Assert(pNode != null);

            return pNode;
        }
        override protected Boolean derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            Debug.Assert(pLinkA != null);
            Debug.Assert(pLinkB != null);

            TimeEvent pDataA = (TimeEvent)pLinkA;
            TimeEvent pDataB = (TimeEvent)pLinkB;

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
            TimeEvent pNode = (TimeEvent)pLink;
            pNode.Wash();
        }

        private static TimerMan privGetInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        public static void SetActive(TimerMan pMan)
        {
            TimerMan.pInstance = pMan;
        }

        private static TimerMan pInstance = null;
        private TimeEvent poNodeCompare;
        protected float mCurrTime;
    }

}
