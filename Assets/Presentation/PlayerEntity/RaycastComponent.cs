using System;
using Domain;
using Domain.InteractuableEntity;
using Presentation.Pickups;
using UnityEngine;

namespace Presentation.PlayerEntity
{
    public class RaycastComponent : MonoBehaviour, IInteractionController
    {
        public event Action<IInteractuable> OnInteractuableChanged = delegate { };

        [SerializeField] private int _interactionDistance;
        [SerializeField] private bool _debug;

        public void Interact()
        {
            RaycastHit hit;
            if (IsAbleToInteract(out hit))
            {
                GetInteractuable(hit).Action.Invoke();
            }
        }

        void Update()
        {
            RaycastHit hit;
            ShouldDebug();
            if (IsAbleToInteract(out hit))
            {
                OnInteractuableChanged(GetInteractuable(hit));
            }
            else
            {
                OnInteractuableChanged(new EmptyInteractuable());
            }
        }

        private bool IsAbleToInteract(out RaycastHit hit)
        {
            return HasRaycastHitSomething(out hit) && HasDetectedObjectSomeCollider(hit) &&
                   IsDetectedObjectInteractuable(hit);
        }

        private bool HasRaycastHitSomething(out RaycastHit hit)
        {
            return Physics.Raycast(transform.position, transform.forward, out hit,
                _interactionDistance);
        }

        private void ShouldDebug()
        {
            if (_debug)
                Debug.DrawRay(transform.position,
                    transform.forward * _interactionDistance);
        }

        private static bool IsDetectedObjectInteractuable(RaycastHit hit)
        {
            return hit.collider.gameObject.GetComponent<InteractuableComponent>() != null;
        }

        private static bool HasDetectedObjectSomeCollider(RaycastHit hit)
        {
            return hit.collider != null;
        }

        private static InteractuableComponent GetInteractuable(RaycastHit hit)
        {
            return hit.collider.gameObject.GetComponent<InteractuableComponent>();
        }
    }
}