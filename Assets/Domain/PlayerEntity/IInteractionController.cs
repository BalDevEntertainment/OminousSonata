using System;
using Domain.InteractuableEntity;

namespace Domain.PlayerEntity
{
    public interface IInteractionController
    {
        event Action<IInteractuable> OnInteractuableChanged;
        void Interact();
    }
}