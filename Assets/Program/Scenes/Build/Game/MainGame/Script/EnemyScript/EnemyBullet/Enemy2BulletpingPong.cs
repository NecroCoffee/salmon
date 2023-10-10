using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2BulletpingPong : EnemyBulletSuperClass
{

    [SerializeField]private float speed=5f;
    [SerializeField] private float length = 2f;

    private void FixedUpdate()
    {
        ShootPingPong(Vector2.left, speed, length);
    }
}
    
