using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[HideInInspector] public Transform parentAfterDrag; // to ensure item is drawn over slots
	Image image;
	TMP_Text stackSizeText;

	public void OnBeginDrag(PointerEventData ed)
	{
		image.raycastTarget = false;		// so the raycast can hit slots instead of this
		parentAfterDrag = transform.parent;	// in case item isn't dragged to a new slot and needs to be sent back
		transform.SetParent(transform.root);
	}
	public void OnDrag(PointerEventData ed) { transform.position = Input.mousePosition; }
	public void OnEndDrag(PointerEventData ed)
	{
		image.raycastTarget = true;
		transform.SetParent(parentAfterDrag);
		transform.position = parentAfterDrag.position;
	}

	public void Init(ItemStack itemStack)
	{
		image.sprite = itemStack.Item.Sprite;
		UpdateStackSizeText(itemStack.Size);
	}
	public void UpdateStackSizeText(int stackSize)
	{
		if (stackSize > 1) stackSizeText.text = stackSize.ToString();
		else stackSizeText.text = "";
	}

	void Awake()
	{
		image = GetComponent<Image>();
		stackSizeText = GetComponentInChildren<TMP_Text>();
	}
}
