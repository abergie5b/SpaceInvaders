using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMan
    {
        public enum State
        {
            Ready,
            MissileFlying,
            Dead,
            Inactive
        }

        private ShipMan()
        {
            this.pStateReady = new ShipStateReady();
            this.pStateMissileFlying = new ShipStateMissileFlying();
            this.pStateDead = new ShipStateDead();
            this.pStateInactive = new ShipStateInactive();

            this.pShip = null;
            this.pHead = null;
        }

        public static Ship GetShip(int nPlayer)
        {
            Ship head = ShipMan.instance.pHead;
            for (; nPlayer>0; nPlayer--)
                head = (Ship)head.pNext;
            return head;
        }

        public static Ship Find(Ship pShip)
        {
            Ship head = ShipMan.instance.pShip;
            while (head != null)
            {
                if (head == pShip)
                    return head;
                head = (Ship)head.pNext;
            }
            return null;
        }

        public static void Add(Ship pShip)
        {
            Ship head = ShipMan.instance.pShip;
            if (head != null)
            {
                pShip.pNext = head;
            }
            head = pShip;
        }

        public static ShipMan Create()
        {
            if (instance == null)
            {
                instance = new ShipMan();
            }
            return instance;
        }

        public static Ship CreateShip()
        {
            if (instance == null)
            {
                instance = new ShipMan();
            }

            Debug.Assert(instance != null);

            Ship pShip = ActivateShip();
            pShip.SetState(ShipMan.State.Ready);
            return pShip;
        }

        private static ShipMan PrivInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static Ship GetShip()
        {
            ShipMan pShipMan = ShipMan.PrivInstance();

            Debug.Assert(pShipMan != null);

            return pShipMan.pShip;
        }

        public static ShipState GetState(State state)
        {
            ShipMan pShipMan = ShipMan.PrivInstance();
            Debug.Assert(pShipMan != null);

            ShipState pShipState = null;

            switch (state)
            {
                case ShipMan.State.Ready:
                    pShipState = pShipMan.pStateReady;
                    break;

                case ShipMan.State.MissileFlying:
                    pShipState = pShipMan.pStateMissileFlying;
                    break;

                case ShipMan.State.Dead:
                    pShipState = pShipMan.pStateDead;
                    break;

                case ShipMan.State.Inactive:
                    pShipState = pShipMan.pStateInactive;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }

        public static Missile ActivateMissile(Ship pShip)
        {
            Missile pMissile = pShip.GetMissile();
            ShipMan pShipMan = ShipMan.PrivInstance();
            Debug.Assert(pShipMan != null);

            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            SpriteBatch pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);

            pMissile.ActivateCollisionSprite(pSB_Boxes);
            pMissile.ActivateGameSprite(pSB_Aliens);
            pMissile.pPlayer = pShip.pPlayer;

            GameObject pMissileGroup = GameObjectMan.Find(GameObject.Name.MissileGroup);
            Debug.Assert(pMissileGroup != null);

            pMissileGroup.Add(pMissile);
            return pMissile;
        }

        public static Ship CreateInactiveShip(int xPos, int yPos)
        {
            ShipMan pShipMan = ShipMan.PrivInstance();
            Debug.Assert(pShipMan != null);

            // copy over safe copy
            Ship pShip = new Ship(GameObject.Name.ShipInactive, GameSprite.Name.ShipInactive, xPos, yPos);
            pShip.SetState(ShipMan.State.Inactive);

            // Attach the sprite to the correct sprite batch
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            pSB_Aliens.Attach(pShip.pProxySprite);

            GameObject pShipRoot = GameObjectMan.Find(GameObject.Name.ShipRoot);
            Debug.Assert(pShipRoot != null);

            pShipRoot.Add(pShip);
            GameObjectMan.Attach(pShip);
            return pShip;
        }

        public static Ship ActivateShip(Ship pShip)
        {
            // Attach the sprite to the correct sprite batch
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            pSB_Aliens.Attach(pShip.pProxySprite);

            GameObject pShipRoot = GameObjectMan.Find(GameObject.Name.ShipRoot);
            Debug.Assert(pShipRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pShipRoot.Add(pShip);
            return pShip;
        }

        public static Ship ActivateShip()
        {
            ShipMan pShipMan = ShipMan.PrivInstance();
            Debug.Assert(pShipMan != null);

            // copy over safe copy
            Ship pShip = new Ship(GameObject.Name.Ship, GameSprite.Name.Ship, 300, 70);
            ShipMan.Add(pShip);

            // Attach the sprite to the correct sprite batch
            SpriteBatch pSB_Aliens = SpriteBatchMan.Find(SpriteBatch.Name.Aliens);
            pSB_Aliens.Attach(pShip.pProxySprite);

            GameObject pShipRoot = GameObjectMan.Find(GameObject.Name.ShipRoot);
            Debug.Assert(pShipRoot != null);

            // Add to GameObject Tree - {update and collisions}
            pShipRoot.Add(pShip);
            return pShip;
        }

        // Data: ----------------------------------------------
        private static ShipMan instance = null;

        // Active
        private Ship pShip;
        private Ship pHead;

        // Reference
        private ShipStateReady pStateReady;
        private ShipStateMissileFlying pStateMissileFlying;
        private ShipStateInactive pStateInactive;
        private readonly ShipStateDead pStateDead;

    }
}
