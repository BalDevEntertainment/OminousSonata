using Domain.PlayerEntity;

namespace Infrastructure.PlayerEntity
{
    public class PlayerInMemoryRepository : IPlayerRepository
    {
        private Player _player;

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public Player GetPlayer()
        {
            return _player;
        }
    }
}