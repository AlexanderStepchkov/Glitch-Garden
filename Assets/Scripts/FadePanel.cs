using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour {

	public float fadeInSeconds;
	public float fadeOutSeconds;

	private bool isFadingIn = false;
	private bool isFadingOut = false;
	private Image panelImage;
	private Color fadeColor = Color.black;

	void Awake() {
		panelImage = GetComponent<Image> ();
	}

	void Start() {
		FadeIn ();
	}

	public void FadeIn() {
		fadeColor = Color.black;
		isFadingIn = true;
		isFadingOut = false;
		gameObject.SetActive (true);
	}

	public void FadeOut() {
		fadeColor = Color.clear;
		isFadingIn = false;
		isFadingOut = true;
		gameObject.SetActive (true);
	}

	void Update() {
		if (isFadingOut || isFadingIn) {
			float newAlpha = fadeColor.a + (isFadingOut ? 1 : -1) * Time.deltaTime / (isFadingOut ? fadeOutSeconds : fadeInSeconds);
			if (newAlpha >= 255) {
				newAlpha = 255;
				isFadingOut = false;
			}
			if (newAlpha <= 0) {
				newAlpha = 0;
				isFadingIn = false;
			}
			fadeColor.a = newAlpha;
			panelImage.color = fadeColor;
		} else {
			gameObject.SetActive (false);
		}
	}
}
