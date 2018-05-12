using Domain;
using UnityEngine;

namespace Presentation.PlayerEntity
{
    public class StatusComponent : MonoBehaviour, IPlayerStatusController
    {
        private bool IsPlayerAlive  { get; set; }

        private void Start()
        {
            IsPlayerAlive = true;
        }

        public void OnKillPlayer()
        {
            OnPlayerDead();
        }
        
        private void OnPlayerDead()
        {
            Debug.Log("Player muerto");
            // Deberiamos llamar a quien controla el game para restartear el game o mostrar publicidad
            IsPlayerAlive = false;
        }
    }
}