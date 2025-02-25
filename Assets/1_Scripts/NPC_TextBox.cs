using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class NPC_TextBox : MonoBehaviour
{
	RectTransform rectTransform;
	Canvas canvas;
	TMP_Text text;
	RectTransform text_RectTransform;

	Coroutine hideCountdownCoroutine;

	void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvas = GetComponent<Canvas>();
		text = GetComponentInChildren<TMP_Text>();
		text_RectTransform = text.GetComponent<RectTransform>();

		canvas.enabled = false;
	}

	public void Display(string text, float duration)
	{
		this.text.text = text;
		LayoutRebuilder.ForceRebuildLayoutImmediate(text_RectTransform);	// update rect transform immediately instead of on next frame

		rectTransform.sizeDelta = ((RectTransform)this.text.transform).sizeDelta;

		canvas.enabled = true;

		if (hideCountdownCoroutine != null) StopCoroutine(hideCountdownCoroutine);
		hideCountdownCoroutine = StartCoroutine(HideCountdown(duration));
	}

	IEnumerator HideCountdown(float duration)
	{
		yield return new WaitForSeconds(duration);
		canvas.enabled = false;
	}
}
