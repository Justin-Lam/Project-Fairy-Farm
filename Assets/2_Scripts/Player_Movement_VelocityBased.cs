using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement_VelocityBased : MonoBehaviour
{
	[SerializeField] float speed;
	Rigidbody2D rb;
	Vector2 moveDir;

	// "On" functions are called by the Player Input component
	void OnMove(InputValue iv)
	{
		moveDir = iv.Get<Vector2>();
	}

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		rb.velocity = moveDir * speed;
	}
}
