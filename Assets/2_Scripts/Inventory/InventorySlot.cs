using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		if (transform.childCount == 0) eventData.pointerDrag.GetComponent<InventoryItem>().parentAfterDrag = transform;
	}
}
