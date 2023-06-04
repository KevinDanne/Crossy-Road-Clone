using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private void Update()
    {
        transform.Translate(new Vector3(_speed * Time.deltaTime, 0, 0));
    }
}
