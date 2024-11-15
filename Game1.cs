using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ECS;
using MonoGame.Extended.VectorDraw;

namespace MwGame;

public class Game1 : Game
{
	public static Game1 Instance;

	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;

	public SpriteBatch SpriteBatch { get { return _spriteBatch; } }

	private MwWorld _mwWorld;

	private WorldBuilder _worldBuilder;
	private World _world;
	private SpriteFont _font;



	public int Width
	{
		get
		{
			return GraphicsDevice.Viewport.Width;
		}
	}


	public int Height
	{
		get
		{
			return GraphicsDevice.Viewport.Height;
		}
	}


	public KeyboardState Kb;


	public Game1()
	{
		Instance = this;
		_graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content";
		IsMouseVisible = true;
		Window.AllowUserResizing = true;
	}

	private Matrix _primitivesProjectionMatrix;
	private Matrix _matrixIdentity = Matrix.Identity;
	protected override void Initialize()
	{
		_mwWorld = new MwWorld();

		NewGame.Apply(_mwWorld);
		// _gridColor. = 0;

		_primitivesProjectionMatrix = Matrix.CreateOrthographicOffCenter(0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 0, 0, 1);

		_drawTestBatch = new PrimitiveBatch(GraphicsDevice, 1024);
		_drawTest = new PrimitiveDrawing(_drawTestBatch);

		_worldBuilder = new WorldBuilder();

		var aspectBuilder = new AspectBuilder();
		_worldBuilder.AddSystem(new GameEntityDrawSystem(aspectBuilder));
		_world = _worldBuilder.Build();
		var player = _world.CreateEntity();
		
		
		
		base.Initialize();
	}

	BasicEffect _gridEffect;
	Color _gridColor = Color.LightGray;

	PrimitiveDrawing _drawTest;
	PrimitiveBatch _drawTestBatch;

	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);

		_gridEffect = new BasicEffect(GraphicsDevice);
		_gridEffect.VertexColorEnabled = true;
		_gridEffect.Projection = Matrix.CreateOrthographicOffCenter
			(0, Width,     // left, right
			Height, 0,    // bottom, top
			0, 1);





		_drawTestBatch = new PrimitiveBatch(GraphicsDevice);
		_drawTest = new PrimitiveDrawing(_drawTestBatch);

		_font = Content.Load<SpriteFont>("font/font1");

	}

	protected override void Update(GameTime gameTime)
	{
		Kb = Keyboard.GetState();
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Kb.IsKeyDown(Keys.Escape))
			Exit();

		_mwWorld.Update();
		_world.Update(gameTime);

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.Transparent);

		_spriteBatch.Begin();
		_mwWorld.Draw();
		_world.Draw(gameTime);
		_spriteBatch.DrawString(_font, "yo!!!!", new Vector2(100, 100), Color.Green);
		_spriteBatch.End();

		if (Config.DrawGrid)
		{
			DrawGrid();
		}


		_drawTestBatch.Begin(ref _primitivesProjectionMatrix, ref _matrixIdentity);


		for (int x = 10; x < Width; x+=10)
		{
			_drawTest.DrawSegment(new Vector2(x, 10), new Vector2(500, 300), Color.Red);	
		}

		
		// var fill = Color.Orange;
		var fill = Color.Black;
		
		fill.A = Byte.MinValue;
		// fill.A = Byte.MaxValue;
		_drawTest.DrawSolidCircle(new Vector2(10, 10), 222, Color.Red, fill);

		_drawTestBatch.End();


		base.Draw(gameTime);
	} // Draw

	void DrawGrid()
	{
		_gridEffect.CurrentTechnique.Passes[0].Apply();
		var vertices = new List<VertexPositionColor>();

		// for (int x = 64; x < Width; x += 64)
		// {
		for (int x = 64; x < Width; x += 64)
		{
			vertices.Clear();
			vertices.Add(new VertexPositionColor(new Vector3(x, 0, 0), _gridColor));

			vertices.Add(new VertexPositionColor(new Vector3(x, Height, 0), _gridColor));

			vertices.Add(new VertexPositionColor(new Vector3(x - 32, 0, 0), _gridColor));


			vertices.Add(new VertexPositionColor(new Vector3(x - 32, Height, 0), _gridColor));

			GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, vertices.ToArray(), 0, 2);

		}

		for (int y = 64; y < Height; y += 64)
		{
			vertices.Clear();
			vertices.Add(new VertexPositionColor(new Vector3(0, y, 0), _gridColor));

			vertices.Add(new VertexPositionColor(new Vector3(Width, y, 0), _gridColor));

			vertices.Add(new VertexPositionColor(new Vector3(0, y - 32, 0), _gridColor));


			vertices.Add(new VertexPositionColor(new Vector3(Width, y - 32, 0), _gridColor));

			GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.LineList, vertices.ToArray(), 0, 2);

		}

	} // DrawGrid
} // Game1
