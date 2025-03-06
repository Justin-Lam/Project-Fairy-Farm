using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Inventory : MonoBehaviour
{
	[SerializeField] int hotbarSize;
	[SerializeField] int inventorySize;

	PlayerInventoryAndHotbar ui;
	InventorySlot[] slots;
	int selectedHotbarSlotIndex = 0;
	float useItemCooldownCounter = 0;

	public static Player_Inventory Instance { get; private set; } void InitSingleton() { if (Instance && Instance != this) Destroy(gameObject); else Instance = this; }

	void OnUseItem()
	{
		InventorySlot slot = slots[selectedHotbarSlotIndex];
		if (slot.IsEmpty) return;
		if (useItemCooldownCounter > 0) return;

		Item selectedItem = slot.ItemStack.Item;
		selectedItem.Use();
		useItemCooldownCounter = selectedItem.UseCooldown;
	}

	void OnScrollHotbar(InputValue iv)
	{
		if (iv.Get<float>() > 0) selectedHotbarSlotIndex = (selectedHotbarSlotIndex + 1) % hotbarSize;
		else if (iv.Get<float>() < 0) selectedHotbarSlotIndex = (selectedHotbarSlotIndex - 1 + hotbarSize) % hotbarSize;
		ui.MoveHotbarIndicatorToSlot(selectedHotbarSlotIndex);
	}
	void SelectHotbarSlot(int num)
	{
		selectedHotbarSlotIndex = num - 1;
		ui.MoveHotbarIndicatorToSlot(selectedHotbarSlotIndex);
	}

	public void AddOneItem(Item item) { AddItem(item, 1); }
	public void AddFiveItems(Item item) { AddItem(item, 5); }

	public void AddItem(Item item, int amount)
	{
		int remainingAmountToAdd = amount;

		// Try to stack
		foreach (InventorySlot slot in slots)
		{
			if (slot.IsEmpty) continue;
			if (slot.ItemStack.Item != item) continue;

			int amountCanBeAdded = item.MaxStackSize - slot.ItemStack.Size;
			if (amountCanBeAdded <= 0) continue;

			int amountToAdd = Math.Min(amountCanBeAdded, remainingAmountToAdd);
			slot.ItemStack.AddToStack(amountToAdd);
			remainingAmountToAdd -= amountToAdd;

			if (remainingAmountToAdd <= 0) return;
		}

		// Try to create stack
		foreach (InventorySlot slot in slots)
		{
			if (!slot.IsEmpty) continue;

			int amountToAdd = Math.Min(item.MaxStackSize, remainingAmountToAdd);
			slot.CreateItemStack(item, amountToAdd);
			remainingAmountToAdd -= amountToAdd;

			if (remainingAmountToAdd <= 0) return;
		}		

		// Handle remaining items that inventory can't add
		if (remainingAmountToAdd > 0) Debug.LogWarning("NOTIFICATION: Player inventory was unable to add remaining items.");
	}

	void Awake()
	{
		InitSingleton();
	}
	void Start()
	{
		ui = PlayerInventoryAndHotbar.Instance;
		slots = PlayerInventoryAndHotbar.Instance.slots;
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
