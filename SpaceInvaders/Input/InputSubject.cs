using System;
using System.Diagnostics;


namespace SpaceInvaders
{
    public class InputSubject
    {
        public Font pObja;
        public Font pObjb;

        public InputSubject()
        {
            this.pObja = null;
            this.pObjb = null;
        }

        public InputSubject(Font a)
        {
            this.pObja = a;
            this.pObjb = null;
        }

        public void Attach(InputObserver observer)
        {
            // protection
            Debug.Assert(observer != null);

            observer.pSubject = this;

            // add to front
            if (head == null)
            {
                head = observer;
                observer.pNext = null;
                observer.pPrev = null;
            }
            else
            {
                observer.pNext = head;
                observer.pPrev = null;
                head.pPrev = observer;
                head = observer;
            }
        }

        public void Notify(float xCurs, float yCurs)
        {
            InputObserver pNode = this.head;

            while (pNode != null)
            {
                // Fire off listener
                pNode.Notify(xCurs, yCurs);

                pNode = (InputObserver)pNode.pNext;
            }
        }

        public void Notify()
        {
            InputObserver pNode = this.head;

            while (pNode != null)
            {
                // Fire off listener
                pNode.Notify();

                pNode = (InputObserver)pNode.pNext;
            }
        }

        public void Detach()
        {
        }


        // Data: ------------------------
        private InputObserver head;



    }
}
