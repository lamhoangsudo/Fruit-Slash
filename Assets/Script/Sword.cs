using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Joystick joystick;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float timeToBreakMax;
    private const string Sword_JoyStick_Rotation = "Sword_JoyStick_Rotation";
    private bool isBlock;
    private bool isKill;
    public static event EventHandler OnAnySwordBreak;
    private float timeToBreak;
    [SerializeField] private Transform SwordVisual;
    private float scaleY;
    [SerializeField] private AudioClip audioKill;
    private TextMeshProUGUI timeBreak;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        joystick = GameObject.FindGameObjectWithTag(Sword_JoyStick_Rotation).GetComponent<Joystick>();
        scaleY = transform.localScale.y;
        timeBreak = GameObject.Find("TimeBreak").GetComponent<TextMeshProUGUI>();
        Enemy.OnAnyEnemyKill += Enemy_OnAnyEnemyKill;
        Barrier.OnAnyBlock += Barrier_OnAnyBlock;
    }

    private void Barrier_OnAnyBlock(object sender, bool e)
    {
        isBlock = e;
        timeToBreak = timeToBreakMax;
    }

    private void Enemy_OnAnyEnemyKill(object sender, System.EventArgs e)
    {
        audioSource.PlayOneShot(audioKill);
        scaleY = scaleY + 0.5f;
        isKill = true;
    }

    private void Update()
    {
        SwordRotation();
        if(isBlock)
        {
            timeToBreak -= Time.deltaTime;
            int timeText = (int)timeToBreak;
            timeBreak.text = "Break in: " + timeText.ToString();
            if (timeToBreak <= 0)
            {
                OnAnySwordBreak?.Invoke(this, EventArgs.Empty);
            }
        }
        else
        {
            timeBreak.text = string.Empty;
        }
        if (isKill) 
        { 
            SwordScale();
        }
    }
    private void SwordRotation()
    {
        if (joystick.Direction != Vector2.zero)
        {
            Vector2 offset = joystick.Direction;
            float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle - 90), Time.deltaTime * rotationSpeed);
        }
    }
    private void SwordScale()
    {
        SwordVisual.localScale = Vector3.Lerp(SwordVisual.localScale, new Vector3(SwordVisual.localScale.x, SwordVisual.localScale.y + 0.5f, SwordVisual.localScale.z), Time.deltaTime * 2f);
        if(SwordVisual.localScale.y >= scaleY)
        {
            isKill = false;
        }
    }
    private void OnDestroy()
    {
        Enemy.OnAnyEnemyKill -= Enemy_OnAnyEnemyKill;
        Barrier.OnAnyBlock -= Barrier_OnAnyBlock;
    }
}
