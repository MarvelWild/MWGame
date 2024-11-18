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
	public class DemoGrid
	{
		BasicEffect _gridEffect;
		Game1 _game;
		Color _gridColor = Color.LightGray;

		public void LoadContent()
		{
			_gridEffect = new BasicEffect(_game.GraphicsDevice);
			_gridEffect.VertexColorEnabled = true;
			_gridEffect.Projection = Matrix.CreateOrthographicOffCenter
				(0, _game.Width,     // left, right
				_game.Height, 0,    // bottom, top
				0, 1);
		}

		public void OnSizeChanged()
		{
			_gridEffect.Projection = Matrix.CreateOrthographicOffCenter
				(0, _game.Width,     // left, right
				_game.Height, 0,    // bottom, top
				0, 1);
		} 

		public	void Draw()
		{
			_gridEffect.CurrentTechnique.Passes[0].Apply();
			var vertices = new List<VertexPositionColor>();

			// for (int x = 64; x < Width; x += 64)
			// {
			for (int x = 64; x < _game.Width+100; x += 64)
			{
				vertices.Clear();
				vertices.Add(new VertexPositionColor(new Vector3(x, 0, 0), _gridColor));

				vertices.Add(new VertexPositionColor(new Vector3(x, _game.Height, 0), _gridColor));

				vertices.Add(new VertexPositionColor(new Vector3(x - 32, 0, 0), _gridColor));


				vertices.Add(new VertexPositionColor(new Vector3(x - 32, _game.Height, 0), _gridColor));

				_game.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, vertices.ToArray(), 0, 2);

			}

			for (int y = 64; y < _game.Height; y += 64)
			{
				vertices.Clear();
				vertices.Add(new VertexPositionColor(new Vector3(0, y, 0), _gridColor));

				vertices.Add(new VertexPositionColor(new Vector3(_game.Width, y, 0), _gridColor));

				vertices.Add(new VertexPositionColor(new Vector3(0, y - 32, 0), _gridColor));


				vertices.Add(new VertexPositionColor(new Vector3(_game.Width, y - 32, 0), _gridColor));

				_game.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, vertices.ToArray(), 0, 2);

			}

		} // DrawGrid
	}
}