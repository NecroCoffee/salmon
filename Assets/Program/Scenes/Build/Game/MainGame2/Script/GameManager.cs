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
    
    private void TimeCounter()
    {
        timer = Time.time - startTime;
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        isGameOver = false;
        startTime = Time.time;
    }

    private void Update()
    {
        if (isGameOver == false)
        {
            TimeCounter();
        }
    }
}
