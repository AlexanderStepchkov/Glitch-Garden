using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;

	private MusicManager musicManager;
	private LevelManager levelManager;

	public void SetDefault () {
		volumeSlider.value = 20f;
		difficultySlider.value = 1f;
	}

	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		volumeSlider.value = PlayerPrefManager.GetMasterVolume () * 100;
		difficultySlider.value = PlayerPrefManager.GetDifficulty ();
	}

	void Update () {
		musicManager.ChangeVolume (volumeSlider.value / 100f);
	}

	public void SaveAndExit (){
		PlayerPrefManager.SetMasterVolume (volumeSlider.value / 100f);
		PlayerPrefManager.SetDifficulty ((int)difficultySlider.value);
		levelManager.LoadLevel ("01a Start");
	}
}
