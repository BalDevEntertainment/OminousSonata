using System;
using Domain.InteractuableEntity;

namespace Domain.PlayerEntity
{
    public class Player
    {
        public Inventory Inventory { get; private set; }
        public IInteractionController InteractionController { get; private set; }
        public IPlayerStatusController PlayerStatusController { get; private set; }
        public IPlayerNoiseController PlayeNoiseController { get; private set; }
        public event Action OnDeath;
        
        public Player(IInteractionController interactionController, Inventory inventory, IPlayerRepository playerRepository, IPlayerStatusController playerStatusController, IPlayerNoiseController playerNoiseController)
        {
            InteractionController = interactionController;
            PlayerStatusController = playerStatusController;
            PlayeNoiseController = playerNoiseController;
            Inventory = inventory;
            playerRepository.SetPlayer(this);
        }

        public void PickItem(ItemKey itemKey)
        {
            Inventory.AddItem(itemKey);
        }

        public void OnPlayerDeath()
        {
            OnDeath.Invoke();
        }
    }
   
}