using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioPlayer : MonoBehaviour
{
	//this script is instatiated with DontDestroyOnLoad wich means the object that is attached to this script will not be destroyed.
	//this is the main music object script 
    public AudioSource _audioSource { get; set; }
	

    private void Awake()
    {
        _audioSource = transform.gameObject.GetComponent<AudioSource>();
        if (GameObject.FindGameObjectsWithTag(this.gameObject.tag).Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
