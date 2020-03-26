using System.Diagnostics;

namespace SpaceInvaders
{
    class AlienFactory
    {
        public AlienFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxSpriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pBoxSpriteBatch = SpriteBatchMan.Find(boxSpriteBatchName);
            Debug.Assert(this.pBoxSpriteBatch != null);
        }

        ~AlienFactory()
        {

        }

        public AlienGrid CreateGrid(int xPos, int yPos)
        {
            AlienGrid pGrid = (AlienGrid)Create(GameObject.Name.AlienGrid, AlienCategory.Type.Grid, xPos, yPos);

            GameObject pGameObj;
            for (int i = 0; i < 11; i++)
            {
                GameObject pCol = Create(GameObject.Name.AlienColumn + i, AlienCategory.Type.Column, xPos, yPos);

                pGameObj = Create(GameObject.Name.BlueAlien, AlienCategory.Type.Blue, xPos + i * 50.0f, yPos);
                pCol.Add(pGameObj);

                pGameObj = Create(GameObject.Name.GreenAlien, AlienCategory.Type.Green, xPos + i * 50.0f, yPos-50);
                pCol.Add(pGameObj);

                pGameObj = Create(GameObject.Name.GreenAlien, AlienCategory.Type.Green, xPos + i * 50.0f, yPos-100);
                pCol.Add(pGameObj);

                pGameObj = Create(GameObject.Name.RedAlien, AlienCategory.Type.Red, xPos + i * 50.0f, yPos-150);
                pCol.Add(pGameObj);

                pGameObj = Create(GameObject.Name.RedAlien, AlienCategory.Type.Red, xPos + i * 50.0f, yPos-200);
                pCol.Add(pGameObj);

                pGrid.Add(pCol);
                pGrid.nNumActive += 5;
            }

            GameObjectMan.Attach(pGrid);
            return pGrid;
        }

        public GameObject Create(GameObject.Name name, AlienCategory.Type type, float posX=0.0f, float posY=0.0f)
        {
            GameObject pGameObj = null;

            switch (type)
            {
                case AlienCategory.Type.Green:
                    pGameObj = new GreenAlien(GameObject.Name.GreenAlien, GameSprite.Name.GreenAlien, posX, posY);
                    break;

                case AlienCategory.Type.Red:
                    pGameObj = new RedAlien(GameObject.Name.RedAlien, GameSprite.Name.RedAlien, posX, posY);
                    break;

                case AlienCategory.Type.White:
                    pGameObj = new WhiteAlien(GameObject.Name.WhiteAlien, GameSprite.Name.WhiteAlien, posX, posY);
                    break;

                case AlienCategory.Type.Yellow:
                    pGameObj = new YellowAlien(GameObject.Name.YellowAlien, GameSprite.Name.YellowAlien, posX, posY);
                    break;

                case AlienCategory.Type.Blue:
                    pGameObj = new BlueAlien(GameObject.Name.BlueAlien, GameSprite.Name.BlueAlien, posX, posY);
                    break;

                case AlienCategory.Type.Grid:
                    pGameObj = new AlienGrid(name, GameSprite.Name.NullObject, posX, posY);
                    break;

                case AlienCategory.Type.Column:
                    pGameObj = new AlienColumn(name, GameSprite.Name.NullObject, posX, posY);
                    break;

                default:
                    // something is wrong
                    Debug.Assert(false);
                    break;
            }
            Debug.Assert(pGameObj != null);

            pGameObj.ActivateGameSprite(this.pSpriteBatch);
            pGameObj.ActivateCollisionSprite(this.pBoxSpriteBatch);
            GameObjectMan.Attach(pGameObj);

            return pGameObj;
        }

        // Data: ---------------------

        private readonly SpriteBatch pSpriteBatch;
        private readonly SpriteBatch pBoxSpriteBatch;

    }
}
