using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
	
	void Awake () {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't Destroy on Load: " + name);
	}

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		Debug.Log ("Playing Clip: " + levelMusicChangeArray);

		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();
			audioSource.volume = PlayerPrefsManager.GetMasterVolume ();
		}
	}

	public void SetVolume (float volume) {
		audioSource.volume = volume;
	}
}
