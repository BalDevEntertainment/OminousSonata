using System;
using Domain.InteractuableEntity;

namespace Domain.PlayerEntity
{
    public class Enemy
    {
        public event Action OnPlayerWasDeath;
        
        public Enemy(IEnemyRepository enemyRepository)
        {
            enemyRepository.SetEnemy(this);
        }

        public void OnKillPlayer()
        {
            OnPlayerWasDeath.Invoke();
        }

    }
   
}