using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ItemStack : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Item Item { get; private set; }
	public int Size { get; private set; }

	[HideInInspector] public Transform parentAfterDrag; // to ensure item is drawn over slots

	Image image;
	TMP_Text sizeText;

	public void Init(Item item, int size)
	{
		Item = item;
		Size = size;
		image.sprite = item.Sprite;
		UpdateSizeText();
	}

	public void AddToStack(int amount)
	{
		Size += amount;
		UpdateSizeText();
	}

	public void UpdateSizeText()
	{
		if (Size > 1) sizeText.text = Size.ToString();
		else sizeText.text = "";
	}

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

	void Awake()
	{
		image = GetComponent<Image>();
		sizeText = GetComponentInChildren<TMP_Text>();
	}
}
