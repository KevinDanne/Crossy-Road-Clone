using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]  private TextMeshProUGUI scoreText;

    private PlayerMovement playerMovement;
    
    private Transform transform;
    private float score = 0f;

    private void Awake()
    {
        transform = GetComponent<Transform>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        score = Math.Max(score, transform.position.z);
        scoreText.text = "Score: " + Math.Floor(score / playerMovement.JumpDistance());
    }
}
