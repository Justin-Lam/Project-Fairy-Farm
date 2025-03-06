using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
	[SerializeField] InventoryItem inventoryItemPrefab;

	public void CreateItem(ItemStack stack) { Instantiate(inventoryItemPrefab, transform).Init(stack); }
	public void UpdateStackSizeText(int stackSize) { GetComponentInChildren<InventoryItem>().UpdateStackSizeText(stackSize); }

	public void OnDrop(PointerEventData ed)
	{
		if (transform.childCount == 0) ed.pointerDrag.GetComponent<InventoryItem>().parentAfterDrag = transform;
	}
}
