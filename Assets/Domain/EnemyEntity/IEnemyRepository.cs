namespace Domain.PlayerEntity
{
    public interface IEnemyRepository
    {
        void SetEnemy(Enemy enemy);
        Enemy GetEnemy();
    }
}