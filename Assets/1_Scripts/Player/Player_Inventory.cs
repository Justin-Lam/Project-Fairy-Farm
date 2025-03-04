using UnityEngine;

public class Player_Inventory : MonoBehaviour
{
	float useItemCounter = 0;

	public static Player_Inventory instance { get; private set; }
	void InitSingleton()
	{
		if (instance && instance != this) Destroy(gameObject);
		else instance = this;
	}

	void Awake()
	{
		InitSingleton();
	}
	void Update()
	{
		if (useItemCounter > 0) useItemCounter -= Time.deltaTime;
	}

	void OnUseItem()
	{
		Item selectedItem = Hotbar.Instance.SelectedItem;

		if (!selectedItem) return;
		if (useItemCounter > 0) return;

		selectedItem.Use();
		useItemCounter = selectedItem.useCooldown;
	}

	public void AddItem(Item itemSO)
	{
		if (Hotbar.Instance.TryStackItem(itemSO)) return;
		if (PlayerInventoryUI.instance.TryStackItem(itemSO)) return;
		if (Hotbar.Instance.TryCreateStack(itemSO)) return;
		else PlayerInventoryUI.instance.TryCreateStack(itemSO);
	}
}
