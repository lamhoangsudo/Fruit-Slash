using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public static event EventHandler OnAnyLevelClear;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6 && GameLevelManager.instance.playerHasEnoughPoints)
        {
            OnAnyLevelClear?.Invoke(this, EventArgs.Empty);
        }
    }
}
