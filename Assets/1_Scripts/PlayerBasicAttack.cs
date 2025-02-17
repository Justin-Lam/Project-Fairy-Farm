using UnityEngine;

public class PlayerBasicAttack : MonoBehaviour
{
	bool charging = false;
	float chargeDuration = 0;

	// "On" functions are called by the Player Input component
	void OnChargeBasic()
	{
		charging = true;
	}
	void OnFireBasic()
	{
		Fire();
		charging = false;
	}

	void Update()
	{
		if (charging) chargeDuration += Time.deltaTime;
	}

	void Fire()
	{

	}
}
