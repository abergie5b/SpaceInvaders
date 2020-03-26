
namespace SpaceInvaders
{
    public class PlayerMan
    {
        public static PlayerMan instance;
        private static Player pPlayer1;
        private static Player pPlayer2;
        public static int nPlayers;
        public static int nCurrPlayer = 1;

        private PlayerMan()
        {
            pPlayer1 = null;
            pPlayer2 = null;
        }

        public static Player GetPlayer(int n)
        {
            if (n == 1)
                return pPlayer1;
            return pPlayer2;
        }

        public static void WriteHighScores()
        {
            HighScore hS = new HighScore();
            hS.WriteHighScoreToFile(pPlayer1.nPoints);
            if (pPlayer2 != null)
                hS.WriteHighScoreToFile(pPlayer2.nPoints);
        }
        public static void SetNPlayers(int n)
        {
            nPlayers = n;
        }


        public static void SetCurrentPlayer(int n)
        {
            nCurrPlayer = n;
        }

        public static Player GetCurrentPlayer(Ship pShip)
        {
            Player pPlayer = null;
            if (nCurrPlayer == 1)
            {
                pPlayer = pPlayer1;
                if (pPlayer == null)
                {
                    pPlayer = new Player(nCurrPlayer, pShip);
                    pPlayer1 = pPlayer;
                }
            }
            if (nCurrPlayer == 2)
            {
                pPlayer = pPlayer2;
                if (pPlayer == null)
                {
                    pPlayer = new Player(nCurrPlayer, pShip);
                    pPlayer2 = pPlayer;
                }
            }
            return pPlayer;
        }

        public static void Create()
        {
            if (instance == null)
                instance = new PlayerMan();
        }

    }
}
