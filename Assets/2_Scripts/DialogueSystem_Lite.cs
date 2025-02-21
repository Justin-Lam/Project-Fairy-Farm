using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueSystem_Lite : MonoBehaviour
{
	Canvas canvas;
	PlayerInput playerInput;

	public static event Action OnActivate;
	public static event Action OnDeactivate;

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

		canvas = GetComponent<Canvas>();
		playerInput = GetComponent<PlayerInput>();

		canvas.enabled = false;
		playerInput.enabled = false;
	}

	public void Activate()
	{
		OnActivate?.Invoke();
		canvas.enabled = true;
		playerInput.enabled = true;
	}

	void Deactivate()
	{
		OnDeactivate?.Invoke();
		canvas.enabled = false;
		playerInput.enabled = false;
	}
}
