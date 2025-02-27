using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
	[SerializeField] GameObject inventoryItemPrefab;
	Canvas canvas;
	InventorySlot[] slots;

	public static PlayerInventoryUI instance { get; private set; }
	void InitSingleton()
	{
		if (instance && instance != this) Destroy(gameObject);
		else instance = this;
	}

	void OnToggle()
	{
		canvas.enabled = !canvas.enabled;
	}

	void OnExit()
	{
		if (canvas.enabled) canvas.enabled = false;
	}

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
			item.Init(itemSO);
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
}
