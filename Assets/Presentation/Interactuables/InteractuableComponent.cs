using System;
using Domain.InteractuableEntity;
using UnityEngine;

namespace Presentation.Interactuables
{
	public class InteractuableComponent : MonoBehaviour, IInteractuable
	{
		[SerializeField] private Sprite _icon;
		[SerializeField] private bool _canInteract = true;
		protected Action _action = () => {};

		public Sprite Icon
		{
			get { return _icon; }
		}

		public bool CanInteract
		{
			get { return _canInteract; }
		}

		public Action Action
		{
			get { return _action; }
		}
	}
}
