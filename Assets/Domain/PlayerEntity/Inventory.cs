using System;
using System.Linq;
using Boo.Lang;
using Domain.InteractuableEntity;
using Presentation.Interactuables.Pickups;

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

		public bool ContainsItem(ItemId id)
		{
			var item = _items.ToList().Find(key => key.Id.Equals(id));
			return item != null;
		}
	}
}
