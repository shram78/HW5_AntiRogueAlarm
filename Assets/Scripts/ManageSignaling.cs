using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSignaling : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Animator _animator;

    public void OpenDoor()
    {
        _renderer.color = Color.white;
    }

    public void CloseDoor()
    {
        _renderer.color = Color.clear;
    }

    public void LightSignalingOn()
    {
        _animator.Play("SignalingAlarm");
    }

    public void LightSignalingOff()
    {
        _animator.Play("SignalingOff");
    }
}