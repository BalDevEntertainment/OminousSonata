using System;
using Boo.Lang;
using Domain.InteractuableEntity;

namespace Domain.PlayerEntity
{
	public class Inventory {
		
		public event Action<ItemKey> OnItemAdded = delegate {  };
		private readonly List<ItemKey> _items = new List<ItemKey>();
		
		public void AddItem(ItemKey itemKey)
		{
			_items.Add(itemKey);
			OnItemAdded(itemKey);
		}
	}
}
