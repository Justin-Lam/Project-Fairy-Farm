using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	[Header("Movement")]
	[SerializeField] float moveSpeed;
	Rigidbody2D rb;
	Vector2 moveDir;

	// Called by the Player Input component
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
		rb.velocity = moveDir * moveSpeed;
	}
}
