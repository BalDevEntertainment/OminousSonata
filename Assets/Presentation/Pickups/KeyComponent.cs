
using UnityEngine;

namespace Presentation.Pickups
{
    public class KeyComponent : InteractuableComponent
    {
        public KeyComponent()
        {
            _action = () => { Debug.Log("Give key to player");};
        }
    }
}