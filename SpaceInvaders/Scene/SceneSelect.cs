
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneSelect : SceneState
    {
        public SceneSelect()
        {
            this.Initialize();
        }

        public override void Handle()
        {
            Debug.WriteLine("Handle");
        }

        public override void Initialize()
        {
            ImageMan.Add(Image.Name.Logo, Texture.Name.Aliens, new Azul.Rect(24, 78, 85, 40));
            GameSpriteMan.Add(GameSprite.Name.Logo, Image.Name.Logo, 200, 350, 180, 90);

            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poGameObjectMan = new GameObjectMan(10, 2);
            GameObjectMan.SetActive(this.poGameObjectMan);

            this.poInputMan = new InputMan();
            InputMan.SetActive(this.poInputMan);

            this.poFontMan = new FontMan();
            FontMan.SetActive(this.poFontMan);

            this.poTimerMan = new TimerMan();
            TimerMan.SetActive(this.poTimerMan);

            SpriteBatch pSB_texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts, 100, true);

            Logo logo = new Logo(GameObject.Name.Logo, GameSprite.Name.Logo, 400, 400);
            logo.ActivateGameSprite(pSB_texts);
            GameObjectMan.Attach(logo);

            Texture pTexture = TextureMan.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphMan.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            pTexture = TextureMan.Add(Texture.Name.Consolas20pt, "Consolas20pt.tga");
            GlyphMan.AddXml(Glyph.Name.Consolas20pt, "Consolas20pt.xml", Texture.Name.Consolas20pt);

            pTexture = TextureMan.Add(Texture.Name.Consolas20pt, "Consolas20pt.tga");
            GlyphMan.AddXml(Glyph.Name.NullObject, "Consolas20pt.xml", Texture.Name.Consolas20pt);

            Font pFont = FontMan.Add(Font.Name.SinglePlayer, SpriteBatch.Name.Texts, "Single Player", Glyph.Name.Consolas20pt, 200, 300);
            pFont.SetColor(0.60f, 0.60f, 0.60f);
            InputSubject pInputSubject = InputMan.GetCursorSubject();
            pInputSubject.Attach(new HighlightHoverTextObserver(pFont));
            pInputSubject = InputMan.GetMouseLeftKeySubject();
            pInputSubject.Attach(new SinglePlayerChoiceObserver(pFont));

            pFont = FontMan.Add(Font.Name.MultiPlayer, SpriteBatch.Name.Texts, "Multi Player", Glyph.Name.Consolas20pt, 200, 275);
            pFont.SetColor(0.60f, 0.60f, 0.60f);
            pInputSubject = InputMan.GetCursorSubject();
            pInputSubject.Attach(new HighlightHoverTextObserver(pFont));
            pInputSubject = InputMan.GetMouseLeftKeySubject();
            pInputSubject.Attach(new MultiPlayerChoiceObserver(pFont));

            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "Instructions", Glyph.Name.Consolas20pt, 200, 250);
            pFont.SetColor(0.60f, 0.60f, 0.60f);
            pInputSubject = InputMan.GetCursorSubject();
            pInputSubject.Attach(new HighlightHoverTextObserver(pFont));
            pInputSubject = InputMan.GetMouseLeftKeySubject();
            pInputSubject.Attach(new InstructionsChoiceObserver(pFont));

            pFont = FontMan.Add(Font.Name.HighScores, SpriteBatch.Name.Texts, "High Scores", Glyph.Name.Consolas20pt, 200, 225);
            pFont.SetColor(0.60f, 0.60f, 0.60f);
            pInputSubject = InputMan.GetCursorSubject();
            pInputSubject.Attach(new HighlightHoverTextObserver(pFont));
            pInputSubject = InputMan.GetMouseLeftKeySubject();
            pInputSubject.Attach(new HighScoresChoiceObserver(pFont));

            pFont = FontMan.Add(Font.Name.Aliens, SpriteBatch.Name.Texts, "Aliens", Glyph.Name.Consolas20pt, 200, 200);
            pFont.SetColor(0.60f, 0.60f, 0.60f);
            pInputSubject = InputMan.GetCursorSubject();
            pInputSubject.Attach(new HighlightHoverTextObserver(pFont));
            pInputSubject = InputMan.GetMouseLeftKeySubject();
            pInputSubject.Attach(new AliensChoiceObserver(pFont));

            pFont = FontMan.Add(Font.Name.Credits, SpriteBatch.Name.Texts, "Credits", Glyph.Name.Consolas20pt, 200, 175);
            pFont.SetColor(0.60f, 0.60f, 0.60f);
            pInputSubject = InputMan.GetCursorSubject();
            pInputSubject.Attach(new HighlightHoverTextObserver(pFont));
            pInputSubject = InputMan.GetMouseLeftKeySubject();
            pInputSubject.Attach(new CreditsChoiceObserver(pFont));

            pFont = FontMan.Add(Font.Name.Exit, SpriteBatch.Name.Texts, "Exit", Glyph.Name.Consolas20pt, 200, 150);
            pFont.SetColor(0.60f, 0.60f, 0.60f);
            pInputSubject = InputMan.GetCursorSubject();
            pInputSubject.Attach(new HighlightHoverTextObserver(pFont));
            pInputSubject = InputMan.GetMouseLeftKeySubject();
            pInputSubject.Attach(new ExitObserver(pFont));

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
            GameObjectMan.SetActive(this.poGameObjectMan);
            InputMan.SetActive(this.poInputMan);
            FontMan.SetActive(this.poFontMan);
            TimerMan.SetActive(this.poTimerMan);
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public GameObjectMan poGameObjectMan;
        public InputMan poInputMan;
        public FontMan poFontMan;
        public TimerMan poTimerMan;

    }
}
