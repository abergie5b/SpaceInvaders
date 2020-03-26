using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class InputObserver : DLink
    {
        abstract public void Notify();
        virtual public void Notify(float xCurs, float yCurs) { }

        public InputSubject pSubject;
    }
}
