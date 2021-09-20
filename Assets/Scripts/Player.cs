using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction EnteredTheBank;
    public event UnityAction LeftTheBank;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Door>(out Door door))
            EnteredTheBank?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Door>(out Door door))
            LeftTheBank?.Invoke();
    }
}
