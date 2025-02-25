using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueSystem_Lite : MonoBehaviour
{
	Canvas canvas_DS;
	PlayerInput playerInput;
	[SerializeField] Canvas canvas_Player1;
	[SerializeField] Canvas canvas_Player2;
	[SerializeField] Image image;

	public static event Action OnActivated;
	public static event Action OnDeactivated;

	[Header("Singleton Pattern")]
	private static DialogueSystem_Lite instance;
	public static DialogueSystem_Lite Instance => instance;
	void InitSingleton()
	{
		if (instance && instance != this) Destroy(gameObject);
		else instance = this;
	}

	// "On" functions are called by the Player Input component
	void OnContinue()
	{
		Deactivate();
	}

	void Awake()
	{
		InitSingleton();

		canvas_DS = GetComponent<Canvas>();
		playerInput = GetComponent<PlayerInput>();

		canvas_DS.enabled = false;
		playerInput.enabled = false;
		canvas_Player2.enabled = false;
		image.enabled = false;
	}

	public void Activate()
	{
		OnActivated?.Invoke();
		canvas_DS.enabled = true;
		playerInput.enabled = true;
	}

	void Deactivate()
	{
		OnDeactivated?.Invoke();
		canvas_DS.enabled = false;
		playerInput.enabled = false;
		canvas_Player2.enabled = false;
		image.enabled = false;
	}
}
