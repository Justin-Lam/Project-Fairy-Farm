using UnityEngine;

public class SnowQueen : MonoBehaviour
{
	[SerializeField] int maxHealth;
	int health;

	StateMachine stateMachine;

	void Awake()
	{
		health = maxHealth;
	}
}
