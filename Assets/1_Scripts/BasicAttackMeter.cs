using Unity.VisualScripting;
using UnityEngine;

public class BasicAttackMeter : MonoBehaviour
{
	[SerializeField] Vector2 offsetFromMouse;
	Canvas canvas;

	void Awake()
	{
		canvas = GetComponent<Canvas>();
	}

	void OnEnable()
	{
		PlayerBasicAttack.OnCharge += () => canvas.enabled = true;
		PlayerBasicAttack.OnFire += () => canvas.enabled = false;
	}
	void OnDisable()
	{
		PlayerBasicAttack.OnCharge -= () => canvas.enabled = true;
		PlayerBasicAttack.OnFire -= () => canvas.enabled = false;
	}

	void Update()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = mousePos + offsetFromMouse;
	}
}
