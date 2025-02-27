using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
	public static Player_Inventory instance { get; private set; }
	void InitSingleton()
	{
		if (instance && instance != this) Destroy(gameObject);
		else instance = this;
	}

	public void AddItem(ItemSO itemSO)
	{
		if (Hotbar.instance.TryStackItem(itemSO)) return;
		if (PlayerInventoryUI.instance.TryStackItem(itemSO)) return;
		if (Hotbar.instance.TryCreateStack(itemSO)) return;
		else PlayerInventoryUI.instance.TryCreateStack(itemSO);
	}

	void Awake()
	{
		InitSingleton();	
	}
}
