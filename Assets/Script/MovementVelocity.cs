using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVelocity : MonoBehaviour, IMove
{
    [SerializeField] private float moveSpeed;
    private Vector3 moveDirection;
    private Rigidbody2D playerRigidbody2D;
    private void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void SetMove(Vector3 moveDirection)
    {
        this.moveDirection = moveDirection;
    }
    private void Move()
    {
        playerRigidbody2D.velocity = moveSpeed * moveDirection;
    }
}
