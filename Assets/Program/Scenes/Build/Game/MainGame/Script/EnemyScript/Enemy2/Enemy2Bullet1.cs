using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Bullet1 : EnemyBulletSuperClass
{
    private Vector3 bulletPos = new Vector3();

    private float direction;
    

    private void Awake()
    {
        direction = GetAimForSalmon();

        bulletPos = this.gameObject.transform.position;
    }

    private void OnBecameInvisible()
    {
        DeleteBullet();
    }

    private void FixedUpdate()
    {
        bulletPos = this.gameObject.transform.position;
        //this.gameObject.transform.position +=
    }

}
