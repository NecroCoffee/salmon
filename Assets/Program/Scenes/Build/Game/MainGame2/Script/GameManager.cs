using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public float gameSpeed = 1f;
    [SerializeField] public int timeScore = 0;
    [SerializeField] public int bonusScore = 0;

    [SerializeField] public bool isGameOver;

    [SerializeField] public float startTime;
    [SerializeField] public float timer;

    [SerializeField] public float gameStageTimer = 0f;
    [SerializeField] private float gameStageChangeTime = 30f;

    [SerializeField] private MissileGenerator missileGenerator;

    private void TimeCounter()
    {

        timer = Time.time - startTime;
        timeScore = (int)Math.Truncate(timer * 1000);

    }

    private void GameStageTimeCounter()
    {
        gameStageTimer += Time.deltaTime;
        if (gameStageTimer >= gameStageChangeTime)
        {
            addMisileDiff();
            gameSpeed += 2.5f;
            gameStageTimer = 0f;
        }
    }

    private void addMisileDiff()
    {
        missileGenerator.repeatTime -= 0.5f;
        if (missileGenerator.repeatTime <= 1.5f)
        {
            missileGenerator.repeatTime = 1.5f;
        }
    }

    private void slowGameSpeed()
    {
        if (gameSpeed >= 0f)
        {
            gameSpeed -= 0.1f;
        }
        
        if (gameSpeed < 0f)
        {
            gameSpeed = 0f;
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

        if (isGameOver == true)
        {
            slowGameSpeed();
        }
    }
}
