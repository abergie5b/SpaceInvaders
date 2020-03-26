
namespace SpaceInvaders
{
    public class ExitObserver : InputObserver
    {
        public ExitObserver(Font pFont)
        {
            this.pFont = pFont;
        }

        override public void Notify()
        {

        }

        public override void Notify(float xCurs, float yCurs)
        {
            if (ColRect.Intersect(this.pFont.pFontSprite.pColRect, new ColRect(xCurs, yCurs, 1, 1)))
            {
                // there is a better way
                // do something clever here
                System.Environment.Exit(0);
            }
        }
        Font pFont;
    }
}
