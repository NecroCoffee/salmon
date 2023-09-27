using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2BulletStraight : EnemyBulletSuperClass
{
    [SerializeField]
    private float speed = 0.5f;

    private void FixedUpdate()
    {
        ShootStraight(speed);
    }
}
