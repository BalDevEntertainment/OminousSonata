using Domain.InteractuableEntity;
using Infrastructure;
using UnityEditor;
using UnityEngine;

namespace Presentation.Interactuables.Pickups
{
    public class KeyComponent : InteractuableComponent
    {
        [SerializeField] private Sprite _inventoryIcon;

        public KeyComponent()
        {
            _action = () =>
            {
                RepositoryProvider.Player().GetPlayer().PickItem(new ItemKey(ItemId.YellowDoorKey, _inventoryIcon));
                Destroy(gameObject);
            };
        }
    }
}