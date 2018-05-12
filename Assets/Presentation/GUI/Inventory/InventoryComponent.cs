using Domain.InteractuableEntity;
using Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.GUI.Inventory
{
	public class InventoryComponent : MonoBehaviour
	{

		[SerializeField] private GameObject _itemPrefab;
		
		private void Start()
		{
			RepositoryProvider.Player().GetPlayer().Inventory.OnItemAdded += AddItem;
		}

		private void AddItem(ItemKey obj)
		{
			var item = Instantiate(_itemPrefab, gameObject.transform);
			item.GetComponent<Image>().sprite = obj.Icon;
		}
	}
}
