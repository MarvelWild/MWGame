using Microsoft.Xna.Framework;

namespace MwGame
{
	public interface IEntity : IDrawable, IUpdateable
	{
		public Vector2 Location { get; set; }
		

	}

}