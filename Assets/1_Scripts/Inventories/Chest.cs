using System;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
	public static event Action OnOpened;

	public void Interact()
	{
		ChestInventoryUI.instance.Open();
		OnOpened?.Invoke();
	}
}
