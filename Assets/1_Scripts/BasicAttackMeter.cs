using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicAttackMeter : MonoBehaviour
{
	[SerializeField] Vector2 offsetFromMouse;
	Canvas canvas;
	Slider slider;
	TMP_Text text;

	void Awake()
	{
		canvas = GetComponent<Canvas>();
		slider = GetComponentInChildren<Slider>();
		text = GetComponentInChildren<TMP_Text>();
	}

	void OnEnable()
	{
		Player_BasicAttack.OnCharge += () => canvas.enabled = true;
		Player_BasicAttack.OnFire += () => canvas.enabled = false;
	}
	void OnDisable()
	{
		Player_BasicAttack.OnCharge -= () => canvas.enabled = true;
		Player_BasicAttack.OnFire -= () => canvas.enabled = false;
	}

	void Update()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = mousePos + offsetFromMouse;

		float counter = Player_BasicAttack.Instance.chargeCounter;
		float duration = Player_BasicAttack.Instance.chargeDuration;
		slider.value = counter / duration;

		if (counter >= duration) text.enabled = true;
		else text.enabled = false;
	}
}
