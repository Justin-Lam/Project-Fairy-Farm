using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
	NPC_TextBox textBox;

	void Awake()
	{
		textBox = GetComponentInChildren<NPC_TextBox>();
	}

	public void Interact()
	{
		textBox.Display("Hi!");
	}
}
