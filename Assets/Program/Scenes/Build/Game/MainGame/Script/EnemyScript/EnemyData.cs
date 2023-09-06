using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    
    enum EnemyShotType
    {
        NONE,
        AIM,
    }

    [System.Serializable]
    struct Enemy
    {
        public string EnemyName;
    }
}
