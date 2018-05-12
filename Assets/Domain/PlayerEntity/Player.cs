using Domain.InteractuableEntity;
using Infrastructure.PlayerEntity;

namespace Domain.PlayerEntity
{
    public class Player
    {
        private readonly Inventory _inventory;
        public IInteractionController InteractionController { get; private set; }

        public Player(IInteractionController interactionController, Inventory inventory, IPlayerRepository playerRepository)
        {
            InteractionController = interactionController;
            _inventory = inventory;
            playerRepository.SetPlayer(this);
        }

        public void PickItem(ItemKey itemKey)
        {
            _inventory.AddItem(itemKey);
        }
    }
}