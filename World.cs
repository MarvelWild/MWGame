namespace MwGame
{

    public class World
    {
        private Room _room;

        public World()
        {
            _room = new Room();
        }

        public void Update()
        {
            _room.Update();
        }

        public void Draw()
        {
            _room.Draw();
        }
    }
}