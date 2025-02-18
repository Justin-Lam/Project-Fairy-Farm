using UnityEngine;
using UnityEngine.UI;

public class SnowQueenHealthBar : MonoBehaviour
{
	Slider healthBar;

	[Header("Singleton Pattern")]
	private static SnowQueenHealthBar instance;
	public static SnowQueenHealthBar Instance { get { return instance; } }
	void InitializeSingleton()
	{
		if (instance && instance != this) Destroy(gameObject);
		else instance = this;
	}

	void Awake()
	{
		InitializeSingleton();
		healthBar = GetComponentInChildren<Slider>();
	}

	void OnEnable()
	{
		SnowQueen_Health.OnDamaged += OnDamaged;
	}
	void OnDisable()
	{
		SnowQueen_Health.OnDamaged -= OnDamaged;
	}

	void OnDamaged()
	{
		healthBar.value = SnowQueen_Health.Instance.health / SnowQueen_Health.Instance.maxHealth;
	}
}
