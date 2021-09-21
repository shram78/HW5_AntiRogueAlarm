using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class Siren : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Animator _animator;
    private AudioSource _audioSource;

    private const string DoorOpen = "isDoorOpen";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        _player.EnteredTheBank += LightOn;
        _player.EnteredTheBank += SoundOn;

        _player.LeftTheBank += LoghtOff;
        _player.LeftTheBank += SoundOff;
    }

    private void OnDisable()
    {
        _player.EnteredTheBank -= LightOn;
        _player.EnteredTheBank -= SoundOn;

        _player.LeftTheBank -= LoghtOff;
        _player.LeftTheBank -= SoundOff;
    }

    private void LightOn()
    {
        _animator.SetBool(DoorOpen, true);
    }

    private void LoghtOff()
    {
        _animator.SetBool(DoorOpen, false);
    }

    private void SoundOn()
    {
        _audioSource.volume = 0f;
        _audioSource.Play();
        StartCoroutine(VolumeChange(1, 1));
    }

    private void SoundOff()
    {
        StartCoroutine(VolumeChange(-1, 0));
    }

    private IEnumerator VolumeChange(int volumeUpDownValue, int targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1f, 0.5f * Time.deltaTime * volumeUpDownValue);
            Debug.Log(_audioSource.volume);
            yield return null;
        }

        if (_audioSource.volume == 0)
            _audioSource.Stop();
    }
}