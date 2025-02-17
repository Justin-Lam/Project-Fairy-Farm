using System;
using UnityEngine;

public class PlayerBasicAttack : MonoBehaviour
{
	[SerializeField] float chargeDuration;
	[SerializeField] float velocity;
	[SerializeField] float lifespan;
	[SerializeField] BasicAttack projectile;
	bool charging = false;
	float chargeCounter = 0;

	public static event Action OnCharge;
	public static event Action OnFire;

	PlayerMovement playerMovementScript;

	// "On" functions are called by the Player Input component
	void OnChargeBasic()
	{
		charging = true;
		OnCharge?.Invoke();
	}
	void OnFireBasic()
	{
		if (chargeCounter >= chargeDuration) Fire();
		chargeCounter = 0;
		charging = false;
		OnFire?.Invoke();
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
		projectile.transform.position = transform.position;
		projectile.gameObject.SetActive(true);
		projectile.Fire(velocity, lifespan);
	}
}
