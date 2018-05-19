using ICode;
using ICode.Actions;
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
        private SoundEmitterComponent _currentSoundEmitterComponent = null;

        private void Start()
        {
            _codeBehaviour = gameObject.transform.parent.gameObject.GetBehaviour();
        }

        private void OnDestroy()
        {
            if (_currentSoundEmitterComponent != null)
            {
                _currentSoundEmitterComponent.OnMakeNoise -= Hear;    
            }
                    
        }

        void OnTriggerEnter(Collider other)
        {
            _currentSoundEmitterComponent = other.gameObject.GetComponent<SoundEmitterComponent>();
            if (_currentSoundEmitterComponent == null)
            {
                _currentSoundEmitterComponent = other.gameObject.GetComponentInChildren<SoundEmitterComponent>();
            }

            if (_currentSoundEmitterComponent != null)
            {
                _currentSoundEmitterComponent.OnMakeNoise += Hear;
            }
        }

        void OnTriggerExit(Collider other)
        {
            _currentSoundEmitterComponent = other.gameObject.GetComponent<SoundEmitterComponent>();
            if (_currentSoundEmitterComponent == null)
            {
                _currentSoundEmitterComponent = other.gameObject.GetComponentInChildren<SoundEmitterComponent>();
            }

            if (_currentSoundEmitterComponent != null)
            {
                _currentSoundEmitterComponent.OnMakeNoise -= Hear;
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