using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip startMucic;
    [SerializeField]
    private LevelManager loadManager;

	void Awake () {
        GameObject.DontDestroyOnLoad(gameObject);
        audioSource = gameObject.GetComponent<AudioSource>();
	}

    void Start() {
        audioSource.clip = startMucic;
        audioSource.Play();
        Invoke("LoadNextLevel", startMucic.length);
    }

    void LoadNextLevel() {
        loadManager.LoadLevel("01 Start");
    }
}
