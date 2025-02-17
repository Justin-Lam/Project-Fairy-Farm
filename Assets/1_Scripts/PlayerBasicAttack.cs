using UnityEngine;

public class PlayerBasicAttack : MonoBehaviour
{
	[SerializeField] float chargeDuration;
	bool charging = false;
	float chargeCounter = 0;

	PlayerMovement playerMovementScript;

	// "On" functions are called by the Player Input component
	void OnChargeBasic()
	{
		charging = true;
		playerMovementScript.canMove = false;
	}
	void OnFireBasic()
	{
		if (chargeCounter >= chargeDuration) Fire();
		chargeCounter = 0;
		charging = false;
		playerMovementScript.canMove = true;
	}

	void Awake()
	{
		playerMovementScript = GetComponent<PlayerMovement>();
	}

	void Update()
	{
		if (charging) chargeCounter += Time.deltaTime;
	}

	void Fire()
	{

	}
}
