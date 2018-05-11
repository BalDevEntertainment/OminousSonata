namespace Domain.PlayerEntity
{
    public class Player
    {
        private readonly IInteractionController _interactionController;

        public Player(IInteractionController interactionController)
        {
            _interactionController = interactionController;
        }
    }
}