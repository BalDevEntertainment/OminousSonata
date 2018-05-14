
using System;
using Domain.PlayerEntity;
using UnityEngine;

public class PlayerSoundEmitterComponent : MonoBehaviour, IPlayerNoiseController
{

	public event Action<GameObject> OnMakeNoise = delegate {  };

	public void MakeNoise()
	{
		OnMakeNoise.Invoke(gameObject);
	}
}
