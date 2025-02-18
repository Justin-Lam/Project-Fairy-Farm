using System;
using UnityEngine;

public class PlayerBasicAttack : MonoBehaviour
{
	[SerializeField] float damage;
	[SerializeField] public float chargeDuration;
	[SerializeField] float velocity;
	[SerializeField] float lifespan;
	[SerializeField] GameObject projectilePrefab;
	bool charging = false;
	[HideInInspector] public float chargeCounter = 0;
	GameObject projectile;

	public static event Action OnCharge;
	public static event Action OnFire;

	PlayerMovement playerMovementScript;

	[Header("Singleton Pattern")]
	private static PlayerBasicAttack instance;
	public static PlayerBasicAttack Instance { get { return instance; } }
	void SetSingletonInstance()
	{
		if (instance != null && instance != this) Destroy(gameObject);
		else instance = this;
	}

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
		SetSingletonInstance();
		projectile = Instantiate(projectilePrefab);
		projectile.SetActive(false);
		playerMovementScript = GetComponent<PlayerMovement>();
	}

	void Update()
	{
		if (charging) chargeCounter += Time.deltaTime;
	}

	void Fire()
	{
		Vector3 offset = new Vector3(0, 0.5f, 0);
		projectile.transform.position = transform.position + offset;
		projectile.SetActive(true);
		projectile.GetComponent<BasicAttack>().Fire(velocity, lifespan);
	}
}
