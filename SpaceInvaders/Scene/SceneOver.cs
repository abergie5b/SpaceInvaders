using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneOver : SceneState
    {
        public SceneOver()
        {
            this.Initialize();
        }
        public override void Handle()
        {

        }
        public override void Initialize()
        {
            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poInputMan = new InputMan();
            InputMan.SetActive(this.poInputMan);

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts, 100, true);

            Texture pTexture = TextureMan.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphMan.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            Font pFont = FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "GAME OVER", Glyph.Name.Consolas36pt, 100, 500);
            pFont.SetColor(1.0f, 1.0f, 1.0f);
        }
        public override void Update(float systemTime)
        {
            InputMan.Update();
            GameObjectMan.Update();
        }
        public override void Draw()
        {
            SpriteBatchMan.Draw();
        }
        public override void Transition()
        {
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            InputMan.SetActive(this.poInputMan);
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public InputMan poInputMan;
    }
}
