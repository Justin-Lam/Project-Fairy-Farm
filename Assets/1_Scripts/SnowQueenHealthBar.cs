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
		SnowQueen.OnDamaged += OnDamaged;
	}
	void OnDisable()
	{
		SnowQueen.OnDamaged -= OnDamaged;
	}

	void OnDamaged()
	{
		healthBar.value = SnowQueen.Instance.health / SnowQueen.Instance.maxHealth;
	}
}
