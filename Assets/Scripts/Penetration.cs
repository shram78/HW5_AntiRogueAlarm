using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Penetration : MonoBehaviour
{
    [SerializeField] private UnityEvent _enteredTheBank;
    [SerializeField] private UnityEvent _exitTheBank;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _enteredTheBank?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _exitTheBank?.Invoke();
    }
}