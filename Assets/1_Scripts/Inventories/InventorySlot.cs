using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
	public bool HasItem()
	{
		return transform.childCount > 0;
	}
	public InventoryItem GetItem()
	{
		return GetComponentInChildren<InventoryItem>();
	}

	public void OnDrop(PointerEventData ed)
	{
		if (transform.childCount == 0) ed.pointerDrag.GetComponent<InventoryItem>().parentAfterDrag = transform;
	}
}
