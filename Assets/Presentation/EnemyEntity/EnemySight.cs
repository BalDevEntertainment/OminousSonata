using Boo.Lang;
using Domain.PlayerEntity;
using Infrastructure;
using UnityEngine;

using ICode;

namespace Presentation.EnemyEntity
{
    public class EnemySight : MonoBehaviour
    {
        private readonly string NOISE_LOCATION_VARIABLE_NAME = "NoiseLocation";
        private ICodeBehaviour _codeBehaviour;

        private void Start()
        {
            _codeBehaviour = gameObject.transform.parent.gameObject.GetBehaviour();

        }

        void OnTriggerEnter(Collider other)
        {
            var soundEmitterComponent = other.gameObject.GetComponent<PlayerSoundEmitterComponent>();
            if (soundEmitterComponent == null)
            {
                soundEmitterComponent = other.gameObject.GetComponentInChildren<PlayerSoundEmitterComponent>();
            }

            if (soundEmitterComponent != null)
            {
                soundEmitterComponent.OnMakeNoise += Hear;
            }
        }

        void OnTriggerExit(Collider other) {
            var soundEmitterComponent = other.gameObject.GetComponent<PlayerSoundEmitterComponent>();
            if (soundEmitterComponent == null)
            {
                soundEmitterComponent = other.gameObject.GetComponentInChildren<PlayerSoundEmitterComponent>();
            }

            if (soundEmitterComponent != null)
            {
                soundEmitterComponent.OnMakeNoise -= Hear;
            }
        }
        
        private void Hear(GameObject hearedObject)
        {
            _codeBehaviour.stateMachine.SetVariable(NOISE_LOCATION_VARIABLE_NAME, hearedObject.transform.position);    
        }
       
    }
    
}