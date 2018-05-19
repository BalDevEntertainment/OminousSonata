using System;
using Domain.PlayerEntity;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Presentation.PlayerEntity
{
	public class SoundEmitterComponent : MonoBehaviour, IPlayerNoiseController
	{

		public event Action<GameObject> OnMakeNoise = delegate {  };
		[SerializeField] private FirstPersonController _firstPersonController;

		private void Start()
		{
			_firstPersonController.OnWalkingSound += MakeNoise;
		}

		private void OnDestroy()
		{
			_firstPersonController.OnWalkingSound -= MakeNoise;		
		}

		private void MakeNoise()
		{
			OnMakeNoise.Invoke(gameObject);
		}
	}
}
