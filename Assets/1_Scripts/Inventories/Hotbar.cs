using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Hotbar : MonoBehaviour
{
	[SerializeField] Image background;
	[SerializeField] Transform selectedSlotIndicator;
	[SerializeField] GameObject inventoryItemPrefab;
	InventorySlot[] slots;
	int selectedSlotIndex = 0;

	public static Hotbar instance { get; private set; }
	void InitSingleton()
	{
		if (instance && instance != this) Destroy(gameObject);
		else instance = this;
	}

	void OnScrollSlots(InputValue iv)
	{
		if (iv.Get<float>() > 0) selectedSlotIndex = (selectedSlotIndex + 1) % slots.Length;
		else if (iv.Get<float>() < 0) selectedSlotIndex = (selectedSlotIndex - 1 + slots.Length) % slots.Length;

		selectedSlotIndicator.transform.position = slots[selectedSlotIndex].transform.position;
	}
	void SelectSlot(int num)
	{
		selectedSlotIndex = num - 1;
		selectedSlotIndicator.transform.position = slots[selectedSlotIndex].transform.position;
	}

	void ShowBackground() { background.enabled = true; }
	void HideBackground() { background.enabled = false; }

	public bool TryStackItem(ItemSO itemSO)
	{
		foreach (InventorySlot slot in slots)
		{
			if (!slot.HasItem()) continue;

			InventoryItem item = slot.GetItem();
			if (item.itemSO == itemSO && item.amount < itemSO.maxStackSize)
			{
				item.IncrementAmount();
				return true;
			}
		}

		return false;
	}
	public bool TryCreateStack(ItemSO itemSO)
	{
		foreach (InventorySlot slot in slots)
		{
			if (slot.HasItem()) continue;

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
		slots = GetComponentsInChildren<InventorySlot>();
	}
	void OnEnable()
	{
		PlayerInventoryUI.OnOpened += HideBackground;
		PlayerInventoryUI.OnClosed += ShowBackground;
	}
	void OnDisable()
	{
		PlayerInventoryUI.OnOpened -= HideBackground;
		PlayerInventoryUI.OnClosed -= ShowBackground;
	}

	void OnSelectSlot1()
	{
		SelectSlot(1);
	}
	void OnSelectSlot2()
	{
		SelectSlot(2);
	}
	void OnSelectSlot3()
	{
		SelectSlot(3);
	}
	void OnSelectSlot4()
	{
		SelectSlot(4);
	}
	void OnSelectSlot5()
	{
		SelectSlot(5);
	}
	void OnSelectSlot6()
	{
		SelectSlot(6);
	}
	void OnSelectSlot7()
	{
		SelectSlot(7);
	}
	void OnSelectSlot8()
	{
		SelectSlot(8);
	}
	void OnSelectSlot9()
	{
		SelectSlot(9);
	}
	void OnSelectSlot10()
	{
		SelectSlot(10);
	}
}
