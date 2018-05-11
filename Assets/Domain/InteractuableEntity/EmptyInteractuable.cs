using UnityEngine;

namespace Domain.InteractuableEntity
{
    public class EmptyInteractuable : IInteractuable
    {
        public Sprite Icon { get; private set; }
        public bool CanInteract { get; private set; }
    }
}