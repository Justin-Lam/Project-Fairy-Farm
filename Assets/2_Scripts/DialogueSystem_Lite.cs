using System;
using UnityEngine;

public class DialogueSystem_Lite : MonoBehaviour
{
	Canvas canvas;

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

	void Awake()
	{
		InitSingleton();
		canvas = GetComponent<Canvas>();
	}

	public void Activate()
	{
		OnActivate?.Invoke();
		canvas.enabled = true;
	}

	void Deactivate()
	{
		OnDeactivate?.Invoke();
		canvas.enabled = false;
	}
}
