using System;
using UnityEngine;

public class SnowQueen_Health : MonoBehaviour
{
	[SerializeField] public float maxHealth;
	[HideInInspector] public float health;

	public static event Action OnDamaged;
	public static event Action OnDeath;

	[Header("Singleton Pattern")]
	private static SnowQueen_Health instance;
	public static SnowQueen_Health Instance { get { return instance; } }
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
		if (health < 0) health = 0;
		OnDamaged?.Invoke();
		if (health <= 0) OnDeath?.Invoke();
	}
}
