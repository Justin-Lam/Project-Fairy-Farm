using System;
using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
	Item[] items = new Item[40];

	public static Player_Inventory Instance { get; private set; }
	void InitSingleton()
	{
		if (Instance && Instance != this) Destroy(gameObject);
		else Instance = this;
	}

	void Awake()
	{
		Debug.Log(items);
	}

	public void Add(Item item, int amount)
	{
		Item itemToAdd = item;
		int remainingAmountToAdd = amount;

		while (remainingAmountToAdd > 0)
		{
			// Try to stack
			foreach (Item itemInInventory in items)
			{
				if (itemInInventory.Name != itemToAdd.Name) continue;

				int amountThatCanBeAdded = itemInInventory.MaxStackSize - itemInInventory.StackSize;
				if (amountThatCanBeAdded <= 0) continue;

				int amountToAdd = Math.Min(amountThatCanBeAdded, remainingAmountToAdd);
				itemInInventory.AddToStack(amountToAdd);
				remainingAmountToAdd -= amountToAdd;

				if (remainingAmountToAdd <= 0) break;
			}

			if (remainingAmountToAdd <= 0) break;

			// Try to create stack
			for (int i = 0; i < items.Length; i++)
			{
				Item itemInInventory = items[i];

				if (itemInInventory) continue;

				items[i] = Instantiate(itemToAdd);
				remainingAmountToAdd--;

				if (remainingAmountToAdd <= 0) break;

				int amountThatCanBeAdded = itemInInventory.MaxStackSize - itemInInventory.StackSize;
				if (amountThatCanBeAdded <= 0) continue;

				int amountToAdd = Math.Min(amountThatCanBeAdded, remainingAmountToAdd);
				itemInInventory.AddToStack(amountToAdd);
				remainingAmountToAdd -= amountToAdd;

				if (remainingAmountToAdd <= 0) break;
			}

			// Inventory cannot add remaining item(s)
			if (remainingAmountToAdd > 0) Debug.Log("NOTIFICATION: Player inventory was unable to add remaining items.");
			break;
		}
	}
}
