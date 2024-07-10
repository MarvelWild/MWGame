namespace MwGame
{

    public class World
    {
        private Room _room;
        private Player _player;

        public Room Room { get { return _room; }}

        public World()
        {
            _room = new Room();
        }

        public void AddPlayer(Player player)
        {
            _player = player;
            _room.Entities.Add(player);
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