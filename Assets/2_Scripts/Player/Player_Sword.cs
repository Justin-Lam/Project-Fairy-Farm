using UnityEngine;

public class Player_Sword : MonoBehaviour
{
	[System.Serializable] class ComboAttack
	{
		[field: SerializeField] public float damage { get; private set; }
		[field: SerializeField, Tooltip("How long the attack lasts")] public float duration { get; private set; }
		[field: SerializeField, Tooltip("How long the player has from the previous attack to do this one")] public float buffer { get; private set; }
	}

	[SerializeField] ComboAttack[] attackCombo;
	int comboIndex = 0;
	float durationCounter = 0;
	float bufferCounter = 0;

	void OnAttack()
	{
		if (durationCounter > 0) return;  // if in middle of attack, don't attack

		if (comboIndex > 0 && bufferCounter <= 0) comboIndex = 0;	// cancel combo

		Debug.Log($"Attack {comboIndex}"); // execute attack

		int nextIndex = (comboIndex + 1) % attackCombo.Length;
		ComboAttack attack = attackCombo[comboIndex];
		ComboAttack nextAttack = attackCombo[nextIndex];

		durationCounter = attack.duration;
		bufferCounter = attack.duration + nextAttack.buffer;
		comboIndex = nextIndex;
	}

	void Update()
	{
		if (durationCounter > 0) durationCounter -= Time.deltaTime;
		if (bufferCounter > 0) bufferCounter -= Time.deltaTime;
	}
}
