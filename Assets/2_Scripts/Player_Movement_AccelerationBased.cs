using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement_AccelerationBased : MonoBehaviour
{
	[SerializeField] float maxVelocity;
	[SerializeField] float acceleration;
	[SerializeField] float turningAccelMultiplier;
	[SerializeField][Tooltip("(in degrees)")] float multiplierMinThreshold;
	[SerializeField] float deceleration;
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

	private void Update()
	{
		Debug.Log(rb.velocity.magnitude);
	}

	void FixedUpdate()
	{
		if (moveDir != Vector2.zero) Accelerate();
		else Decelerate();
	}

	void Accelerate()
	{
		// Code based off of https://www.reddit.com/r/Unity2D/comments/16w3v3s/comment/k2un48s/?utm_source=share&utm_medium=web3x&utm_name=web3xcss&utm_term=1&utm_content=share_button

		// Get the direction we need to go in order to get to where we want to go (deltaVelocity)
		Vector2 currentVelocity = rb.velocity;
		Vector2 targetVelocity = moveDir * maxVelocity;
		Vector2 deltaVelocity = targetVelocity - currentVelocity;

		// Get the acceleration vector and make sure it doesn't overshoot the amount we need to go
		float multiplier = (Vector2.Angle(currentVelocity, moveDir) > multiplierMinThreshold) ? turningAccelMultiplier : 1f;
		Vector2 accelerationVector = deltaVelocity.normalized * acceleration * multiplier * Time.deltaTime;
		if (accelerationVector.sqrMagnitude > deltaVelocity.sqrMagnitude) accelerationVector = deltaVelocity;	// sqrMagnitude is faster to get than actual magnitude

		rb.velocity += accelerationVector;
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
	}

	void Decelerate()
	{
		// Code based from https://www.reddit.com/r/Unity2D/comments/16w3v3s/comment/k2un48s/?utm_source=share&utm_medium=web3x&utm_name=web3xcss&utm_term=1&utm_content=share_button

		Vector2 decelerationVector = -rb.velocity.normalized * deceleration * Time.deltaTime;
		
		rb.velocity += decelerationVector;
		if (Vector2.Dot(rb.velocity, decelerationVector) > 0f) rb.velocity = Vector2.zero;	// if now going backwards (the vectors point in the same direction)
	}
}
