using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Bullet : EnemyBulletSuperClass
{
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
