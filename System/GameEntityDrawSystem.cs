using System;
using Microsoft.Xna.Framework;
using MonoGame.Extended.ECS;
using MonoGame.Extended.ECS.Systems;

namespace MwGame;

public class GameEntityDrawSystem : EntityDrawSystem
{
	public GameEntityDrawSystem(AspectBuilder aspect) : base(aspect)
	{
	}

	public override void Draw(GameTime gameTime)
	{
		int a=1;
	}

	public override void Initialize(IComponentMapperService mapperService)
	{
	}
}
