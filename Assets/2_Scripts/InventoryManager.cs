using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	[SerializeField] Image background;
	[SerializeField] Canvas playerInventory;

	void OnToggleInventory()
	{
		background.enabled = !background.enabled;
		playerInventory.enabled = !playerInventory.enabled;
	}

	void Awake()
	{
		background.enabled = false;
		playerInventory.enabled = false;
	}
}
