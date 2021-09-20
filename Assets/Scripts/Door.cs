using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Player _player;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _player.EnteredTheBank += OnOpened;
        _player.LeftTheBank += OnClosed;
    }

    private void OnDisable()
    {
        _player.EnteredTheBank -= OnOpened;
        _player.LeftTheBank -= OnClosed;
    }

    private void OnOpened()
    {
        _spriteRenderer.color = Color.white;
    }

    private void OnClosed()
    {
        _spriteRenderer.color = Color.clear;
    }
}