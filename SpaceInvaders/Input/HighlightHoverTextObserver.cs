using System;

namespace SpaceInvaders
{
    class HighlightHoverTextObserver: InputObserver
    {
        public HighlightHoverTextObserver(Font pFont)
        {
            this.pState = false;
            this.pFont = pFont;
            this.pRandom = new Random();
        }

        override public void Notify(float xCurs, float yCurs)
        {
            var inter = ColRect.Intersect(this.pFont.pFontSprite.pColRect, new ColRect(xCurs, yCurs, 1, 1));
            if (!this.pState && inter)
            {
                Sound.Name sound = Sound.Name.Uninitialized;
                switch (this.pRandom.Next(0, 3))
                {
                    case (0):
                        sound = Sound.Name.Invader1;
                        break;
                    case (1):
                        sound = Sound.Name.Invader2;
                        break;
                    case (2):
                        sound = Sound.Name.Invader3;
                        break;
                    case (3):
                        sound = Sound.Name.Invader4;
                        break;
                }
                SoundMan.PlaySound(sound);
                this.pFont.SetColor(1.0f, 1.0f, 1.0f);
                this.pState = true;
            }
            else if (!inter)
            {
                this.pState = false;
                this.pFont.SetColor(0.60f, 0.60f, 0.60f);
            }
        }

        override public void Notify()
        {

        }

        private Font pFont;
        private Random pRandom;
        private bool pState;

    }
}
