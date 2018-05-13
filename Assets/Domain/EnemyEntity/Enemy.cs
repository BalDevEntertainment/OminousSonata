using System;

namespace Domain.PlayerEntity
{
    public class Enemy
    {
        public event Action OnPlayerWasDeath;
        public event Action OnPlayerMakeNoiseEvent;
        
        public Enemy(IEnemyRepository enemyRepository)
        {
            enemyRepository.SetEnemy(this);
        }

        public void OnKillPlayer()
        {
            OnPlayerWasDeath.Invoke();
        }

        public void OnPlayerMakeNoise()
        {
            OnPlayerMakeNoiseEvent.Invoke();
        }
    }
   
}