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

	// private MwWorld _mwWorld;

	private WorldBuilder _worldBuilder;
	private World _world;
	
	// private OrthographicCamera _camera;


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


	protected override void Initialize()
	{
		// _mwWorld = new MwWorld();

		// NewGame.Apply(_mwWorld);
		// _gridColor. = 0;



		_worldBuilder = new WorldBuilder();

		// var aspectBuilder = new AspectBuilder();

		_worldBuilder.AddSystem(new RainfallSystem());
		_worldBuilder.AddSystem(new ExpirySystem());
		_worldBuilder.AddSystem(new RenderSystem(GraphicsDevice));
		_world = _worldBuilder.Build();

		// var player = _world.CreateEntity();
		
		
		
		base.Initialize();

		Window.ClientSizeChanged += Window_ClientSizeChanged;
	}

	private void Window_ClientSizeChanged(object sender, System.EventArgs e)
	{
		

	}

	




	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);





		

	}

	protected override void Update(GameTime gameTime)
	{
		Kb = Keyboard.GetState();
		// if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Kb.IsKeyDown(Keys.Escape))
		// 	Exit();

		// _mwWorld.Update();
		_world.Update(gameTime);

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.Transparent);

		_spriteBatch.Begin();
		// _mwWorld.Draw();
		_world.Draw(gameTime);
		
		_spriteBatch.End();





		base.Draw(gameTime);
	} // Draw


} // Game1
