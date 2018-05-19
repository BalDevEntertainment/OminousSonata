using Infrastructure;
using UnityEngine;

namespace Presentation.Events.Triggers
{
	public class GhostTriggerComponent : MonoBehaviour
	{
		[SerializeField] private GameObject _ghostSpawnPoint;
		[SerializeField] private GameObject _ghostPrefab;
		public int SpawnChance;
		
		private void OnTriggerEnter(Collider other)
		{
			
			if (ShouldSpawnGhost(other)) 
			{
				Destroy(GameObject.FindGameObjectWithTag(Tags.Ghost.ToString()));
				Instantiate(_ghostPrefab, _ghostSpawnPoint.transform.position, _ghostSpawnPoint.transform.rotation);
			}
		}

		private bool ShouldSpawnGhost(Collider other)
		{
			var prob = Random.Range(1, 100);
			return other.CompareTag(Tags.Player.ToString()) && prob <= SpawnChance;
		}
	}
}
