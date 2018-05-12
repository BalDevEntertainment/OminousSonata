using System;
using Domain.InteractuableEntity;
using Presentation.Pickups;

namespace Domain
{
    public interface IInteractionController
    {
        event Action<IInteractuable> OnInteractuableChanged;
        void Interact();
    }
}