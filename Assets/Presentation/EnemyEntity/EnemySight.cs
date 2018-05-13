using Domain.PlayerEntity;
using Infrastructure;
using UnityEngine;

namespace Presentation.EnemyEntity
{
    public class EnemySight : MonoBehaviour
    {
        private Player _player;
        private GameObject _playerReference;
        private string PLAYER_TAG = "Player";

        private void Start()
        {
            _player = RepositoryProvider.Player().GetPlayer();
            _player.PlayerMakeNoise += HearPlayer;
            
        }
        
        void OnTriggerEnter(Collider other) {    
            if (other.gameObject.name.Equals(PLAYER_TAG))
            {
                _playerReference = other.gameObject;
            }
        }
        
        void OnTriggerExit(Collider other) {    
            if (other.gameObject.name.Equals(PLAYER_TAG))
            {
                _playerReference = null;
            }
        }

        private void HearPlayer()
        {
            if(_playerReference != null){
                // ir al player                
            }
        }
    }
    
}