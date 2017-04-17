using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
    
    public AudioClip[] musicArray;

    private AudioSource audioSource;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		int level = scene.buildIndex;
		AudioClip clip = musicArray[level];
		if (clip) {
			audioSource.clip = clip;
			audioSource.Play();
		}
		if (level == 0) {
			audioSource.loop = false;
		} else {
			audioSource.loop = true;
		}
    }
}
