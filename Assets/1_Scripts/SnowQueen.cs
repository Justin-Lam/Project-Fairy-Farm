using UnityEngine;

public class SnowQueen : MonoBehaviour
{
	[SerializeField] float maxHealth;
	float health;

	StateMachine stateMachine;

	void Awake()
	{
		health = maxHealth;
	}
}
