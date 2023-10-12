using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameData : MonoBehaviour
{
    public struct PlayerData
    {
        public static int HP;
    }

    public struct CurrentEnemyData
    {
        public static string EnemyName;
        public static int MaxHP;
        public static int currentHP;
    }

    public struct UIData
    {
        public static int score;
    }

    [SerializeField] int EnemyHP = CurrentEnemyData.currentHP;


}
