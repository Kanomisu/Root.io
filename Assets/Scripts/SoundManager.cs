using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSound;
    [SerializeField] private AudioClip clipSound;

    void Awake()
    {
        audioSound = GetComponent<AudioSource>();
        audioSound.clip = clipSound;
        audioSound.volume = 0.2f;
        audioSound.playOnAwake = true;
        audioSound.loop = true;
        audioSound.Play();
    }

    void AudioPlay()
    {
        audioSound.clip = clipSound;
        audioSound.Play();
        Debug.Log("Play sound");
    }

    void AudioStop()
    {
        audioSound.Stop();
        audioSound.loop = false;
        Debug.Log("Stop sound");
    }

    private void Update()
    {
        if (CameraScript.instance.endGame == true)
        {
            AudioStop();
        }
    }
}
