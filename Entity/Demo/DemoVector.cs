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
	public class DemoVector
	{
		PrimitiveDrawing _drawTest;
		PrimitiveBatch _drawTestBatch;

		private Game1 _game;

		private Matrix _primitivesProjectionMatrix;
		private Matrix _matrixIdentity = Matrix.Identity;


		void Initialize()
		{
			_primitivesProjectionMatrix = Matrix.CreateOrthographicOffCenter(0, _game.GraphicsDevice.Viewport.Width, _game.GraphicsDevice.Viewport.Height, 0, 0, 1);

			_drawTestBatch = new PrimitiveBatch(_game.GraphicsDevice, 1024);
			_drawTest = new PrimitiveDrawing(_drawTestBatch);
		}

		void LoadContent()
		{
			_drawTestBatch = new PrimitiveBatch(_game.GraphicsDevice);
			_drawTest = new PrimitiveDrawing(_drawTestBatch);
		}

		void Draw()
		{
			_drawTestBatch.Begin(ref _primitivesProjectionMatrix, ref _matrixIdentity);


			for (int x = 10; x < _game.Width; x+=10)
			{
				_drawTest.DrawSegment(new Vector2(x, 10), new Vector2(500, 300), Color.Red);	
			}

			
			// var fill = Color.Orange;
			var fill = Color.Black;
			
			fill.A = Byte.MinValue;
			// fill.A = Byte.MaxValue;
			_drawTest.DrawSolidCircle(new Vector2(10, 10), 222, Color.Red, fill);

			_drawTestBatch.End();
		}

		void OnSizeChanged()
		{
			_primitivesProjectionMatrix = Matrix.CreateOrthographicOffCenter(0, _game.GraphicsDevice.Viewport.Width, _game.GraphicsDevice.Viewport.Height, 0, 0, 1);
		}
	}
}