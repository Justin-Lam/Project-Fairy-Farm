using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInventoryUI : MonoBehaviour
{	
	// Done vvv
	[SerializeField] GameObject inventoryItemPrefab;
	Canvas canvas;
	InventorySlot[] slots;

	public static event Action OnOpened;
	public static event Action OnClosed;

	public static PlayerInventoryUI instance { get; private set; }
	void InitSingleton()
	{
		if (instance && instance != this) Destroy(gameObject);
		else instance = this;
	}

	void OnToggle()
	{
		canvas.enabled = !canvas.enabled;
		if (canvas.enabled) OnOpened?.Invoke();
		else OnClosed?.Invoke();
	}
	void OnExit()
	{
		if (canvas.enabled)
		{
			canvas.enabled = false;
			OnClosed?.Invoke();
		}
	}
	// Done ^^^

	void Open()
	{
		canvas.enabled = true;
		OnOpened?.Invoke();
	}

	public bool TryStackItem(Item itemSO)
	{
		foreach (InventorySlot slot in slots)
		{
			if (!slot.HasInventoryItem()) continue;

			InventoryItem item = slot.GetInventoryItem();
			if (item.item == itemSO && item.amount < itemSO.MaxStackSize)
			{
				item.IncrementAmount();
				return true;
			}
		}

		return false;
	}
	public bool TryCreateStack(Item itemSO)
	{
		foreach (InventorySlot slot in slots)
		{
			if (slot.HasInventoryItem()) continue;

			GameObject itemGO = Instantiate(inventoryItemPrefab, slot.transform);
			InventoryItem item = itemGO.GetComponent<InventoryItem>();
			item.Set(itemSO);
			return true;
		}

		return false;
	}

	void Awake()
	{
		InitSingleton();

		canvas = GetComponent<Canvas>();
		slots = GetComponentsInChildren<InventorySlot>();

		canvas.enabled = false;
	}
	void OnEnable()
	{
		Chest.OnOpened += Open;
	}
	void OnDisable()
	{
		Chest.OnOpened -= Open;
	}
}
