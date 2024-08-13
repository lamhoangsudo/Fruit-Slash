using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Camera camera; // Reference to the Camera component

    private void Start()
    {
        if (camera == null)
        {
            camera = Camera.main; // Default to the main camera if none is assigned
        }

        InvokeRepeating(nameof(hangeColor), 0f, 10);
    }

    private void hangeColor()
    {
        if (camera != null)
        {
            camera.backgroundColor = new Color(Random.value, Random.value, Random.value);
        }
    }
}
