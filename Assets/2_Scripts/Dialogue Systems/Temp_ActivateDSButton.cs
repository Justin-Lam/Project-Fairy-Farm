using UnityEngine;
using UnityEngine.UI;

public class Temp_ActivateDSButton : MonoBehaviour
{
	Button button;
	public void Activate()
	{
		if (DialogueSystem_Full.Instance) DialogueSystem_Full.Instance.Activate();
		else if (DialogueSystem_Lite.Instance) DialogueSystem_Lite.Instance.Activate();
	}

	void Awake()
	{
		button = GetComponent<Button>();
	}
	void OnEnable()
	{
		DialogueSystem_Lite.OnActivate += SetUninteractable;
		DialogueSystem_Lite.OnDeactivate += SetInteractable;
		DialogueSystem_Full.OnActivate += SetUninteractable;
		DialogueSystem_Full.OnDeactivate += SetInteractable;
	}
	void OnDisable()
	{
		DialogueSystem_Lite.OnActivate -= SetUninteractable;
		DialogueSystem_Lite.OnDeactivate -= SetInteractable;
		DialogueSystem_Full.OnActivate += SetUninteractable;
		DialogueSystem_Full.OnDeactivate += SetInteractable;
	}
	void SetInteractable()
	{
		button.interactable = true;
	}
	void SetUninteractable()
	{
		button.interactable = false;
	}
}
