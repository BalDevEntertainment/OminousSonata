using Infrastructure;
using UnityEngine;

namespace Presentation.Events.Triggers
{
	public class GhostTriggerComponent : MonoBehaviour
	{
		[SerializeField] private GameObject _ghostSpawnPoint;
		[SerializeField] private GameObject _ghostPrefab;
		
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag(Tags.Player.ToString()))
			{
				Destroy(GameObject.FindGameObjectWithTag(Tags.Ghost.ToString()));
				Instantiate(_ghostPrefab, _ghostSpawnPoint.transform.position, _ghostSpawnPoint.transform.rotation);
			}
		}
	}
}
