using UnityEngine;

public class PlayerInventoryAndHotbar : MonoBehaviour
{
	[Header("Inventory & Hotbar")]
	[SerializeField] InventorySlot[] slots;
	
	[Header("Hotbar")]
	[SerializeField] Transform indicator;

	public static PlayerInventoryAndHotbar Instance { get; private set; } void InitSingleton() { if (Instance && Instance != this) Destroy(gameObject); else Instance = this; }

	public void MoveHotbarIndicatorToSlot(int index) { indicator.transform.position = slots[index].transform.position; }

	void Awake()
	{
		InitSingleton();
	}
}
