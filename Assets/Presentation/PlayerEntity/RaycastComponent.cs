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

        void Update()
        {
            RaycastHit hit;

            ShouldDebug();

            if (HasInteractuableChanged(out hit))
            {
                OnInteractuableChanged(
                    hit.collider.gameObject.GetComponent<InteractuableComponent>());
            }
            else
            {
                OnInteractuableChanged(new EmptyInteractuable());
            }
        }

        private bool HasInteractuableChanged(out RaycastHit hit)
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
    }
}