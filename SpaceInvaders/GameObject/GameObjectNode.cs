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
    abstract public class GameObjectNode_Link : DLink
    {

    }

    public class GameObjectNode : GameObjectNode_Link
    {
        public GameObjectNode()
            : base()
        {
            this.poGameObj = null;
        }
        ~GameObjectNode()
        {

        }
        public void Set(GameObject pGameObject)
        {
            Debug.Assert(pGameObject != null);
            this.poGameObj = pGameObject;
        }

        public void Wash()
        {
            this.poGameObj = null;
        }


        // Data: ------------------

        public GameObject poGameObj;

    }
}
