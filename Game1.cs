using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace MwGame;

public class Game1 : Game
{
	public static Game1 Instance;

	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;

	public SpriteBatch SpriteBatch { get { return _spriteBatch; } }

	private World _world;



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
	}

	protected override void Initialize()
	{
		_world = new World();

		NewGame.Apply(_world);
		// _gridColor. = 0;

		base.Initialize();
	}

	BasicEffect _gridEffect;
	Color _gridColor = Color.LightGray;

	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);

		_gridEffect = new BasicEffect(GraphicsDevice);
		_gridEffect.VertexColorEnabled = true;
		_gridEffect.Projection = Matrix.CreateOrthographicOffCenter
			(0, Width,     // left, right
			Height, 0,    // bottom, top
			0, 1);

	}

	protected override void Update(GameTime gameTime)
	{
		Kb = Keyboard.GetState();
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Kb.IsKeyDown(Keys.Escape))
			Exit();

		_world.Update();

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.Transparent);

		_spriteBatch.Begin();
		_world.Draw();
		_spriteBatch.End();

		if (Config.DrawGrid)
		{
			DrawGrid();
		}

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
