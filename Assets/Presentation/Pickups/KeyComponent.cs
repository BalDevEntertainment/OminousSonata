using Domain.InteractuableEntity;
using Infrastructure;
using UnityEngine;

namespace Presentation.Pickups
{
    public class KeyComponent : InteractuableComponent
    {
        [SerializeField] private Sprite _inventoryIcon;

        public KeyComponent()
        {
            _action = () =>
            {
                RepositoryProvider.Player().GetPlayer().PickItem(new ItemKey(_inventoryIcon));
                Destroy(gameObject);
            };
        }
    }
}