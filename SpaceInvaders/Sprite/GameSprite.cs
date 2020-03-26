using System.Diagnostics;

namespace SpaceInvaders
{
    //---------------------------------------------------------------------------------------------------------
    // Design Notes:
    //
    //  Only "new" happens in the default constructor Sprite()
    //
    //  Managers - create a pool of them...
    //  Add - Takes one and reuses it by using Set() 
    //
    //---------------------------------------------------------------------------------------------------------
    abstract public class GameSprite_Base : SpriteBase
    {

    }
    public class GameSprite : GameSprite_Base
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Name
        {
            RedAlien,
            YellowAlien,
            GreenAlien,
            WhiteAlien,
            BlueAlien,
            AlienGrid,
            AlienColumn,
            UFO,
            Logo,

            Ship,
            ShipInactive,
            Wall,
            WallLeft,
            WallTop,
            WallRight,
            WallBottom,
            Missile,

            BombStraight,
            BombZigZag,
            BombDagger,

            Brick,
            Brick_LeftTop0,
            Brick_LeftTop1,
            Brick_LeftBottom,
            Brick_RightTop0,
            Brick_RightTop1,
            Brick_RightBottom,

            Explosion,
            Explosion_Ground,
            NullObject,
            Uninitialized
        }

        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public GameSprite()
            : base()
        {
            this.name = GameSprite.Name.Uninitialized;

            this.pImage = ImageMan.Find(Image.Name.Default);
            Debug.Assert(this.pImage != null);

            this.poScreenRect = new Azul.Rect();
            Debug.Assert(this.poScreenRect != null);
            this.poScreenRect.Clear();

            this.poAzulColor = new Azul.Color(1, 1, 1);
            Debug.Assert(this.poAzulColor != null);

            this.poAzulSprite = new Azul.Sprite(pImage.GetAzulTexture(), pImage.GetAzulRect(), this.poScreenRect, psTmpColor);
            Debug.Assert(this.poAzulSprite != null);

            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;
        }

        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void Set(GameSprite.Name name, Image pImage, float x, float y, float width, float height, Azul.Color pColor)
        {
            Debug.Assert(pImage != null);
            Debug.Assert(this.poScreenRect != null);
            Debug.Assert(this.poAzulSprite != null);

            this.poScreenRect.Set(x, y, width, height);
            this.pImage = pImage;
            this.name = name;

            if (pColor == null)
            {
                Debug.Assert(GameSprite.psTmpColor != null);
                GameSprite.psTmpColor.Set(1, 1, 1);

                this.poAzulColor.Set(psTmpColor);
            }
            else
            {
                this.poAzulColor.Set(pColor);
            }

            this.poAzulSprite.Swap(pImage.GetAzulTexture(), pImage.GetAzulRect(), this.poScreenRect, this.poAzulColor);

            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;
        }
        private void privClear()   
        {
            this.pImage = null;
            this.name = GameSprite.Name.Uninitialized;

            // NOTE:
            // Do not clear the poAzulSprite it is created once in Default then reused

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }
        public void Wash()
        {
            this.privClear();
        }
        public void SwapColor(Azul.Color _pColor)
        {
            Debug.Assert(_pColor != null);
            Debug.Assert(this.poAzulColor != null);
            Debug.Assert(this.poAzulSprite != null);
            this.poAzulColor.Set(_pColor);
            this.poAzulSprite.SwapColor(_pColor);
        }
        public void SwapColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.poAzulColor != null);
            Debug.Assert(this.poAzulSprite != null);
            this.poAzulColor.Set(red, green, blue, alpha);
            this.poAzulSprite.SwapColor(this.poAzulColor);
        }
        public void SwapImage(Image pNewImage)
        {
            Debug.Assert(this.poAzulSprite != null);
            Debug.Assert(pNewImage != null);
            this.pImage = pNewImage;

            this.poAzulSprite.SwapTexture(this.pImage.GetAzulTexture());
            this.poAzulSprite.SwapTextureRect(this.pImage.GetAzulRect());
        }
        public void SetName(GameSprite.Name inName)
        {
            this.name = inName;
        }
        public GameSprite.Name GetName()
        {
            return this.name;
        }
        public Azul.Rect GetScreenRect()
        {
            Debug.Assert(this.poScreenRect != null);
            return this.poScreenRect;
        }
       
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public override void Update()
        {
            this.poAzulSprite.x = this.x;
            this.poAzulSprite.y = this.y;
            this.poAzulSprite.sx = this.sx;
            this.poAzulSprite.sy = this.sy;
            this.poAzulSprite.angle = this.angle;

            this.poAzulSprite.Update();
        }

        public override void Render()
        {
            this.poAzulSprite.Render();
        }

        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------

        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        private Name name;
        private Image pImage;
        private readonly Azul.Color poAzulColor;
        private Azul.Sprite poAzulSprite;
        private readonly Azul.Rect poScreenRect;

        //---------------------------------------------------------------------------------------------------------
        // Static Data - prevent unecessary "new" in the above methods
        //---------------------------------------------------------------------------------------------------------
        static private Azul.Color psTmpColor = new Azul.Color(1, 1, 1);
    }
}

// End of file
