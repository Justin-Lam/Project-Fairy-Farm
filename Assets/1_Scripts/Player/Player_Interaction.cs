using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
	[SerializeField] CircleCollider2D range;
	[SerializeField] LayerMask layersToCheck;
	float radius;
	bool canInteract = true;

	void OnInteract()
	{
		if (!canInteract) return;

		/*
		 *	Asked ChatGPT about different methods to go about handling interaction
		 *	It recommended to use interfaces and OverlapCircleAll() and gave some example code
		 *	This code is based off of that example code
		 */

		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, layersToCheck);

		IInteractable nearestInteractable = null;
		float leastDist = Mathf.Infinity;
		foreach (Collider2D collider in colliders)
		{
			IInteractable interactable = collider.GetComponent<IInteractable>();	// don't need to do collider.gameobject.GetComponent()
			if (interactable != null)
			{
				float dist = Vector2.Distance(transform.position, collider.transform.position);
				if (dist < leastDist)
				{
					nearestInteractable = interactable;
					leastDist = dist;
				}
			}
		}

		nearestInteractable?.Interact();
	}

	void Awake()
	{
		radius = range.radius;
	}
	void OnEnable()
	{
		PlayerInventoryAndHotbar.OnInventoryOpened += DisableInteract;
		PlayerInventoryAndHotbar.OnInventoryClosed += EnableInteract;
	}
	void OnDisable()
	{
		PlayerInventoryAndHotbar.OnInventoryOpened -= DisableInteract;
		PlayerInventoryAndHotbar.OnInventoryClosed -= EnableInteract;
	}
	void EnableInteract()
	{
		canInteract = true;
	}
	void DisableInteract()
	{
		canInteract = false;
	}
}
