using Domain.InteractuableEntity;
using Infrastructure.PlayerEntity;

namespace Domain.PlayerEntity
{
    public class Player
    {
        public Inventory Inventory { get; private set; }
        public IInteractionController InteractionController { get; private set; }

        public Player(IInteractionController interactionController, Inventory inventory, IPlayerRepository playerRepository)
        {
            InteractionController = interactionController;
            Inventory = inventory;
            playerRepository.SetPlayer(this);
        }

        public void PickItem(ItemKey itemKey)
        {
            Inventory.AddItem(itemKey);
        }
    }
}