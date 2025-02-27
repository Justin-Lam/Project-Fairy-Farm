using UnityEngine;
using UnityEngine.InputSystem;

public class Hotbar : MonoBehaviour
{
	[SerializeField] Transform selectedSlotIndicator;
	[field: SerializeField, HideInInspector] public InventorySlot[] slots { get; private set; }
	int selectedSlotIndex = 0;

	void Awake()
	{
		slots = GetComponentsInChildren<InventorySlot>();
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
