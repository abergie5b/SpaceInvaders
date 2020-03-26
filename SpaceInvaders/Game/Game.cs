/*

1. Drop random powerups for the ship
2. Ship move up and down? Maybe?
3. Charge shots can kill multiple aliens
4. Unlockable ships
5. 

*/

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {

        public override void Initialize()
        {
            this.SetWindowName("Space Invaders");
            this.SetWidthHeight(800, 600);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }

        public override void LoadContent()
        {
            //---------------------------------------------------------------------------------------------------------
            // Setup Managers - once here
            //---------------------------------------------------------------------------------------------------------
            TimerMan.Create(3, 1);
            TextureMan.Create(1, 1);
            TextureMan.Add(Texture.Name.Aliens, "Aliens.tga");
            TextureMan.Add(Texture.Name.Birds, "Birds_N_Shield.tga");
            TextureMan.Add(Texture.Name.Birds2, "Birds_N_Shield.tga");

            //---------------------------------------------------------------------------------------------------------
            // Sounds
            //---------------------------------------------------------------------------------------------------------
            SoundMan.Create();
            SoundMan.Add(Sound.Name.Explode, "explosion.wav");
            SoundMan.Add(Sound.Name.Shoot, "shoot.wav");
            SoundMan.Add(Sound.Name.Invader1, "fastinvader1.wav");
            SoundMan.Add(Sound.Name.Invader2, "fastinvader2.wav");
            SoundMan.Add(Sound.Name.Invader3, "fastinvader3.wav");
            SoundMan.Add(Sound.Name.Invader4, "fastinvader4.wav");
            SoundMan.Add(Sound.Name.InvaderKilled, "invaderkilled.wav");
            SoundMan.Add(Sound.Name.UFOLow, "ufo_lowpitch.wav");
            SoundMan.Add(Sound.Name.UFOHigh, "ufo_highpitch.wav");

            ImageMan.Create(5, 2);
            ImageMan.Add(Image.Name.Default, Texture.Name.Aliens, new Azul.Rect(0, 0, 0, 0));
            ImageMan.Add(Image.Name.NullObject, Texture.Name.Aliens, new Azul.Rect(0, 0, 0, 0));

            GameSpriteMan.Create(25, 5);
            BoxSpriteMan.Create(25, 5);

            SpriteBatchMan.Create(5, 2);

            ProxySpriteMan.Create(10, 1);
            GameObjectMan.Create(50, 5);
            ColPairMan.Create(25, 5);
            GlyphMan.Create(5, 2);
            FontMan.Create(5, 2);
            ShipMan.Create();

            PlayerMan.Create();
            SceneContext.Create();
        }

        public override void Update()
        {
            SceneContext.GetState().Update(this.GetTime());
        }

        public override void Draw()
        {
            SceneContext.GetState().Draw();
        }

        public override void UnLoadContent()
        {

        }

    }
}

