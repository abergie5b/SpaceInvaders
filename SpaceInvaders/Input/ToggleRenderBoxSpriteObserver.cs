using System;

namespace SpaceInvaders
{
    class ToggleRenderBoxSpriteObserver: InputObserver
    {
        override public void Notify()
        {
            SpriteBatch sb_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            sb_Boxes.bRenderEnabled = !sb_Boxes.bRenderEnabled;
        }

    }
}
