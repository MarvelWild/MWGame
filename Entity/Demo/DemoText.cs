using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.VectorDraw;

namespace MwGame
{
	public class DemoText
	{
		private SpriteFont _font;
		private Game1 _game;

		public void LoadContent()
		{
			_font = _game.Content.Load<SpriteFont>("font/font1");
		}

		public void Draw()
		{
			_game.SpriteBatch.DrawString(_font, "yo!!!!"+_game.Width, new Vector2(100, 100), Color.Green);
		}
	}
}