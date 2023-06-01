using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(0, 0, speed * Time.deltaTime);
    }
}
