using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private Animator _animator;

    private const string IsRunning = "isRunning";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(IsRunning, false);

        if (Input.GetKey(KeyCode.D))
        {
            Move(1, false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Move(-1, true);
        }
    }

    private void Move(int direction, bool flip)
    {
        transform.Translate(_speed * Time.deltaTime * direction, 0, 0);
        _spriteRenderer.flipX = flip;
        _animator.SetBool(IsRunning, true);
    }
}