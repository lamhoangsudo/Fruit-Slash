using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public static event EventHandler<bool> OnAnyBlock;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnAnyBlock?.Invoke(this, true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnAnyBlock?.Invoke(this, false);
    }
}
