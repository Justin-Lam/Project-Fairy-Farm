using UnityEngine;

public class Player_Sword : MonoBehaviour
{
	[SerializeField] float damage;
	[SerializeField] float cooldown;
	[SerializeField] float[] comboDurations;
	float cooldownCounter;

	void OnAttack()
	{
		if (cooldownCounter > 0) return;

		Debug.Log("attack 1");

		cooldownCounter = cooldown;
	}

	void Update()
	{
		if (cooldownCounter > 0) cooldownCounter -= Time.deltaTime;
	}
}
