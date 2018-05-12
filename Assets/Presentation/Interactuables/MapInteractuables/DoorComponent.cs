using Infrastructure;
using Presentation.Interactuables.Pickups;
using UnityEngine;

namespace Presentation.Interactuables.MapInteractuables
{
    public class DoorComponent : InteractuableComponent
    {
        public DoorComponent()
        {
            _action = () =>
            {
                var player = RepositoryProvider.Player().GetPlayer();
                if (player.Inventory.ContainsItem(ItemId.YellowDoorKey))
                {
                    Destroy(gameObject);
                }
                else
                {
                    GetComponent<AudioSource>().Play();
                }
            };
        }
    }
}