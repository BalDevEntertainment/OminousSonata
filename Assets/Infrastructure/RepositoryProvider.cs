using Domain.PlayerEntity;
using Infrastructure.PlayerEntity;

namespace Infrastructure
{
    public static class RepositoryProvider
    {
        private static IPlayerRepository _playerRepository;

        public static IPlayerRepository Player()
        {
            return _playerRepository ?? (_playerRepository = new PlayerInMemoryRepository());
        }
    }
}