using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2BulletStraight : EnemyBulletSuperClass
{
    [SerializeField]
    private float speed = 0.5f;

    [SerializeField]
    private Vector2 direction = Vector2.left;

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    private void FixedUpdate()
    {
        ShootStraight(direction, speed);
    }
}
