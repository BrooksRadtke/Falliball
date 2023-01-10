using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] musicPlayList;
    AudioClip lastClip;

    public static PlayAudio instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.clip = musicPlayList[Random.Range(0, musicPlayList.Length)];
        audioSource.PlayOneShot(audioSource.clip);

        //audioSource.PlayOneShot(RandomClip());
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = musicPlayList[Random.Range(0, musicPlayList.Length)];
            audioSource.Play();
        }
    }

    //AudioClip RandomClip()
    //{
    //    int attempts = 3;
    //    AudioClip newClip = musicPlayList[Random.Range(0, musicPlayList.Length)];

    //    while (newClip == lastClip && attempts > 0)
    //    {
    //        newClip = musicPlayList[Random.Range(0, musicPlayList.Length)];
    //        attempts--;
    //    }

    //    lastClip = newClip;
    //    return newClip;
    //}
}