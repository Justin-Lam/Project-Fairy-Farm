using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	Image image;
	TMP_Text amountText;

	[HideInInspector] public Item item {  get; private set; }
	[HideInInspector] public int amount { get; private set; } = 1;
	[HideInInspector] public Transform parentAfterDrag; // to ensure item is drawn over slots

	public void Set(Item itemSO)
	{
		this.item = itemSO;
		image.sprite = itemSO.sprite;
		RefreshAmountText();
	}

	void RefreshAmountText()
	{
		if (amount > 1) amountText.text = amount.ToString();
		else amountText.text = "";  // don't show
	}

	public void IncrementAmount()
	{
		amount++;
		RefreshAmountText();
	}

	public void OnBeginDrag(PointerEventData ed)
	{
		image.raycastTarget = false;		// so the raycast can hit slots instead of this
		parentAfterDrag = transform.parent;	// in case item isn't dragged to a new slot and needs to be sent back
		transform.SetParent(transform.root);
	}
	public void OnDrag(PointerEventData ed)
	{
		transform.position = Input.mousePosition;
	}
	public void OnEndDrag(PointerEventData ed)
	{
		image.raycastTarget = true;
		transform.SetParent(parentAfterDrag);
		transform.position = parentAfterDrag.position;
	}

	void Awake()
	{
		image = GetComponent<Image>();
		amountText = GetComponentInChildren<TMP_Text>();
	}
}
