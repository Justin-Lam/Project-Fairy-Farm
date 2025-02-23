using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
	[Header("Text Box")]
	[SerializeField, Tooltip("In characters per second")] float speakRate;
	[SerializeField] float minSpeakDuration;
	NPC_TextBox textBox;

	void Awake()
	{
		textBox = GetComponentInChildren<NPC_TextBox>();
	}

	public void Interact()
	{
		string str = "My feet are killing me! Could you uh- hurry and\nbeam up so I get swapped out with another enforcer?";
		textBox.Display(str, minSpeakDuration + str.Length/speakRate);
	}
}
