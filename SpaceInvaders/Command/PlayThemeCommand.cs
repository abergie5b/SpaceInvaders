
namespace SpaceInvaders
{
    public class PlayThemeCommand : Command
    {
        public override void Execute(float deltaTime)
        {
            SoundMan.PlaySound(Sound.Name.Theme);
        }
    }

}
