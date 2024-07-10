using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MwGame
{

    public class Player : IEntity
    {
        Texture2D _testTex = Game1.Instance.Content.Load<Texture2D>("img/player");

        public void Draw()
        {
            Game1.Instance.SpriteBatch.Draw(_testTex, new Vector2(0, 0), Color.White);
        }

        public void Update()
        {
        }
    }
}