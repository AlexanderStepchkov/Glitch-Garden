using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOutTitle : MonoBehaviour {

	public float fadeOutSeconds = 1.0f;
	public float fadeDelay = 2.0f;

	public Color textColor;

	private Text title;

	void Awake() {
		title = GetComponent<Text> ();
		textColor = title.color;
	}

	void Update() {
		if (Time.timeSinceLevelLoad < fadeOutSeconds + fadeDelay && Time.timeSinceLevelLoad > fadeDelay) {
			float newAlpha = textColor.a - Time.deltaTime / fadeOutSeconds;
			textColor.a = newAlpha;
			title.color = textColor;
		} else if (Time.timeSinceLevelLoad > fadeOutSeconds + fadeDelay) {
			gameObject.SetActive (false);
		}
	}
}
