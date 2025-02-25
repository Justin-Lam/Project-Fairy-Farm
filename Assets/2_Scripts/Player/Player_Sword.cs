using System;
using UnityEngine;

public class Player_Sword : MonoBehaviour
{
	[System.Serializable] class ComboAttack
	{
		[field: SerializeField] public float damage { get; private set; }
		[field: SerializeField, Tooltip("How long the attack lasts")] public float duration { get; private set; }
		[field: SerializeField, Tooltip("How long the player has from the previous attack to do this one")] public float buffer { get; private set; }
		[field: SerializeField] public float moveForce { get; private set; }
	}

	[SerializeField] ComboAttack[] attackCombo;
	int comboIndex = 0;
	float durationCounter = 0;
	float bufferCounter = 0;

	Rigidbody2D rb;

	public static event Action OnAttackStart;
	public static event Action OnAttackEnd;

	void OnAttack()
	{
		if (durationCounter > 0) return;  // if in middle of attack, don't attack

		OnAttackStart?.Invoke();

		if (comboIndex > 0 && bufferCounter <= 0) comboIndex = 0;   // cancel combo

		int nextIndex = (comboIndex + 1) % attackCombo.Length;
		ComboAttack attack = attackCombo[comboIndex];
		ComboAttack nextAttack = attackCombo[nextIndex];

		Debug.Log($"Attack {comboIndex}");
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 mouseDir = mousePos - (Vector2)transform.position;
		rb.AddForce(mouseDir.normalized * attack.moveForce, ForceMode2D.Impulse);

		durationCounter = attack.duration;
		bufferCounter = attack.duration + nextAttack.buffer;
		comboIndex = nextIndex;

	}
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		if (durationCounter > 0) durationCounter -= Time.deltaTime;
		if (durationCounter <= 0) OnAttackEnd?.Invoke();

		if (bufferCounter > 0) bufferCounter -= Time.deltaTime;
	}
}
