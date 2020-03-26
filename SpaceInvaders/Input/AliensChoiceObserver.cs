using System;

namespace SpaceInvaders
{
    class AliensChoiceObserver: InputObserver
    {
        public AliensChoiceObserver(Font pFont)
        {
            this.pFont = pFont;
        }


        override public void Notify(float xCurs, float yCurs)
        {
            if (ColRect.Intersect(this.pFont.pFontSprite.pColRect, new ColRect(xCurs, yCurs, 1, 1)))
            {
                SceneContext.SetState(SceneContext.Scene.Aliens);
                SoundMan.PlaySound(Sound.Name.Shoot);
            }
        }

        override public void Notify()
        {

        }
        private Font pFont;

    }
}
