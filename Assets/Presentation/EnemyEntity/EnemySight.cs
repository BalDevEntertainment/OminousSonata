using ICode;
using Presentation.PlayerEntity;
using UnityEngine;

namespace Presentation.EnemyEntity
{
    public class EnemySight : MonoBehaviour
    {
        private const string IsPlayerSeen = "IsPlayerSeen";
        private const string LastHearLocation = "LastHearLocation";
        private ICodeBehaviour _codeBehaviour;
        private Vector3 _lastHearingNoisePosition;

        private void Start()
        {
            _codeBehaviour = gameObject.transform.parent.gameObject.GetBehaviour();
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Collision");
            var soundEmitterComponent = other.gameObject.GetComponent<SoundEmitterComponent>();
            if (soundEmitterComponent == null)
            {
                soundEmitterComponent = other.gameObject.GetComponentInChildren<SoundEmitterComponent>();
            }

            if (soundEmitterComponent != null)
            {
                Debug.Log("BIND");
                soundEmitterComponent.OnMakeNoise += Hear;
            }
        }

        void OnTriggerExit(Collider other)
        {
            var soundEmitterComponent = other.gameObject.GetComponent<SoundEmitterComponent>();
            if (soundEmitterComponent == null)
            {
                soundEmitterComponent = other.gameObject.GetComponentInChildren<SoundEmitterComponent>();
            }

            if (soundEmitterComponent != null)
            {
                soundEmitterComponent.OnMakeNoise -= Hear;
                _codeBehaviour.stateMachine.SetVariable(IsPlayerSeen, false);
                _codeBehaviour.stateMachine.SetVariable(LastHearLocation, _lastHearingNoisePosition);
            }
        }

        private void Hear(GameObject hearedObject)
        {
            _codeBehaviour.stateMachine.SetVariable(IsPlayerSeen, true);
            _lastHearingNoisePosition = hearedObject.transform.position;

        }
    }
}