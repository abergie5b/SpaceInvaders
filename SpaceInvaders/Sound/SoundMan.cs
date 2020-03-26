using System.Diagnostics;

namespace SpaceInvaders
{
    public class SoundMan: Manager
    {
        private SoundMan(int nNumReserved, int mGrowth) : base()
        {
            this.engine = new IrrKlang.ISoundEngine();
            this.baseInitialize(nNumReserved, mGrowth);
            this.pNodeCompare = new Sound();
        }

        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            if (instance == null)
            {
                instance = new SoundMan(reserveNum, reserveGrow);
            }
        }

        public static Sound Find(Sound.Name name)
        {
            instance.pNodeCompare.name = name;
            Sound image = (Sound) instance.baseFind(instance.pNodeCompare);
            return image;
        }

        private static SoundMan privGetInstance()
        {
            if (instance == null)
            {
                instance = new SoundMan(3, 1);
            }
            return instance;
        }

        public static void PlaySound(Sound.Name name, float volume=1.0f)
        {
            Debug.Assert(name != Sound.Name.Uninitialized);
            SoundMan sMan = SoundMan.privGetInstance();
            Sound pHead = (Sound)sMan.pActive;
            while (pHead != null)
            {
                if (pHead.name == name)
                {
                    IrrKlang.ISound sound = sMan.engine.Play2D(pHead.source, false, false, false);
                }

                pHead = (Sound)pHead.pNext;
            }
        }

        public static Sound Add(Sound.Name name, string filename)
        {
            SoundMan sMan = SoundMan.privGetInstance();
            Sound sound = (Sound) sMan.AddToFront();
            IrrKlang.ISoundSource source = sMan.engine.AddSoundSourceFromFile(filename);
            source.DefaultVolume = 0.1f;
            sound.Initialize(name, source);
            return sound;
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        override protected DLink derivedCreateNode()
        {
            DLink pNode = new Sound();
            return pNode;
        }

        override protected bool derivedCompare(DLink pLinkA, DLink pLinkB)
        {
            Sound pDataA = (Sound)pLinkA;
            Sound pDataB = (Sound)pLinkB;

            bool status = false;

            if (pDataA.GetName() == pDataB.GetName())
            {
                status = true;
            }

            return status;
        }

        override protected void derivedWash(DLink pLink)
        {
            Sound pNode = (Sound)pLink;
            pNode.Wash();
        }

        // Data
        private static SoundMan instance;
        public IrrKlang.ISoundEngine engine;
        private Sound pNodeCompare;
    }
}
