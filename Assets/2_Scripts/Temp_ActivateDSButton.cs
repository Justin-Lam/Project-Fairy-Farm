using UnityEngine;
using UnityEngine.UI;

public class Temp_ActivateDSButton : MonoBehaviour
{
	Button button;

	void Awake()
	{
		button = GetComponent<Button>();
	}

	void OnEnable()
	{
		DialogueSystem_Lite.OnActivate += () => button.interactable = false;
		DialogueSystem_Lite.OnDeactivate += () => button.interactable = true;
	}
	void OnDisable()
	{
		DialogueSystem_Lite.OnActivate -= () => button.interactable = false;
		DialogueSystem_Lite.OnDeactivate -= () => button.interactable = true;
	}

	public void Activate()
	{
		DialogueSystem_Lite.Instance.Activate();
	}
}
