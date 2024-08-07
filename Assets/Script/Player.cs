using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform visual;
    private Joystick joystick;
    private IMove movemnet;
    private const string Player_JoyStick_Movememnt = "Player_JoyStick_Movememnt";
    private void Start()
    {
        movemnet = GetComponent<IMove>();
        joystick = GameObject.FindGameObjectWithTag(Player_JoyStick_Movememnt).GetComponent<Joystick>();
    }

    private void Update()
    {
        if(joystick.Direction.x != 0 || joystick.Direction.y != 0)
        {
            if (joystick.Direction.x < 0)
            {
                visual.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            else if (joystick.Direction.x > 0)
            {
                visual.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
            }
            movemnet.SetMove(joystick.Direction);
            animator.Play("Run");
        }
        else
        {
            movemnet.SetMove(Vector3.zero);
            animator.Play("Idel");
        }
    }
}
