using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneInstructions : SceneState
    {
        public SceneInstructions()
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

            Texture pTexture = TextureMan.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphMan.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            Font pFont = FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "Instructions", Glyph.Name.Consolas36pt, 100, 500);
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Player One", Glyph.Name.Consolas20pt, 100, 450);
            pFont.SetColor(0.80f, 0.80f, 0.80f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Move Left: ", Glyph.Name.Consolas20pt, 100, 400);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Left Arrow Key", Glyph.Name.Consolas20pt, 225, 400);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Move Right: ", Glyph.Name.Consolas20pt, 100, 350);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Right Arrow Key", Glyph.Name.Consolas20pt, 225, 350);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Shoot: ", Glyph.Name.Consolas20pt, 100, 300);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Spacebar", Glyph.Name.Consolas20pt, 175, 300);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Player Two", Glyph.Name.Consolas20pt, 500, 450);
            pFont.SetColor(0.80f, 0.80f, 0.80f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Move Left: ", Glyph.Name.Consolas20pt, 500, 400);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "A", Glyph.Name.Consolas20pt, 625, 400);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Move Right: ", Glyph.Name.Consolas20pt, 500, 350);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "D", Glyph.Name.Consolas20pt, 625, 350);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Shoot: ", Glyph.Name.Consolas20pt, 500, 300);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "S", Glyph.Name.Consolas20pt, 625, 300);
            pFont.SetColor(0.60f, 0.60f, 0.60f);


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
            InputMan.SetActive(this.poInputMan);
            FontMan.SetActive(this.poFontMan);
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public InputMan poInputMan;
        public FontMan poFontMan;
    }
}
