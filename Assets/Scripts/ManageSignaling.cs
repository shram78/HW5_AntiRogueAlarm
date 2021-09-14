using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSignaling : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Animator _animator;

    private AudioSource _audioSource;
    private const string _doorOpen = "isDoorOpen";

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void OpenDoor()
    {
        _renderer.color = Color.white;
        _audioSource.volume = 0f;
    }

    public void CloseDoor()
    {
        _renderer.color = Color.clear;
    }

    public void LightSignalingOn()
    {
        _animator.SetBool(_doorOpen, true);
    }

    public void LightSignalingOff()
    {
        _animator.SetBool(_doorOpen, false);
    }

    public void SoundSignalingOn()
    {
        _audioSource.Play();
        StartCoroutine(VolumeChange(1));
    }

    public void SoundSignalingOff()
    {
        StartCoroutine(VolumeChange(-1));
    }

    private IEnumerator VolumeChange(int volumeUpDown)
    {
        for (int i = 0; i < 1000; i++)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1f, 0.5f * Time.deltaTime * volumeUpDown);
            Debug.Log(_audioSource.volume);

            yield return null;
        }
    }
}