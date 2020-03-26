using System;

namespace SpaceInvaders
{
    public class ScenePlay : SceneState
    {
        public ScenePlay()
        {
            this.Initialize();
        }
        public ScenePlay(int nNumPlayers)
        {
            this.Initialize();
        }
        public override void Handle()
        {

        }
 
        public override void Initialize()
        {
            Random pRandom = new Random();

            //---------------------------------------------------------------------------------------------------------
            // Images
            //---------------------------------------------------------------------------------------------------------
            ImageMan.Add(Image.Name.BlueAlien, Texture.Name.Aliens, new Azul.Rect(341, 337, 65, 64));
            ImageMan.Add(Image.Name.BlueAlien2, Texture.Name.Aliens, new Azul.Rect(464, 65, 64, 63));
            ImageMan.Add(Image.Name.GreenAlien, Texture.Name.Aliens, new Azul.Rect(27, 337, 79, 64));
            ImageMan.Add(Image.Name.GreenAlien2, Texture.Name.Aliens, new Azul.Rect(253, 64, 84, 65));
            ImageMan.Add(Image.Name.RedAlien, Texture.Name.Aliens, new Azul.Rect(647, 200, 72, 65));
            ImageMan.Add(Image.Name.RedAlien2, Texture.Name.Aliens, new Azul.Rect(26, 201, 94, 65));
            ImageMan.Add(Image.Name.Explosion, Texture.Name.Aliens, new Azul.Rect(488, 488, 75, 48));
            ImageMan.Add(Image.Name.Explosion_Ground, Texture.Name.Aliens, new Azul.Rect(328, 489, 84, 48));
            ImageMan.Add(Image.Name.UFO, Texture.Name.Aliens, new Azul.Rect(120, 489, 98, 49));

            ImageMan.Add(Image.Name.Missile, Texture.Name.Aliens, new Azul.Rect(267, 501, 9, 34));
            ImageMan.Add(Image.Name.Ship, Texture.Name.Birds, new Azul.Rect(10, 93, 30, 18));

            ImageMan.Add(Image.Name.Wall, Texture.Name.Birds, new Azul.Rect(40, 185, 20, 10));
            ImageMan.Add(Image.Name.WallBottom, Texture.Name.Birds, new Azul.Rect(40, 185, 20, 1));

            ImageMan.Add(Image.Name.BombStraight, Texture.Name.Birds, new Azul.Rect(110, 100, 7, 49));
            ImageMan.Add(Image.Name.BombZigZag, Texture.Name.Birds, new Azul.Rect(132, 100, 20, 50));
            ImageMan.Add(Image.Name.BombCross, Texture.Name.Birds, new Azul.Rect(219, 103, 19, 47));

            ImageMan.Add(Image.Name.Brick, Texture.Name.Birds, new Azul.Rect(20, 210, 10, 5));
            ImageMan.Add(Image.Name.BrickLeft_Top0, Texture.Name.Birds, new Azul.Rect(15, 180, 10, 5));
            ImageMan.Add(Image.Name.BrickLeft_Top1, Texture.Name.Birds, new Azul.Rect(15, 185, 10, 5));
            ImageMan.Add(Image.Name.BrickLeft_Bottom, Texture.Name.Birds, new Azul.Rect(35, 215, 10, 5));
            ImageMan.Add(Image.Name.BrickRight_Top0, Texture.Name.Birds, new Azul.Rect(75, 180, 10, 5));
            ImageMan.Add(Image.Name.BrickRight_Top1, Texture.Name.Birds, new Azul.Rect(75, 185, 10, 5));
            ImageMan.Add(Image.Name.BrickRight_Bottom, Texture.Name.Birds, new Azul.Rect(55, 215, 10, 5));

            //---------------------------------------------------------------------------------------------------------
            // Game Sprites
            //---------------------------------------------------------------------------------------------------------
            GameSpriteMan.Add(GameSprite.Name.BlueAlien, Image.Name.BlueAlien, 100, 150, 30, 30);
            GameSpriteMan.Add(GameSprite.Name.RedAlien, Image.Name.RedAlien, 200, 150, 30, 30);
            GameSpriteMan.Add(GameSprite.Name.GreenAlien, Image.Name.GreenAlien, 300, 150, 30, 30);
            GameSpriteMan.Add(GameSprite.Name.UFO, Image.Name.UFO, 120, 489, 70, 25);
            GameSpriteMan.Add(GameSprite.Name.Explosion_Ground, Image.Name.Explosion_Ground, 328, 489, 30, 20);
            GameSpriteMan.Add(GameSprite.Name.Explosion, Image.Name.Explosion, 120, 489, 30, 20);

            GameSpriteMan.Add(GameSprite.Name.Missile, Image.Name.Missile, -100, -100, 3, 12);
            GameSpriteMan.Add(GameSprite.Name.Ship, Image.Name.Ship, 500, 100, 60, 20);
            GameSpriteMan.Add(GameSprite.Name.ShipInactive, Image.Name.Ship, 500, 100, 60, 20);
            GameSpriteMan.Add(GameSprite.Name.Wall, Image.Name.Wall, 448, 900, 850, 30);
            GameSpriteMan.Add(GameSprite.Name.WallBottom, Image.Name.WallBottom, 448, 900, 850, 1);

            GameSpriteMan.Add(GameSprite.Name.BombZigZag, Image.Name.BombZigZag, 200, 200, 8, 25);
            GameSpriteMan.Add(GameSprite.Name.BombStraight, Image.Name.BombStraight, 110, 100, 8, 25);
            GameSpriteMan.Add(GameSprite.Name.BombDagger, Image.Name.BombCross, 100, 100, 8, 25);

            GameSpriteMan.Add(GameSprite.Name.Brick, Image.Name.Brick, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_LeftTop0, Image.Name.BrickLeft_Top0, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_LeftTop1, Image.Name.BrickLeft_Top1, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_LeftBottom, Image.Name.BrickLeft_Bottom, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_RightTop0, Image.Name.BrickRight_Top0, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_RightTop1, Image.Name.BrickRight_Top1, 50, 25, 10, 5);
            GameSpriteMan.Add(GameSprite.Name.Brick_RightBottom, Image.Name.BrickRight_Bottom, 50, 25, 10, 5);

            BoxSpriteMan.Add(BoxSprite.Name.Box1, 550.0f, 500.0f, 50.0f, 150.0f, new Azul.Color(1.0f, 1.0f, 1.0f, 1.0f));
            BoxSpriteMan.Add(BoxSprite.Name.Box2, 550.0f, 100.0f, 50.0f, 100.0f);

            this.poSpriteBatchMan = new SpriteBatchMan(3, 1);
            SpriteBatchMan.SetActive(this.poSpriteBatchMan);

            this.poGameObjectMan = new GameObjectMan(10, 2);
            GameObjectMan.SetActive(this.poGameObjectMan);

            this.poInputMan = new InputMan();
            InputMan.SetActive(this.poInputMan);

            this.poTimerMan = new TimerMan();
            TimerMan.SetActive(this.poTimerMan);

            //---------------------------------------------------------------------------------------------------------
            // SpriteBatches
            //---------------------------------------------------------------------------------------------------------
            SpriteBatch pSB_Box = SpriteBatchMan.Add(SpriteBatch.Name.Boxes, 100, false);
            SpriteBatch pSB_Texts = SpriteBatchMan.Add(SpriteBatch.Name.Texts, 100, true);
            SpriteBatch pSB_Shields = SpriteBatchMan.Add(SpriteBatch.Name.Shields, 100, true);
            SpriteBatch pSB_Aliens = SpriteBatchMan.Add(SpriteBatch.Name.Aliens, 100, true);
            SpriteBatch pSB_Bombs = SpriteBatchMan.Add(SpriteBatch.Name.Bombs, 100, true);

            //---------------------------------------------------------------------------------------------------------
            // Ship
            //---------------------------------------------------------------------------------------------------------
            ShipRoot pShipRoot = new ShipRoot(GameObject.Name.ShipRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            GameObjectMan.Attach(pShipRoot);
            Ship pShip = ShipMan.CreateShip();

            //---------------------------------------------------------------------------------------------------------
            // Player
            //---------------------------------------------------------------------------------------------------------
            Player pPlayer = PlayerMan.GetCurrentPlayer(pShip);
            pShip.SetPlayer(pPlayer);

            //---------------------------------------------------------------------------------------------------------
            // Aliens
            //---------------------------------------------------------------------------------------------------------
            AlienFactory aF = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);
            // Do this somewhere else ..
            int yPos = 475;
            if (pPlayer.nCurrLevel == 2)
                yPos -= 40;
            AlienGrid pGrid = aF.CreateGrid(200, yPos);
            float pGridDelta = 0.2f;
            if (pPlayer.nCurrLevel == 2)
                pGridDelta = 0.3f;

            //---------------------------------------------------------------------------------------------------------
            // Missile
            //---------------------------------------------------------------------------------------------------------
            MissileGroup pMissileGroup = new MissileGroup(GameObject.Name.MissileGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pMissileGroup.ActivateGameSprite(pSB_Aliens);
            GameObjectMan.Attach(pMissileGroup);

            //---------------------------------------------------------------------------------------------------------
            // Bomb
            //---------------------------------------------------------------------------------------------------------
            BombRoot pBombRoot = new BombRoot(GameObject.Name.BombRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pBombRoot.ActivateCollisionSprite(pSB_Box);
            pBombRoot.ActivateGameSprite(pSB_Bombs);
            GameObjectMan.Attach(pBombRoot);

            //---------------------------------------------------------------------------------------------------------
            // Input
            //---------------------------------------------------------------------------------------------------------
            InputSubject pInputSubject;
            pInputSubject = InputMan.GetArrowRightSubject();
            pInputSubject.Attach(new MoveRightObserver(pShip));

            pInputSubject = InputMan.GetArrowLeftSubject();
            pInputSubject.Attach(new MoveLeftObserver(pShip));

            pInputSubject = InputMan.GetSpaceSubject();
            pInputSubject.Attach(new ShootObserver(pShip));

            pInputSubject = InputMan.GetPeriodSubject();
            pInputSubject.Attach(new ToggleRenderBoxSpriteObserver());

            pInputSubject = InputMan.GetCommaSubject();
            pInputSubject.Attach(new ToggleShieldBricksObserver());

            //---------------------------------------------------------------------------------------------------------
            // Walls
            //---------------------------------------------------------------------------------------------------------
            WallGroup pWallGroup = new WallGroup(GameObject.Name.WallGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pWallGroup.ActivateGameSprite(pSB_Aliens);

            WallTop pWallTop = new WallTop(GameObject.Name.WallTop, GameSprite.Name.Wall, 400, 750, 700, 15);
            pWallTop.ActivateCollisionSprite(pSB_Aliens);

            WallBottom pWallBottom = new WallBottom(GameObject.Name.WallBottom, GameSprite.Name.WallBottom, 400, 30, 850, 1);
            pWallBottom.ActivateCollisionSprite(pSB_Box);
            pWallBottom.ActivateGameSprite(pSB_Aliens);

            WallLeft pWallLeft = new WallLeft(GameObject.Name.WallLeft, GameSprite.Name.Wall, 0, 300, 15, 600);
            pWallLeft.ActivateCollisionSprite(pSB_Box);

            WallRight pWallRight = new WallRight(GameObject.Name.WallRight, GameSprite.Name.Wall, 800, 300, 15, 600);
            pWallRight.ActivateCollisionSprite(pSB_Box);

            pWallGroup.Add(pWallTop);
            pWallGroup.Add(pWallBottom);
            pWallGroup.Add(pWallRight);
            pWallGroup.Add(pWallLeft);
            GameObjectMan.Attach(pWallGroup);

            //---------------------------------------------------------------------------------------------------------
            // Shield 
            //---------------------------------------------------------------------------------------------------------
            ShieldFactory SF = new ShieldFactory(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, GameObject.Name.ShieldRoot1);
            Composite pShieldRoot1 = SF.CreateShield(50.0f, 100.0f);
            GameObjectMan.Attach(pShieldRoot1);

            SF = new ShieldFactory(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, GameObject.Name.ShieldRoot2);
            Composite pShieldRoot2 = SF.CreateShield(200.0f, 100.0f);
            GameObjectMan.Attach(pShieldRoot2);

            SF = new ShieldFactory(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, GameObject.Name.ShieldRoot3);
            Composite pShieldRoot3 = SF.CreateShield(500.0f, 100.0f);
            GameObjectMan.Attach(pShieldRoot3);

            SF = new ShieldFactory(SpriteBatch.Name.Shields, SpriteBatch.Name.Boxes, GameObject.Name.ShieldRoot4);
            Composite pShieldRoot4 = SF.CreateShield(650.0f, 100.0f);
            GameObjectMan.Attach(pShieldRoot4);

            //---------------------------------------------------------------------------------------------------------
            // Collision Observers 
            //---------------------------------------------------------------------------------------------------------
            ColPair pColPair;
            // Missile vs Wall
            pColPair = ColPairMan.Add(ColPair.Name.Missile_Wall, pMissileGroup, pWallGroup);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new ShipReadyObserver(pShip));

            // Bomb vs Bottom
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Wall, pBombRoot, pWallGroup);
            pColPair.Attach(new RemoveBombObserver());

            // Bomb vs Missile
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Missile, pBombRoot, pMissileGroup);
            pColPair.Attach(new RemoveMissileAndBombObserver());
            pColPair.Attach(new ShipReadyObserver(pShip));

            // Bomb vs Shields
            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Shield1, pBombRoot, pShieldRoot1);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveBrickObserver());

            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Shield2, pBombRoot, pShieldRoot2);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveBrickObserver());

            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Shield3, pBombRoot, pShieldRoot3);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveBrickObserver());

            pColPair = ColPairMan.Add(ColPair.Name.Bomb_Shield4, pBombRoot, pShieldRoot4);
            pColPair.Attach(new RemoveBombObserver());
            pColPair.Attach(new RemoveBrickObserver());

            // Missile vs Shields
            pColPair = ColPairMan.Add(ColPair.Name.Missile_Shield1, pMissileGroup, pShieldRoot1);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveBrickObserver());
            pColPair.Attach(new ShipReadyObserver(pShip));

            pColPair = ColPairMan.Add(ColPair.Name.Missile_Shield2, pMissileGroup, pShieldRoot2);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveBrickObserver());
            pColPair.Attach(new ShipReadyObserver(pShip));

            pColPair = ColPairMan.Add(ColPair.Name.Missile_Shield3, pMissileGroup, pShieldRoot3);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveBrickObserver());
            pColPair.Attach(new ShipReadyObserver(pShip));

            pColPair = ColPairMan.Add(ColPair.Name.Missile_Shield4, pMissileGroup, pShieldRoot4);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveBrickObserver());
            pColPair.Attach(new ShipReadyObserver(pShip));

            // Alien Grid vs Shields
            pColPair = ColPairMan.Add(ColPair.Name.AlienGrid_Shield1, pGrid, pShieldRoot1);
            pColPair.Attach(new RemoveBrickObserver());

            pColPair = ColPairMan.Add(ColPair.Name.AlienGrid_Shield2, pGrid, pShieldRoot2);
            pColPair.Attach(new RemoveBrickObserver());

            pColPair = ColPairMan.Add(ColPair.Name.AlienGrid_Shield3, pGrid, pShieldRoot3);
            pColPair.Attach(new RemoveBrickObserver());

            pColPair = ColPairMan.Add(ColPair.Name.AlienGrid_Shield4, pGrid, pShieldRoot4);
            pColPair.Attach(new RemoveBrickObserver());

            // Missile vs Alien 
            pColPair = ColPairMan.Add(ColPair.Name.Alien_Missile, pMissileGroup, pGrid);
            pColPair.Attach(new RemoveMissileObserver());
            pColPair.Attach(new RemoveAlienObserver());
            pColPair.Attach(new ShipReadyObserver(pShip));

            // Alien Grid vs WallLeft
            pColPair = ColPairMan.Add(ColPair.Name.AlienGrid_WallLeft, pGrid, pWallLeft);
            pColPair.Attach(new AlienGridWallLeftObserver(pGridDelta));

            // Alien Grid vs WallRight
            pColPair = ColPairMan.Add(ColPair.Name.AlienGrid_WallRight, pGrid, pWallRight);
            pColPair.Attach(new AlienGridWallRightObserver(pGridDelta));

            // Alien Grid vs WallBottom
            pColPair = ColPairMan.Add(ColPair.Name.AlienGrid_WallBottom, pGrid, pWallBottom);
            pColPair.Attach(new AlienGridWallBottomObserver());

            // Ship vs Bomb
            pColPair = ColPairMan.Add(ColPair.Name.ShipBomb, pShipRoot, pBombRoot);
            pColPair.Attach(new BombObserver());

            //---------------------------------------------------------------------------------------------------------
            // Alien Animations
            //---------------------------------------------------------------------------------------------------------
            RedAlienAnimationCommand pRedAlienAnimation = new RedAlienAnimationCommand(GameSprite.Name.RedAlien);
            pRedAlienAnimation.Attach(Image.Name.RedAlien);
            pRedAlienAnimation.Attach(Image.Name.RedAlien2);
            TimerMan.Add(TimeEvent.Name.RedAlienAnimation, pRedAlienAnimation, 1.0f);

            BlueAlienAnimationCommand pBlueAlienAnimation = new BlueAlienAnimationCommand(GameSprite.Name.BlueAlien);
            pBlueAlienAnimation.Attach(Image.Name.BlueAlien);
            pBlueAlienAnimation.Attach(Image.Name.BlueAlien2);
            TimerMan.Add(TimeEvent.Name.BlueAlienAnimation, pBlueAlienAnimation, 1.0f);

            GreenAlienAnimationCommand pGreenAlienAnimation = new GreenAlienAnimationCommand(GameSprite.Name.GreenAlien);
            pGreenAlienAnimation.Attach(Image.Name.GreenAlien);
            pGreenAlienAnimation.Attach(Image.Name.GreenAlien2);
            TimerMan.Add(TimeEvent.Name.GreenAlienAnimation, pGreenAlienAnimation, 1.0f);

            //---------------------------------------------------------------------------------------------------------
            // Alien Bomb Spawns
            //---------------------------------------------------------------------------------------------------------
            BombSpawnEvent pBombSpawn = new BombSpawnEvent(pPlayer.nCurrLevel, pRandom);
            TimerMan.Add(TimeEvent.Name.BombSpawn, pBombSpawn, pRandom.Next(1, 10));

            //---------------------------------------------------------------------------------------------------------
            // Scene Play Sound
            //---------------------------------------------------------------------------------------------------------
            ScenePlaySoundCommand pScenePlaySound = new ScenePlaySoundCommand();
            pScenePlaySound.Attach(Sound.Name.Invader1);
            pScenePlaySound.Attach(Sound.Name.Invader2);
            pScenePlaySound.Attach(Sound.Name.Invader3);
            pScenePlaySound.Attach(Sound.Name.Invader4);
            TimerMan.Add(TimeEvent.Name.ScenePlaySound, pScenePlaySound, 1.0f);

            //---------------------------------------------------------------------------------------------------------
            // UFO
            //---------------------------------------------------------------------------------------------------------
            float value = pRandom.Next(10, 60);
            SpawnUFOCommand pUFO = new SpawnUFOCommand(pRandom, pWallLeft, pWallRight);
            TimerMan.Add(TimeEvent.Name.UFO, pUFO, value);

            //---------------------------------------------------------------------------------------------------------
            // Texts
            //---------------------------------------------------------------------------------------------------------
            Texture pTexture = TextureMan.Add(Texture.Name.Consolas36pt, "Consolas20pt.tga");
            GlyphMan.AddXml(Glyph.Name.Consolas20pt, "Consolas20pt.xml", Texture.Name.Consolas20pt);

            Font pFont = FontMan.Add(Font.Name.Credits00, SpriteBatch.Name.Texts, "CREDIT 00", Glyph.Name.Consolas20pt, 700, 15);
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pFont = FontMan.Add(Font.Name.Score1, SpriteBatch.Name.Texts, "SCORE <1>", Glyph.Name.Consolas20pt, 150, 585);
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            Player pPlayer1 = PlayerMan.GetPlayer(1);
            string pPlayer1Score;
            if (pPlayer1 != null)
                pPlayer1Score = pPlayer1.nPoints.ToString();
            else
                pPlayer1Score = "0";
            pFont = FontMan.Add(Font.Name.Score1Value, SpriteBatch.Name.Texts, pPlayer1Score, Glyph.Name.Consolas20pt, 150, 550);
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pFont = FontMan.Add(Font.Name.HighScore, SpriteBatch.Name.Texts, "HIGH SCORE", Glyph.Name.Consolas20pt, 400, 585);
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            HighScore hS = new HighScore();
            pFont = FontMan.Add(Font.Name.HighScores, SpriteBatch.Name.Texts, hS.GetScore().ToString(), Glyph.Name.Consolas20pt, 400, 550);
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pFont = FontMan.Add(Font.Name.Score2, SpriteBatch.Name.Texts, "SCORE <2>", Glyph.Name.Consolas20pt, 650, 585);
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            Player pPlayer2 = PlayerMan.GetPlayer(2);
            string pPlayer2Score;
            if (pPlayer2 != null)
                pPlayer2Score = pPlayer2.nPoints.ToString();
            else
                pPlayer2Score = "0";
            pFont = FontMan.Add(Font.Name.Score2Value, SpriteBatch.Name.Texts, pPlayer2Score, Glyph.Name.Consolas20pt, 650, 550);
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            // Life Totals
            pFont = FontMan.Add(Font.Name.NumLives1, SpriteBatch.Name.Texts, pPlayer.nLives.ToString(), Glyph.Name.Consolas20pt, 15, 15);
            pFont.SetColor(1.0f, 1.0f, 1.0f);

            pShip = ShipMan.CreateInactiveShip(75, 15);
            pShip = ShipMan.CreateInactiveShip(150, 15);
        }

        public override void Update(float systemTime)
        {
            InputMan.Update();

            TimerMan.Update(systemTime);

            ColPairMan.Process();

            GameObjectMan.Update();

            DelayedObjectMan.Process();
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
            TimerMan.SetActive(this.poTimerMan);
        }

        // ---------------------------------------------------
        // Data
        // ---------------------------------------------------
        public SpriteBatchMan poSpriteBatchMan;
        public GameObjectMan poGameObjectMan;
        public InputMan poInputMan;
        public TimerMan poTimerMan;
    }
}
