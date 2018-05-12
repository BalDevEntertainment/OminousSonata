using Domain;
using UnityEngine;

namespace Presentation.PlayerEntity
{
    public class StatusComponent : MonoBehaviour, IPlayerStatusController
    {
        private int _playerHealth = 100;
        
        public void OnReceiveDamage(int DamageAmount)
        {
            //No hay vida segun ultima definicion de gameplay
//            _playerHealth = _playerHealth - DamageAmount;
//            Debug.Log("Damage");
//            if (!IsAlive())
//            {
//                OnPlayerDead();
//            }
            
            
        }

        private bool IsAlive()
        {
            return _playerHealth > 0;
        }
        
        private void OnPlayerDead()
        {
            Debug.Log("Player muerto");
        }
    }
}