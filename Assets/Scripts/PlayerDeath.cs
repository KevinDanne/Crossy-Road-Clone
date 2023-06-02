using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
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
            Debug.Log("camera.z >= player.position.z");
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Vehicle"))
        {
            Debug.Log("Player hit vehicle.");
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!!!");
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
