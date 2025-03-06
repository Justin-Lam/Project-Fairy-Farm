using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
	[SerializeField] ItemStack itemStackPrefab;

	public ItemStack ItemStack => GetComponentInChildren<ItemStack>();
	public bool IsEmpty => transform.childCount == 0;

	public void CreateItemStack(Item item, int stackSize) { Instantiate(itemStackPrefab, transform).Init(item, stackSize); }

	public void OnDrop(PointerEventData ed) { if (IsEmpty) ed.pointerDrag.GetComponent<ItemStack>().parentAfterDrag = transform; }
}
