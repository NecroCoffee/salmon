using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float gameSpeed = 1f;
    [SerializeField] public int score = 0;

    [SerializeField] public bool isGameOver;

    private void Start()
    {
        Application.targetFrameRate = 60;
        isGameOver = false;
    }
}
