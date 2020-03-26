using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneAlien : SceneState
    {
        public SceneAlien()
        {
            this.Initialize();
        }
        public override void Handle()
        {

        }
        public override void Initialize()
        {
            ImageMan.Add(Image.Name.BlueAlien, Texture.Name.Aliens, new Azul.Rect(341, 337, 65, 64));
            ImageMan.Add(Image.Name.GreenAlien, Texture.Name.Aliens, new Azul.Rect(27, 337, 79, 64));
            ImageMan.Add(Image.Name.RedAlien, Texture.Name.Aliens, new Azul.Rect(647, 200, 72, 65));

            ImageMan.Add(Image.Name.UFO, Texture.Name.Aliens, new Azul.Rect(120, 489, 98, 49));
            ImageMan.Add(Image.Name.Ship, Texture.Name.Birds, new Azul.Rect(10, 93, 30, 18));

            ImageMan.Add(Image.Name.Brick, Texture.Name.Birds, new Azul.Rect(20, 210, 10, 5));
            ImageMan.Add(Image.Name.BrickLeft_Top0, Texture.Name.Birds, new Azul.Rect(15, 180, 10, 5));
            ImageMan.Add(Image.Name.BrickLeft_Top1, Texture.Name.Birds, new Azul.Rect(15, 185, 10, 5));
            ImageMan.Add(Image.Name.BrickLeft_Bottom, Texture.Name.Birds, new Azul.Rect(35, 215, 10, 5));
            ImageMan.Add(Image.Name.BrickRight_Top0, Texture.Name.Birds, new Azul.Rect(75, 180, 10, 5));
            ImageMan.Add(Image.Name.BrickRight_Top1, Texture.Name.Birds, new Azul.Rect(75, 185, 10, 5));
            ImageMan.Add(Image.Name.BrickRight_Bottom, Texture.Name.Birds, new Azul.Rect(55, 215, 10, 5));

            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poGameObjectMan = new GameObjectMan(10, 2);
            GameObjectMan.SetActive(this.poGameObjectMan);

            this.poFontMan = new FontMan();
            FontMan.SetActive(this.poFontMan);

            this.poInputMan = new InputMan();
            InputMan.SetActive(this.poInputMan);

            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts, 100, true);
            SpriteBatch pSB_Shields = SpriteBatchMan.Add(SpriteBatch.Name.Shields, 100, true);
            SpriteBatch pSB_Aliens = SpriteBatchMan.Add(SpriteBatch.Name.Aliens, 100, true);
            SpriteBatch pSB_Boxes = SpriteBatchMan.Add(SpriteBatch.Name.Boxes, 100, false);

            GameSpriteMan.Add(GameSprite.Name.BlueAlien, Image.Name.BlueAlien, 100, 150, 30, 30);
            GameSpriteMan.Add(GameSprite.Name.RedAlien, Image.Name.RedAlien, 200, 150, 30, 30);
            GameSpriteMan.Add(GameSprite.Name.GreenAlien, Image.Name.GreenAlien, 300, 150, 30, 30);
            GameSpriteMan.Add(GameSprite.Name.UFO, Image.Name.UFO, 120, 489, 70, 25);
            GameSpriteMan.Add(GameSprite.Name.Ship, Image.Name.Ship, 500, 100, 60, 20);

            GameSpriteMan.Add(GameSprite.Name.Brick, Image.Name.Brick, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_LeftTop0, Image.Name.BrickLeft_Top0, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_LeftTop1, Image.Name.BrickLeft_Top1, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_LeftBottom, Image.Name.BrickLeft_Bottom, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_RightTop0, Image.Name.BrickRight_Top0, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_RightTop1, Image.Name.BrickRight_Top1, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_RightBottom, Image.Name.BrickRight_Bottom, 50, 25, 10, 5);

            AlienFactory aF = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);
            Texture pTexture = TextureMan.Add(Texture.Name.Consolas36pt, "Consolas36pt.tga");
            GlyphMan.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            Font pFont = FontMan.Add(Font.Name.TestMessage, SpriteBatch.Name.Texts, "Aliens", Glyph.Name.Consolas36pt, 100, 500);
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            RedAlien redAlien = (RedAlien)aF.Create(GameObject.Name.RedAlien, AlienCategory.Type.Red, 300.0f, 200.0f);
            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, redAlien.GetPoints().ToString(), Glyph.Name.Consolas20pt, 375.0f, 200.0f);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            GreenAlien greenAlien = (GreenAlien)aF.Create(GameObject.Name.GreenAlien, AlienCategory.Type.Green, 300.0f, 275.0f);
            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, greenAlien.GetPoints().ToString(), Glyph.Name.Consolas20pt, 375.0f, 275.0f);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            BlueAlien blueAlien = (BlueAlien)aF.Create(GameObject.Name.BlueAlien, AlienCategory.Type.Blue, 300.0f, 350.0f);
            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, blueAlien.GetPoints().ToString(), Glyph.Name.Consolas20pt, 375.0f, 350.0f);
            pFont.SetColor(0.60f, 0.60f, 0.60f);

            UFO ufo = new UFO(GameObject.Name.UFO, GameSprite.Name.UFO, 300.0f, 425.0f);
            ufo.ActivateGameSprite(pSB_Aliens);
            GameObjectMan.Attach(ufo);
            pFont = FontMan.Add(Font.Name.Instructions, SpriteBatch.Name.Texts, "?", Glyph.Name.Consolas20pt, 375.0f, 425.0f);
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
            GameObjectMan.SetActive(this.poGameObjectMan);
            FontMan.SetActive(this.poFontMan);
            InputMan.SetActive(this.poInputMan);
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public GameObjectMan poGameObjectMan;
        public InputMan poInputMan;
        public FontMan poFontMan;
    }
}
