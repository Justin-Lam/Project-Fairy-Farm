using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	Image image;
	TMP_Text amountText;

	[HideInInspector] public ItemSO itemSO;
	[HideInInspector] public int amount { get; private set; } = 1;
	[HideInInspector] public Transform parentAfterDrag; // to ensure item is drawn over slots

	public void Init(ItemSO item)
	{
		this.itemSO = item;
		image.sprite = item.sprite;
		RefreshAmountText();
	}

	void RefreshAmountText()
	{
		if (amount > 1) amountText.text = amount.ToString();
		else amountText.text = "";  // don't show amount if there's only one
	}

	public void IncrementAmount()
	{
		amount++;
		RefreshAmountText();
	}

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
		transform.position = parentAfterDrag.position;
	}

	void Awake()
	{
		image = GetComponent<Image>();
		amountText = GetComponentInChildren<TMP_Text>();
	}
}
