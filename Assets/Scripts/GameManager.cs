using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Start()
    {
        Instance = this;
    }

    public void GameOver()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
