using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
	public bool HasInventoryItem()
	{
		return transform.childCount > 0;
	}
	public InventoryItem GetInventoryItem()
	{
		return GetComponentInChildren<InventoryItem>();
	}

	public void OnDrop(PointerEventData ed)
	{
		if (transform.childCount == 0) ed.pointerDrag.GetComponent<InventoryItem>().parentAfterDrag = transform;
	}
}
