
namespace SpaceInvaders
{
    class SoundHolder : SLink
    {
        public SoundHolder(Sound sound)
            : base()
        {
            this.pSound = sound;
        }

        public Sound pSound;
    }

}
