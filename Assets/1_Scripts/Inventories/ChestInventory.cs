using UnityEngine;

public class ChestInventory : MonoBehaviour
{
	Canvas canvas;

	void Awake()
	{
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}
}
