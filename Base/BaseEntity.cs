using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MwGame
{
    public class BaseEntity : IEntity
    {
        Texture2D _tex;

        private Vector2 _location;

        public int Speed = 1;

        public Vector2 Location
        {
            get { return _location; }
            set
            {
                _location = value;
            }
        }

        public void SetTexture(string path)
        {
            _tex = Game1.Instance.Content.Load<Texture2D>("img/" + path);
        }

        public void Draw()
        {
            if (_tex != null)
            {
                Game1.Instance.SpriteBatch.Draw(_tex, Location, Color.White);
            }
        }

        public virtual void Update()
        {
        }
    }
}