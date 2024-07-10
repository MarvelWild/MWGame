namespace MwGame
{
    public static class NewGame
    {
        public static void Apply(World world)
        {
            world.AddPlayer(new Player());
        }

    }    

}