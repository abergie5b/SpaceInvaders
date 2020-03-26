using System;

namespace SpaceInvaders
{
    class SinglePlayerChoiceObserver: InputObserver
    {
        public SinglePlayerChoiceObserver(Font pFont)
        {
            this.pFont = pFont;
        }

        override public void Notify(float xCurs, float yCurs)
        {

            if (ColRect.Intersect(this.pFont.pFontSprite.pColRect, new ColRect(xCurs, yCurs, 1, 1)))
            {
                PlayerMan.SetNPlayers(1);
                SceneContext.SetState(SceneContext.Scene.SinglePlay);
                SoundMan.PlaySound(Sound.Name.Shoot);
            }
        }

        override public void Notify()
        {

        }

        private Font pFont;

    }
}
