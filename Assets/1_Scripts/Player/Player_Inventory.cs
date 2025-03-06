using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Inventory : MonoBehaviour
{
	[SerializeField] int hotbarSize;
	[SerializeField] int inventorySize;
	ItemStack[] itemStacks;
	int selectedItemIndex = 0;
	float useItemCooldownCounter = 0;

	public static Player_Inventory Instance { get; private set; } void InitSingleton() { if (Instance && Instance != this) Destroy(gameObject); else Instance = this; }

	void OnUseItem()
	{
		Item selectedItem = itemStacks[selectedItemIndex].Item;

		if (!selectedItem) return;
		if (useItemCooldownCounter > 0) return;

		selectedItem.Use();
		useItemCooldownCounter = selectedItem.UseCooldown;
	}

	void OnScrollHotbar(InputValue iv)
	{
		if (iv.Get<float>() > 0) selectedItemIndex = (selectedItemIndex + 1) % hotbarSize;
		else if (iv.Get<float>() < 0) selectedItemIndex = (selectedItemIndex - 1 + hotbarSize) % hotbarSize;
		PlayerInventoryAndHotbar.Instance.MoveHotbarIndicatorToSlot(selectedItemIndex);
	}
	void SelectHotbarSlot(int num)
	{
		selectedItemIndex = num - 1;
		PlayerInventoryAndHotbar.Instance.MoveHotbarIndicatorToSlot(selectedItemIndex);
	}

	public void AddOneItem(Item item) { AddItem(item, 1); }
	public void AddFiveItems(Item item) { AddItem(item, 5); }
	public void DisplayInventory()
	{
		for (int i = 0; i < itemStacks.Length; i++)
		{
			if (itemStacks[i].Item) Debug.Log($"{i}: {itemStacks[i].Item} (x{itemStacks[i].Size})");
			else Debug.Log($"{i}: Empty");
		}
	}

	public void AddItem(Item item, int amount)
	{
		int remainingAmountToAdd = amount;

		// Try to stack
		foreach (ItemStack stack in itemStacks)
		{
			if (!stack.Item) continue;
			if (stack.Item != item) continue;

			int amountCanBeAdded = item.MaxStackSize - stack.Size;
			if (amountCanBeAdded <= 0) continue;

			int amountToAdd = Math.Min(amountCanBeAdded, remainingAmountToAdd);
			stack.Add(amountToAdd);
			remainingAmountToAdd -= amountToAdd;

			if (remainingAmountToAdd <= 0) return;
		}

		// Try to create stack
		foreach (ItemStack stack in itemStacks)
		{
			if (stack.Item) continue;

			int amountToAdd = Math.Min(item.MaxStackSize, remainingAmountToAdd);
			stack.Set(item, amountToAdd);
			remainingAmountToAdd -= amountToAdd;

			if (remainingAmountToAdd <= 0) return;
		}		

		// Handle remaining items that inventory can't add
		if (remainingAmountToAdd > 0) Debug.LogWarning("NOTIFICATION: Player inventory was unable to add remaining items.");
	}

	void Awake()
	{
		InitSingleton();

		itemStacks = new ItemStack[hotbarSize + inventorySize];
		for (int i = 0; i < itemStacks.Length; i++) { itemStacks[i] = new ItemStack(); }
	}
	void Update()
	{
		if (useItemCooldownCounter > 0) useItemCooldownCounter -= Time.deltaTime;
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
