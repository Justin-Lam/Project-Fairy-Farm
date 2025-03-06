using UnityEngine;

public class Hotbar : MonoBehaviour
{
	[SerializeField] InventorySlot[] slots;
	[SerializeField] Transform selectedSlotIndicator;

	public static Hotbar Instance { get; private set; } void InitSingleton() { if (Instance && Instance != this) Destroy(gameObject); else Instance = this; }

	public void MoveIndicatorToSlot(int index) { selectedSlotIndicator.transform.position = slots[index].transform.position; }

	void Awake()
	{
		InitSingleton();
	}
}
