using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCup : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        transform.Rotate(0, speed, 0, Space.World);
    }
}
