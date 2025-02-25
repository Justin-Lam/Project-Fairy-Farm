using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueSystem_Full : MonoBehaviour
{
	Canvas canvas_DS;
	PlayerInput playerInput;
	[SerializeField] Image image;
	[SerializeField] Image portrait_3L;
	[SerializeField] Image portrait_2L;
	[SerializeField] Image portrait_M;
	[SerializeField] Image portrait_2R;
	[SerializeField] Image portrait_3R;


	public static event Action OnActivated;
	public static event Action OnDeactivated;

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
		image.enabled = false;
		portrait_3L.enabled = false;
		portrait_2L.enabled = false;
		portrait_2R.enabled = false;
		portrait_3R.enabled = false;
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
		image.enabled = false;
		portrait_3L.enabled = false;
		portrait_2L.enabled = false;
		portrait_2R.enabled = false;
		portrait_3R.enabled = false;
	}
}
