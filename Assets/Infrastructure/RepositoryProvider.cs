using Domain.PlayerEntity;
using Infrastructure.PlayerEntity;

namespace Infrastructure
{
    public static class RepositoryProvider
    {
        private static IPlayerRepository _playerRepository;
        private static IEnemyRepository _enemyRepository;

        public static IPlayerRepository Player()
        {
            return _playerRepository ?? (_playerRepository = new PlayerInMemoryRepository());
        }
        
        public static IEnemyRepository Enemy()
        {
            return _enemyRepository ?? (_enemyRepository = new EnemyInMemoryRepository());
        }
    }
}