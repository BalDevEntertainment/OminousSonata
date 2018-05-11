using Domain;
using Domain.PlayerEntity;
using UnityEngine;

namespace Presentation.PlayerEntity
{
    public class PlayerContext : MonoBehaviour
    {
        private Player _player;

        public IInteractionController InteractionController { get; private set; }

        private void Awake()
        {
            InteractionController = GetComponent<RaycastComponent>();
        }

        private void Start()
        {
            _player = new Player(InteractionController);
        }
    }
}