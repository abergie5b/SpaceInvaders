using System.Diagnostics;
using System;

namespace SpaceInvaders
{
    public class RemoveAlienCommand : Command
    {
        public RemoveAlienCommand(AlienCategory alien)
        {
            this.alien = null;
        }

        public override void Execute(float deltaTime)
        {
            alien.Remove();
        }

        private AlienCategory alien;
    }

}
