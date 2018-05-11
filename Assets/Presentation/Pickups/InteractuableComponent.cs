using Domain.InteractuableEntity;
using UnityEngine;

namespace Presentation.Pickups
{
	public class InteractuableComponent : MonoBehaviour, IInteractuable
	{
		[SerializeField] private Sprite _icon;
		[SerializeField] private bool _canInteract = true;

		public Sprite Icon
		{
			get { return _icon; }
		}

		public bool CanInteract
		{
			get { return _canInteract; }
		}
	}
}
