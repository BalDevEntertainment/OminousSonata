using UnityEngine;

namespace Domain.InteractuableEntity
{
    public class ItemKey
    {
        public ItemKey(Sprite icon)
        {
            Icon = icon;
        }

        public Sprite Icon { get; private set; }
    }
}