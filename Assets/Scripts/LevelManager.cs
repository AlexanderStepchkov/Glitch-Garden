using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float autoloadNextLevelAfterSeconds = 0.0f;

    void Awake() {
		DontDestroyOnLoad (gameObject);
    }

	void Start() {
		if (autoloadNextLevelAfterSeconds > 0) {
			Invoke ("LoadNextLevel", autoloadNextLevelAfterSeconds);
			autoloadNextLevelAfterSeconds = 0.0f;
			PlayerPrefManager.SetDefaults ();
		}
	}

    public void LoadLevel(string sceneName) {
		SceneManager.LoadSceneAsync (sceneName);
    }

	public void LoadLevel(int sceneNum) {
		SceneManager.LoadSceneAsync (sceneNum);
	}

    public void LoadNextLevel() {
		int currentBuildIndex = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadSceneAsync (currentBuildIndex + 1);
    }

    public void Quit() {
		Debug.Log ("App is closing");
		Application.Quit ();
    }
}
