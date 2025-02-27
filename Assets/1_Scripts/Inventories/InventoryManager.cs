using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] Image background;
	[SerializeField] Canvas playerInventory;

	[Header("Hotbar")]
	[SerializeField] int numHotbarSlots;
	[SerializeField, Tooltip("Aka inventory slot width")] float hotbarCellSizeX;
	[SerializeField] float hotbarSpacingX;
	[SerializeField] RectTransform selectedSlotIndicator;
	int currentHotbarSlot = 0;
	Vector3 selectedSlotIndicatorStartPosition;

	[Header("Player Inventory")]
	[SerializeField] GameObject inventoryItemPrefab;
	public GameObject[] playerInventorySlots;

	public static event Action OnPlayerInventoryOpened;
	public static event Action OnPlayerInventoryClosed;

	[Header("Singleton Pattern")]
	private static InventoryManager instance;
	public static InventoryManager Instance => instance;
	void InitSingleton()
	{
		if (instance && instance != this) Destroy(gameObject);
		else instance = this;
	}

	void OnScrollSlots(InputValue iv)
	{
		if (iv.Get<float>() > 0) ScrollUp();
		else if (iv.Get<float>() < 0) ScrollDown();
	}
	void OnSelectSlot1()
	{ 
		// figure out a better way to go about splitting things up
	}
	void OnToggleInventory()
	{
		background.enabled = !background.enabled;
		playerInventory.enabled = !playerInventory.enabled;

		if (background.enabled) OnPlayerInventoryOpened?.Invoke();
		else OnPlayerInventoryClosed?.Invoke();
	}
	void OnExit()
	{
		if (!background.enabled) return;

		background.enabled = false;
		playerInventory.enabled = false;
		OnPlayerInventoryClosed?.Invoke();
	}

	void ScrollUp()
	{
		if (currentHotbarSlot < numHotbarSlots - 1) selectedSlotIndicator.position += new Vector3(hotbarCellSizeX + hotbarSpacingX, 0, 0);
		else selectedSlotIndicator.position -= new Vector3(hotbarCellSizeX + hotbarSpacingX, 0, 0) * (numHotbarSlots - 1);

		currentHotbarSlot = (currentHotbarSlot + 1) % numHotbarSlots;
	}
	void ScrollDown()
	{
		if (currentHotbarSlot > 0) selectedSlotIndicator.position -= new Vector3(hotbarCellSizeX + hotbarSpacingX, 0, 0);
		else selectedSlotIndicator.position += new Vector3(hotbarCellSizeX + hotbarSpacingX, 0, 0) * (numHotbarSlots - 1);

		currentHotbarSlot = (currentHotbarSlot - 1 + numHotbarSlots) % numHotbarSlots;
	}

	public void AddItemToPlayerInventory(Item item)
	{
		// First try to add to a stack
		foreach (GameObject slot in playerInventorySlots)
		{
			if (slot.transform.childCount == 0) continue;

			InventoryItem ii = slot.GetComponentInChildren<InventoryItem>();
			if (ii.item == item && ii.amount < item.maxStackSize)
			{
				ii.IncrementAmount();
				return;
			}
		}

		// Second try to create a new stack
		foreach (GameObject slot in playerInventorySlots)
		{
			if (slot.transform.childCount == 0)
			{
				GameObject itemGO = Instantiate(inventoryItemPrefab, slot.transform);
				InventoryItem ii = itemGO.GetComponent<InventoryItem>();
				ii.Init(item);
				return;
			}
		}
	}

	void Awake()
	{
		InitSingleton();

		selectedSlotIndicatorStartPosition = selectedSlotIndicator.position;

		background.enabled = false;
		playerInventory.enabled = false;
	}
}
