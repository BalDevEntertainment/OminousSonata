using Domain.InteractuableEntity;
using Infrastructure;
using UnityEngine;

namespace Presentation.Pickups
{
    public class KeyComponent : InteractuableComponent
    {
        public KeyComponent()
        {
            _action = () =>
            {
                RepositoryProvider.Player().GetPlayer().PickItem(new ItemKey()); 
                Debug.Log("Added Key to inventory");
            };
        }
    }
}