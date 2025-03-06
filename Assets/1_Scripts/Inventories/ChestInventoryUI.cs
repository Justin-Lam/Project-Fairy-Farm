using UnityEngine;

public class ChestInventoryUI : MonoBehaviour
{
	Canvas canvas;

	public static ChestInventoryUI instance { get; private set; }
	void InitSingleton()
	{
		if (instance && instance != this) Destroy(gameObject);
		else instance = this;
	}

	public void Open() { canvas.enabled = true; }
	void Close() { canvas.enabled = false; }

	void Awake()
	{
		InitSingleton();
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}
	void OnEnable()
	{
		//PlayerInventoryUI.OnClosed += Close;
	}
	void OnDisable()
	{
		//PlayerInventoryUI.OnClosed -= Close;
	}
}
