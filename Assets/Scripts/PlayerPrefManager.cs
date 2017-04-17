using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefManager : MonoBehaviour {

	public enum Keys {
		MASTER_VOLUME,
		DIFFICULTY
	}

	public static void SetDefaults () {
		if (!PlayerPrefs.HasKey(Keys.MASTER_VOLUME.ToString())) {
			SetMasterVolume (0.2f);
		}
		if (!PlayerPrefs.HasKey(Keys.DIFFICULTY.ToString())) {
			SetDifficulty (1);
		}
	}

	public static void SetMasterVolume (float volume) {
		if (volume >= 0 && volume <= 1) {
			PlayerPrefs.SetFloat (Keys.MASTER_VOLUME.ToString (), volume);
		} else {
			Debug.LogError ("Master volume is out of range. Expected 0 to 1. Given: " + volume);
		}
	}

	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat (Keys.MASTER_VOLUME.ToString ());
	}

	public static void SetDifficulty (int difficulty) {
		if (difficulty >= 0 && difficulty <= 5) {
			PlayerPrefs.SetInt (Keys.DIFFICULTY.ToString (), difficulty);
		} else {
			Debug.LogError ("Difficulty is out of range. Expected 0 to 5. Given: " + difficulty);
		}
	}

	public static int GetDifficulty () {
		return PlayerPrefs.GetInt (Keys.DIFFICULTY.ToString ());
	}
}
