using System;

namespace SpaceInvaders
{
    public class Sound : DLink
    {
        public IrrKlang.ISoundSource source;
        public Sound.Name name;

        public enum Name
        {
            Theme,
            Invader1,
            Invader2,
            Invader3,
            Invader4,
            Explode,
            Shoot,
            InvaderKilled,
            Uninitialized,
            UFOLow,
            UFOHigh,
        }

        public void Initialize(Sound.Name name, IrrKlang.ISoundSource source)
        {
            this.name = name;
            this.source = source;
        }

        public Sound() : base()
        {
            this.name = Sound.Name.Uninitialized;
            this.source = null;
        }

        public Sound(Sound.Name name, IrrKlang.ISoundSource source) : base()
        {
            this.name = name;
            this.source = source;
        }

        public void Wash()
        {
            this.source = null;
        }

        public Sound.Name GetName()
        {
            return this.name;
        }

    }
}
