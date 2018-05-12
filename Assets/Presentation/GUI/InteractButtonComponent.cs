using Domain;
using Domain.InteractuableEntity;
using Presentation.PlayerEntity;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.GUI
{
	public class InteractButtonComponent : MonoBehaviour {
		[SerializeField] private Image _icon;
		private IInteractionController _interactionController;

		public void OnButtonPressed()
		{
			_interactionController.Interact();
		}

		private void Start()
		{
			_interactionController = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerContext>().InteractionController;
			_interactionController.OnInteractuableChanged += InteractionChanged;
		}

		private void OnDestroy()
		{
			_interactionController.OnInteractuableChanged -= InteractionChanged;
		}

		private void InteractionChanged(IInteractuable interactuable)
		{
			gameObject.SetActive(interactuable.CanInteract);
			_icon.sprite = interactuable.Icon;
		}
	}
}
