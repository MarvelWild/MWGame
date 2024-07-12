namespace MwGame
{
    public static class NewGame
    {
        public static void Apply(MwWorld world)
        {
            world.AddPlayer(new Player());

			var stone = new Stone();

			stone.Location = new Microsoft.Xna.Framework.Vector2(320, 320);
			// world.Room.Entities.Add(stone);
        }

    }    

}