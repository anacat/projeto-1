using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomLoop : MonoBehaviour
{
    public List<AudioClip> audioClips = new List<AudioClip>();

    private AudioSource _audioSource;
    private bool _audioEnded = false;
    private int _audioIndex;

    private void Start()
    {
        StartCoroutine(PlayRandomAudio());
    }

    private IEnumerator PlayRandomAudio()
    {
        _audioIndex = Random.Range(0, audioClips.Count);
        AudioClip currentClip = audioClips[_audioIndex];

        _audioSource.clip = currentClip;
        _audioSource.Play();

        float timer = 0f;
        
        while (timer < currentClip.length)
        {
            if (!AudioListener.pause)
            {
                timer += Time.deltaTime;
            }

            yield return null;
        }

        StartCoroutine(PlayRandomAudio());
    }
}