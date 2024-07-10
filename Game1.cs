using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MwGame;

public class Game1 : Game
{
    public static Game1 Instance;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public SpriteBatch SpriteBatch { get{ return _spriteBatch; }}

    private World _world;

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
        // TODO: Add your initialization logic here

        NewGame.Apply(_world);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        
    }

    protected override void Update(GameTime gameTime)
    {
        Kb = Keyboard.GetState();
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Kb.IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        _world.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Transparent);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _world.Draw();


        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
