using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnowQueenHealthBar : MonoBehaviour
{
	[SerializeField] Slider slider;
	[SerializeField] TMP_Text text;

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
		float maxhealth = SnowQueen_Health.Instance.maxHealth;
		float health = SnowQueen_Health.Instance.health;

		slider.value =  health / maxhealth;
		text.text = $"{health} / {maxhealth}";
	}
}
