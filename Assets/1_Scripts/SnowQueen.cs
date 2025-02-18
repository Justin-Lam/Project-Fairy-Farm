using System;
using UnityEngine;

public class SnowQueen : MonoBehaviour
{
	[SerializeField] public float maxHealth;
	[HideInInspector] public float health;

	public static event Action OnDamaged;
	public static event Action OnDeath;

	[Header("Singleton Pattern")]
	private static SnowQueen instance;
	public static SnowQueen Instance { get { return instance; } }
	void InitializeSingleton()
	{
		if (instance && instance != this) Destroy(gameObject);
		else instance = this;
	}

	void Awake()
	{
		InitializeSingleton();
		health = maxHealth;
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		OnDamaged?.Invoke();
		if (health < 0) OnDeath?.Invoke();
	}
}
