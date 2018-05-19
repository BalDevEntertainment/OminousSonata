using UnityEngine;

namespace Presentation.Interactuables.MapInteractuables
{
    public class OpenDoorComponent : InteractuableComponent
    {
        private Animator _animator;

        private void Start()
        {
            _animator = transform.parent.GetComponent<Animator>();
        }

        public OpenDoorComponent()
        {
            _action = () =>
            {
                _animator.SetTrigger("Open");
            };
        }
    }
}