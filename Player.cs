using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MwGame
{

	public class Player : BaseEntity
	{
		public Inventory Inventory = new Inventory();


		public Player()
		{
			SetTexture("player");
		}

		public override void Update()
		{
			var kb = Game1.Instance.Kb;
			var newX = Location.X;
			var newY = Location.Y;
			if (kb.IsKeyDown(Config.KeyRight))
			{
				newX += Speed;
			}

			if (kb.IsKeyDown(Config.KeyLeft))
			{
				newX -= Speed;
			}

			if (kb.IsKeyDown(Config.KeyDown))
			{
				newY += Speed;
			}

			if (kb.IsKeyDown(Config.KeyUp))
			{
				newY -= Speed;
			}

			Location = new Vector2(newX, newY);
		}
	}
}