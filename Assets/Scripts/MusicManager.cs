using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
    
    public AudioClip[] musicArray;

    [SerializeField]
    private LevelManager loadManager;
    private AudioSource audioSource;

    void Awake () {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
	}

    void Start() {
        
    }

    void LoadNextLevel() {
        loadManager.LoadNextLevel();
    }

    private void OnLevelWasLoaded(int level) {
        audioSource.clip = musicArray[level];
        audioSource.Play();
        if (level == 0)
            Invoke("LoadNextLevel", audioSource.clip.length);
    }
}
