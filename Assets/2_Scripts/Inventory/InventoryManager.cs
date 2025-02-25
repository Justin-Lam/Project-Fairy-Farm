using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	[SerializeField] Image background;
	[SerializeField] Canvas playerInventory;

	public static event Action OnPlayerInventoryOpened;
	public static event Action OnPlayerInventoryClosed;

	void OnToggleInventory()
	{
		background.enabled = !background.enabled;
		playerInventory.enabled = !playerInventory.enabled;

		if (background.enabled) OnPlayerInventoryOpened?.Invoke();
		else OnPlayerInventoryClosed?.Invoke();
	}
	void OnExit()
	{
		if (!background.enabled) return;

		background.enabled = false;
		playerInventory.enabled = false;
		OnPlayerInventoryClosed?.Invoke();
	}

	void Awake()
	{
		background.enabled = false;
		playerInventory.enabled = false;
	}
}
