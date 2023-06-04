using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] private Transform _player;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += new Vector3(0, 0, _speed * Time.deltaTime);

        if (transform.position.z >= _player.position.z)
        {
            GameManager.Instance.GameOver();
        }
    }
}
