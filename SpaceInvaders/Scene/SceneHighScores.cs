using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneHighScores : SceneState
    {
        public SceneHighScores()
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

            this.poFontMan = new FontMan();
            FontMan.SetActive(this.poFontMan);

            this.poInputMan = new InputMan();
            InputMan.SetActive(this.poInputMan);

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts, 100, true);

            HighScore hS = new HighScore();

            Texture pTexture = TextureMan.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphMan.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            Font pFont = FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, "High Score", Glyph.Name.Consolas36pt, 100, 500);
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pFont = FontMan.Add(Font.Name.HighScores, SpriteBatch.Name.Texts, hS.GetScore().ToString(), Glyph.Name.Consolas20pt, 100, 400);
            pFont.SetColor(0.40f, 0.40f, 0.40f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Back to Menu", Glyph.Name.Consolas20pt, 100, 100);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            InputSubject pInputSubject = InputMan.GetCursorSubject();
            pInputSubject.Attach(new HighlightHoverTextObserver(pFont));
            pInputSubject = InputMan.GetMouseLeftKeySubject();
            pInputSubject.Attach(new MenuChoiceObserver(pFont));

        }

        public override void Update(float systemTime)
        {
            InputMan.Update();
        }

        public override void Draw()
        {
            SpriteBatchMan.Draw();
        }

        public override void Transition()
        {
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);
            FontMan.SetActive(this.poFontMan);
            InputMan.SetActive(this.poInputMan);
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public InputMan poInputMan;
        public FontMan poFontMan;
    }
}
