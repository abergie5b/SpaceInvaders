using System;

namespace SpaceInvaders
{
    class MultiPlayerChoiceObserver: InputObserver
    {
        public MultiPlayerChoiceObserver(Font pFont)
        {
            this.pFont = pFont;
        }


        override public void Notify(float xCurs, float yCurs)
        {
            if (ColRect.Intersect(this.pFont.pFontSprite.pColRect, new ColRect(xCurs, yCurs, 1, 1)))
            {
                PlayerMan.SetNPlayers(2);
                SceneContext.SetState(SceneContext.Scene.MultiPlay);
                SoundMan.PlaySound(Sound.Name.Shoot);
            }
        }

        override public void Notify()
        {

        }

        private Font pFont;

    }
}
