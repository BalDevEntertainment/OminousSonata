namespace Domain.PlayerEntity
{
    public interface IPlayerRepository
    {
        void SetPlayer(Player player);
        Player GetPlayer();
    }
}