using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BuildingStatus
{
    public int score;
    public int hp;
    public float speed;

    public BuildingStatus(int score, int hp, float speed)
    {
        this.score = score;
        this.hp = hp;
        this.speed = speed;
    }
}

public class BuildingData : MonoBehaviour
{
    
}
