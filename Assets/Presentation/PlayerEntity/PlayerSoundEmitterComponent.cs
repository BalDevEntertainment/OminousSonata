
using Domain.PlayerEntity;
using Infrastructure;
using UnityEngine;

public class PlayerSoundEmitterComponent : MonoBehaviour, IPlayerNoiseController {

	public void MakeNoise(int noiseRadius)
	{
		RepositoryProvider.Enemy().GetEnemy().OnPlayerMakeNoise();
	}
}
