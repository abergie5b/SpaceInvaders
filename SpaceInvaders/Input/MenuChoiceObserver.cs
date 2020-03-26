using System;

namespace SpaceInvaders
{
    class MenuChoiceObserver: InputObserver
    {
        public MenuChoiceObserver(Font pFont)
        {
            this.pFont = pFont;
        }

        override public void Notify(float xCurs, float yCurs)
        {
            if (ColRect.Intersect(this.pFont.pFontSprite.pColRect, new ColRect(xCurs, yCurs, 1, 1)))
                SceneContext.SetState(SceneContext.Scene.Select);
        }

        override public void Notify()
        {

        }

        private Font pFont;
    }
}
