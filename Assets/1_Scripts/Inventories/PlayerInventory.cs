using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	Canvas canvas;
	[field: SerializeField, HideInInspector] public InventorySlot[] slots { get; private set; }


	void OnToggle()
	{
		canvas.enabled = !canvas.enabled;
	}

	void OnExit()
	{
		if (canvas.enabled) canvas.enabled = false;
	}

	void Awake()
	{
		canvas = GetComponent<Canvas>();
		slots = GetComponentsInChildren<InventorySlot>();

		canvas.enabled = false;
	}
}
