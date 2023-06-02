using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private void Update()
    {
        HandleCameraOvertake();
    }

    private void HandleCameraOvertake()
    {
        if (_camera.position.z >= transform.position.z)
        {
            Debug.Log("Game OVER! camera.z >= player.position.z");
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
