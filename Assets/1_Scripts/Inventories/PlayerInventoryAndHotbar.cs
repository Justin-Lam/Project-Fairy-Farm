using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryAndHotbar : MonoBehaviour
{
	[Header("Inventory & Hotbar")]
	[SerializeField] InventorySlot[] slots;
	[SerializeField] InventoryItem inventoryItemPrefab;

	[Header("Inventory")]
	[SerializeField] Canvas inventoryCanvas;

	[Header("Hotbar")]
	[SerializeField] Image hotbarBackground;
	[SerializeField] Transform indicator;

	public static event Action OnInventoryOpened;
	public static event Action OnInventoryClosed;

	public static PlayerInventoryAndHotbar Instance { get; private set; } void InitSingleton() { if (Instance && Instance != this) Destroy(gameObject); else Instance = this; }

	void OnTogglePlayerInventory()
	{
		Debug.Log("hi");
		if (inventoryCanvas.enabled) CloseInventory();
		else OpenInventory();
	}
	void OnExit()
	{
		if (inventoryCanvas.enabled) CloseInventory();
	}
	void OpenInventory()
	{
		inventoryCanvas.enabled = true;
		hotbarBackground.enabled = false;
		OnInventoryOpened?.Invoke();
	}
	void CloseInventory()
	{
		inventoryCanvas.enabled = false;
		hotbarBackground.enabled = true;
		OnInventoryClosed?.Invoke();
	}

	public void MoveHotbarIndicatorToSlot(int index) { indicator.transform.position = slots[index].transform.position; }

	void Awake()
	{
		InitSingleton();
		inventoryCanvas.enabled = false;
	}
}
