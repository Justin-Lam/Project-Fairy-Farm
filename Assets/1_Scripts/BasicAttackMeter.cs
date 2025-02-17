using UnityEngine;

public class BasicAttackMeter : MonoBehaviour
{
	[SerializeField] Vector2 offsetFromMouse;
	Canvas canvas;

	void Awake()
	{
		canvas = GetComponent<Canvas>();
	}

	void Update()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = mousePos + offsetFromMouse;
	}
}
