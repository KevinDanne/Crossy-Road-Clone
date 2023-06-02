using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]  private TextMeshProUGUI _scoreText;

    private PlayerMovement _playerMovement;
    private Transform _transform;
    
    private float _score = 0f;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        _score = Math.Max(_score, transform.position.z);
        _scoreText.text = "Score: " + Math.Floor(_score / _playerMovement.JumpDistance());
    }
}
