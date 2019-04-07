using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
    public AudioClip[] bgMusic;
    AudioSource audioSource;
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
            
		}
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgMusic[Random.Range(0, bgMusic.Length - 1)];
        audioSource.Play();
    }

    private void OnLevelWasLoaded(int level)
    {
        audioSource.clip = bgMusic[Random.Range(0, bgMusic.Length - 1)];
        audioSource.Play();
    }
}
