using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	Image image;
	[HideInInspector] public Transform parentAfterDrag;	// to ensure item is drawn over slots

	public void OnBeginDrag(PointerEventData eventData)
	{
		image.raycastTarget = false;
		parentAfterDrag = transform.parent;
		transform.SetParent(transform.root);
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		image.raycastTarget = true;
		transform.SetParent(parentAfterDrag);
	}

	void Awake()
	{
		image = GetComponent<Image>();
	}
}
