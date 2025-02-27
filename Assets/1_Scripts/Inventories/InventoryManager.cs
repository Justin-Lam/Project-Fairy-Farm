using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	[Header("Player Inventory")]
	[SerializeField] GameObject inventoryItemPrefab;
	public GameObject[] playerInventorySlots;

	[Header("Singleton Pattern")]
	private static InventoryManager instance;
	public static InventoryManager Instance => instance;
	void InitSingleton()
	{
		if (instance && instance != this) Destroy(gameObject);
		else instance = this;
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
	}
}
