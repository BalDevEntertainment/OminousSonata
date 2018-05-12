using Presentation.Interactuables.Pickups;
using UnityEngine;

namespace Domain.InteractuableEntity
{
    public class ItemKey
    {
        public ItemId Id { get; private set; }
        public Sprite Icon { get; private set; }

        public ItemKey(ItemId id, Sprite icon)
        {
            Id = id;
            Icon = icon;
        }
    }
}