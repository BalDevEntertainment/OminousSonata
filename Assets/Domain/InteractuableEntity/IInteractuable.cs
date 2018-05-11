using UnityEngine;

namespace Domain.InteractuableEntity
{
    public interface IInteractuable
    {
        Sprite Icon { get; }
        bool CanInteract { get; }
    }
}