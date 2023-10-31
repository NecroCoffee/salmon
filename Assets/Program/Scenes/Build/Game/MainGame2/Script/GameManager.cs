using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameSpeed = 1f;
    public int timeScore = 0;
    public int bonusScore = 0;

    public bool isGameOver;

    public float startTime;
    public float timer;

    public float gameStageTimer = 0f;
    [SerializeField] private float gameStageChangeTime = 30f;

    [SerializeField] private MissileGenerator missileGenerator;

    [SerializeField] public int missileDestroyBonus = 2000;

    private void TimeCounter()
    {

        timer = Time.timeSinceLevelLoad - startTime;
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
        
        timeScore = 0;
        bonusScore = 0;
        gameStageTimer = 0f;
        gameStageChangeTime = 30f;
        startTime = 0f;
        startTime = Time.deltaTime;
        
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        isGameOver = false;
        timeScore = 0;
        bonusScore = 0;
        gameStageTimer = 0f;
        gameStageChangeTime = 30f;
        startTime = 0f;
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
