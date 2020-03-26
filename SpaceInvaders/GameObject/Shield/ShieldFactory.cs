using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShieldFactory
    {
        public ShieldFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name collisionSpriteBatch, GameObject.Name shieldRootName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionSpriteBatch = SpriteBatchMan.Find(collisionSpriteBatch);
            Debug.Assert(this.pCollisionSpriteBatch != null);

            this.pTree = (Composite)new ShieldRoot(shieldRootName, GameSprite.Name.NullObject, 0.0f, 0.0f);
        }
        public void SetParent(GameObject pParentNode)
        {
            // OK being null
            Debug.Assert(pParentNode != null);
            this.pTree = (Composite)pParentNode;
        }
        ~ShieldFactory()
        {
            this.pSpriteBatch = null;
        }

        public Composite CreateShield(float start_x, float start_y)
        {
            Composite pShieldRoot = this.pTree;
            int j = 0;

            GameObject pColumn;
            SetParent(pShieldRoot);
            pColumn = Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

            SetParent(pColumn);

            float off_x = 0;
            float brickWidth = 10.0f;
            float brickHeight = 5.0f;

            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 2 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 3 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 4 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 5 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 6 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x, start_y + 7 * brickHeight);
            Create(ShieldCategory.Type.LeftTop1, GameObject.Name.ShieldBrick, start_x, start_y + 8 * brickHeight);
            Create(ShieldCategory.Type.LeftTop0, GameObject.Name.ShieldBrick, start_x, start_y + 9 * brickHeight);

            SetParent(pShieldRoot);
            pColumn = Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

            SetParent(pColumn);

            off_x += brickWidth;
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

            SetParent(pShieldRoot);
            pColumn = Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

            SetParent(pColumn);

            off_x += brickWidth;
            Create(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

            SetParent(pShieldRoot);
            pColumn = Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

            SetParent(pColumn);

            off_x += brickWidth;
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

            SetParent(pShieldRoot);
            pColumn = Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

            SetParent(pColumn);

            off_x += brickWidth;
            Create(ShieldCategory.Type.RightBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

            SetParent(pShieldRoot);
            pColumn = Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

            SetParent(pColumn);

            off_x += brickWidth;
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 0 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 1 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

            SetParent(pShieldRoot);
            pColumn = Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

            SetParent(pColumn);

            off_x += brickWidth;
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 0 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 1 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight);
            Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight);
            Create(ShieldCategory.Type.RightTop1, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight);
            Create(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight);

            return pShieldRoot;
        }

        public GameObject Create(ShieldCategory.Type type, GameObject.Name gameName, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pShield = null;

            switch (type)
            {
                case ShieldCategory.Type.Brick:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick, posX, posY);
                    break;

                case ShieldCategory.Type.LeftTop1:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_LeftTop1, posX, posY);
                    break;

                case ShieldCategory.Type.LeftTop0:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_LeftTop0, posX, posY);
                    break;

                case ShieldCategory.Type.LeftBottom:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_LeftBottom, posX, posY);
                    break;

                case ShieldCategory.Type.RightTop1:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_RightTop1, posX, posY);
                    break;

                case ShieldCategory.Type.RightTop0:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_RightTop0, posX, posY);
                    break;

                case ShieldCategory.Type.RightBottom:
                    pShield = new ShieldBrick(gameName, GameSprite.Name.Brick_RightBottom, posX, posY);
                    break;

                case ShieldCategory.Type.Root:
                    pShield = new ShieldRoot(gameName, GameSprite.Name.NullObject, posX, posY);
                    pShield.SetCollisionColor(0.0f, 0.0f, 1.0f);
                    Debug.Assert(false);
                    break;

                case ShieldCategory.Type.Grid:
                    pShield = new ShieldGrid(gameName, GameSprite.Name.NullObject, posX, posY);
                    pShield.SetCollisionColor(0.0f, 0.0f, 1.0f);
                    break;

                case ShieldCategory.Type.Column:
                    pShield = new ShieldColumn(gameName, GameSprite.Name.NullObject, posX, posY);
                    pShield.SetCollisionColor(1.0f, 0.0f, 0.0f);
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }

            // add to the tree
            this.pTree.Add(pShield);

            // Attached to Group
            pShield.ActivateGameSprite(this.pSpriteBatch);
            pShield.ActivateCollisionSprite(this.pCollisionSpriteBatch);

            return pShield;
        }

        // Data: ---------------------
        private SpriteBatch pSpriteBatch;
        private readonly SpriteBatch pCollisionSpriteBatch;
        private Composite pTree;
    }
}

// End of File
