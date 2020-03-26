using System;

namespace SpaceInvaders
{
    class CreditsChoiceObserver: InputObserver
    {
        public CreditsChoiceObserver(Font pFont)
        {
            this.pFont = pFont;
        }


        override public void Notify(float xCurs, float yCurs)
        {
            if (ColRect.Intersect(this.pFont.pFontSprite.pColRect, new ColRect(xCurs, yCurs, 1, 1)))
            {
                SceneContext.SetState(SceneContext.Scene.Credits);
                SoundMan.PlaySound(Sound.Name.Shoot);
            }
        }

        override public void Notify()
        {

        }
        private Font pFont;

    }
}
