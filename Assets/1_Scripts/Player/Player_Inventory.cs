using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Inventory : MonoBehaviour
{
	[SerializeField] int hotbarSize;
	[SerializeField] int inventorySize;
	Item[] items;
	int selectedItemIndex = 0;

	public static Player_Inventory Instance { get; private set; } void InitSingleton() { if (Instance && Instance != this) Destroy(gameObject); else Instance = this; }

	void OnScrollHotbar(InputValue iv)
	{
		if (iv.Get<float>() > 0) selectedItemIndex = (selectedItemIndex + 1) % hotbarSize;
		else if (iv.Get<float>() < 0) selectedItemIndex = (selectedItemIndex - 1 + hotbarSize) % hotbarSize;

		if (items[selectedItemIndex]) Debug.Log($"Selected ({selectedItemIndex}): {items[selectedItemIndex].Name}");
		else Debug.Log($"Selcted ({selectedItemIndex}): Null");
	}
	void SelectHotbarSlot(int num)
	{
		selectedItemIndex = num - 1;

		if (items[selectedItemIndex]) Debug.Log($"Selected ({selectedItemIndex}): {items[selectedItemIndex].Name}");
		else Debug.Log($"Selcted ({selectedItemIndex}): Null");
	}

	public void AddOneItem(Item item) { Add(item, 1); }
	public void AddFiveItems(Item item) { Add(item, 5); }
	public void Add(Item item, int amount)
	{
		Item itemToAdd = item;
		int remainingAmountToAdd = amount;

		while (remainingAmountToAdd > 0)
		{
			// Try to stack
			foreach (Item itemInInventory in items)
			{
				if (!itemInInventory) continue;
				if (itemInInventory.Name != itemToAdd.Name) continue;

				int amountCanBeAdded = itemInInventory.MaxStackSize - itemInInventory.StackSize;
				if (amountCanBeAdded <= 0) continue;

				int amountToAdd = Math.Min(amountCanBeAdded, remainingAmountToAdd);
				itemInInventory.AddToStack(amountToAdd);
				remainingAmountToAdd -= amountToAdd;

				if (remainingAmountToAdd <= 0) break;
			}

			if (remainingAmountToAdd <= 0) break;

			// Try to create stack
			for (int i = 0; i < items.Length; i++)	// can't use foreach loop because need to modify array
			{
				Item itemInInventory = items[i];

				if (itemInInventory) continue;

				items[i] = Instantiate(itemToAdd);
				itemInInventory = items[i];
				remainingAmountToAdd -= itemInInventory.StackSize;

				if (remainingAmountToAdd <= 0) break;

				int amountCanBeAdded = itemInInventory.MaxStackSize - itemInInventory.StackSize;
				if (amountCanBeAdded <= 0) continue;

				int amountToAdd = Math.Min(amountCanBeAdded, remainingAmountToAdd);
				itemInInventory.AddToStack(amountToAdd);
				remainingAmountToAdd -= amountToAdd;

				if (remainingAmountToAdd <= 0) break;
			}

			// Inventory cannot add remaining item(s)
			if (remainingAmountToAdd > 0) Debug.LogWarning("NOTIFICATION: Player inventory was unable to add remaining items.");
			break;
		}

		for (int i = 0; i < items.Length; i++)
		{
			if (items[i]) Debug.Log($"{i}: {items[i].Name}, {items[i].StackSize}");
			else Debug.Log($"{i}: Null");
		}
	}

	void Awake()
	{
		InitSingleton();
		items = new Item[hotbarSize + inventorySize];
	}

	void OnSelectHotbarSlot1() => SelectHotbarSlot(1);
	void OnSelectHotbarSlot2() => SelectHotbarSlot(2);
	void OnSelectHotbarSlot3() => SelectHotbarSlot(3);
	void OnSelectHotbarSlot4() => SelectHotbarSlot(4);
	void OnSelectHotbarSlot5() => SelectHotbarSlot(5);
	void OnSelectHotbarSlot6() => SelectHotbarSlot(6);
	void OnSelectHotbarSlot7() => SelectHotbarSlot(7);
	void OnSelectHotbarSlot8() => SelectHotbarSlot(8);
	void OnSelectHotbarSlot9() => SelectHotbarSlot(9);
	void OnSelectHotbarSlot10() => SelectHotbarSlot(10);
}
