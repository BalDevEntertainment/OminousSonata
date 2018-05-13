
using Domain.PlayerEntity;

public class EnemyInMemoryRepository : IEnemyRepository{
   
    private Enemy _enemy;
    
    public void SetEnemy(Enemy enemy)
    {
        _enemy = enemy;
    }

    public Enemy GetEnemy()
    {
        return _enemy;
    }
}
