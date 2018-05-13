using Domain;
using Domain.PlayerEntity;
using Infrastructure;
using Infrastructure.PlayerEntity;
using UnityEngine;

namespace Presentation.PlayerEntity
{
    public class PlayerContext : MonoBehaviour
    {
        private Player _player;
        private Inventory _inventory;

        private IInteractionController InteractionController { get; set; }
        private IPlayerStatusController PlayerStatusController { get; set; }
        private IPlayerNoiseController PlayerNoiseController { get; set; }

        private void Awake()
        {
            InteractionController = GetComponent<RaycastComponent>();
            PlayerStatusController = GetComponent<StatusComponent>();
            PlayerNoiseController = GetComponent<PlayerSoundEmitterComponent>();
            _inventory = new Inventory();
            _player = new Player(InteractionController, _inventory, RepositoryProvider.Player(), PlayerStatusController, PlayerNoiseController);
        }
    }
}