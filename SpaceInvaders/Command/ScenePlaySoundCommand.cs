using System.Diagnostics;

namespace SpaceInvaders
{
    class ScenePlaySoundCommand : Command
    {
        public ScenePlaySoundCommand()
        {
        }

        public void Attach(Sound.Name soundName)
        {
            Sound pSound = SoundMan.Find(soundName);
            Debug.Assert(pSound != null);

            SoundHolder pSoundHolder = new SoundHolder(pSound);
            Debug.Assert(pSoundHolder != null);

            SLink.AddToFront(ref this.poFirstSound, pSoundHolder);

            this.pCurrSound = pSoundHolder;
        }

        public override void Execute(float deltaTime)
        {
            SoundHolder pSoundHolder = (SoundHolder)this.pCurrSound.pSNext;

            if (pSoundHolder == null)
            {
                pSoundHolder = (SoundHolder)poFirstSound;
            }
            this.pCurrSound = pSoundHolder;

            SoundMan.PlaySound(pSoundHolder.pSound.name);
            TimerMan.Add(TimeEvent.Name.ScenePlaySound, this, deltaTime);
        }

        // Data: ---------------
        private SLink pCurrSound;
        private SLink poFirstSound;
    }

}
