using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float gameSpeed = 1f;
    [SerializeField] public int score = 0;

    [SerializeField] public bool isGameOver;

    [SerializeField] public float startTime;
    [SerializeField] public float timer;

    [SerializeField] public float gameStageTimer = 0f;
    [SerializeField] private float gameStageChangeTime = 15f;

    private void TimeCounter()
    {
        timer = Time.time - startTime;
    }

    private void GameStageTimeCounter()
    {
        gameStageTimer += Time.deltaTime;
        if (gameStageTimer >= gameStageChangeTime)
        {
            gameSpeed += 2.5f;
            gameStageTimer = 0f;
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        isGameOver = false;
        startTime = Time.deltaTime;
    }

    private void Update()
    {
        if (isGameOver == false)
        {
            TimeCounter();
            GameStageTimeCounter();
        }
    }
}
