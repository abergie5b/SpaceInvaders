
namespace SpaceInvaders
{
    class HighScoresChoiceObserver: InputObserver
    {
        public HighScoresChoiceObserver(Font pFont)
        {
            this.pFont = pFont;
        }

        override public void Notify(float xCurs, float yCurs)
        {
            if (ColRect.Intersect(this.pFont.pFontSprite.pColRect, new ColRect(xCurs, yCurs, 1, 1)))
            {
                SceneContext.SetState(SceneContext.Scene.HighScore);
                SceneContext.GetState().Initialize();
                SoundMan.PlaySound(Sound.Name.Shoot);
            }
        }

        override public void Notify()
        {

        }
        private Font pFont;

    }
}
