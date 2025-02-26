using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] Image background;
	[SerializeField] Canvas playerInventory;

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

		background.enabled = false;
		playerInventory.enabled = false;
	}
}
