using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Animator _animator;
    private AudioSource _audioSource;

    private const string _doorOpen = "isDoorOpen";

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
        _animator.SetBool(_doorOpen, true);
    }

    private void LoghtOff()
    {
        _animator.SetBool(_doorOpen, false);
    }

    private void SoundOn()
    {
        _audioSource.volume = 0f;
        _audioSource.Play();
        StartCoroutine(VolumeChange(1));
    }

    private void SoundOff()
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