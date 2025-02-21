using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueSystem_Full : MonoBehaviour
{
	Canvas canvas_DS;
	PlayerInput playerInput;

	public static event Action OnActivate;
	public static event Action OnDeactivate;

	[Header("Singleton Pattern")]
	private static DialogueSystem_Full instance;
	public static DialogueSystem_Full Instance => instance;
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
	}

	public void Activate()
	{
		OnActivate?.Invoke();
		canvas_DS.enabled = true;
		playerInput.enabled = true;
	}

	void Deactivate()
	{
		OnDeactivate?.Invoke();
		canvas_DS.enabled = false;
		playerInput.enabled = false;
	}
}
