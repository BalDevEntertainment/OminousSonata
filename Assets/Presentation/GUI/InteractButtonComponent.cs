using Domain.InteractuableEntity;
using Presentation.PlayerEntity;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.GUI
{
	public class InteractButtonComponent : MonoBehaviour {
		[SerializeField] private Image _icon;
		private PlayerContext _playerContext;

		private void Start()
		{
			_playerContext = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerContext>();
			_playerContext.InteractionController.OnInteractuableChanged += InteractionChanged;
		}

		private void OnDestroy()
		{
			_playerContext.InteractionController.OnInteractuableChanged += InteractionChanged;
		}

		public void InteractionChanged(IInteractuable interactuable)
		{
			gameObject.SetActive(interactuable.CanInteract);
			_icon.sprite = interactuable.Icon;
		}
	}
}
