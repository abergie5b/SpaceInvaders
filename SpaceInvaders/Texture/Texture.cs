
namespace SpaceInvaders
{
    public class Texture: DLink
    {
        public enum Name
        {
            Default,
            Birds,
            Aliens,
            Juggling,
            Consolas20pt,
            Consolas36pt,
            Uninitialized
        }

        public Name name;
        private Azul.Texture poAzulTexture;

        public Texture(): base()
        {
            poAzulTexture = null;
        }

        public Texture.Name GetName()
        {
            return this.name;
        }

        public Azul.Texture GetAzulTexture()
        {
            return this.poAzulTexture;
        }

        public Texture(Name _name, string _filepath)
        {
            name = _name;
            poAzulTexture = new Azul.Texture(_filepath);
        }

        public void Wash()
        {
            name = Name.Uninitialized;
            poAzulTexture = null;
        }

        public void Initialize(Name _name, Azul.Texture texture)
        {
            name = _name;
            poAzulTexture = texture;
        }

        public Azul.Texture GetTexture()
        {
            return poAzulTexture;
        }

    }

}
