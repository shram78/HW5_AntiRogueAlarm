using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalitionVolume : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySignalition()
    {
        _audioSource.PlayOneShot(_audioClip);
        StartCoroutine(VolumeUp());
    }

    public void StopSignalition()
    {
        StartCoroutine(VolumeDown());
    }

    private IEnumerator VolumeUp()
    {
        for (int i = 1; i < 2000; i++)
        {
            Debug.Log("vol UP = " + _audioSource.volume);
            _audioSource.volume = (1f / 1000f * i);
           
            yield return null;
        }
    }

    private IEnumerator VolumeDown()
    {
        for (int i = 1; i < 2000; i++)
        {
            Debug.Log("vol DOWN = " + _audioSource.volume);
            _audioSource.volume = 1- (1f / 1000f * i);

            yield return null;
        }
    }
}