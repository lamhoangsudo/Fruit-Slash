using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static event EventHandler OnAnyEnemyKill;
    [SerializeField] private Transform killVfx;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer.sprite = sprites[UnityEngine.Random.Range(0, sprites.Count -1)]; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Instantiate(killVfx, transform.position, Quaternion.identity);
            OnAnyEnemyKill?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
