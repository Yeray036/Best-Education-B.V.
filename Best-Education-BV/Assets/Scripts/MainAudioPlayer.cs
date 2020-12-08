using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioPlayer : MonoBehaviour
{
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
