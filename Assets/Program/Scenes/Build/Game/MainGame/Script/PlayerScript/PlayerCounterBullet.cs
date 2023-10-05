using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterBullet : PlayerBulletSuperClass
{
    [SerializeField] private Vector3 bulletPos;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float bulletSpeedIncrease = 0.5f;
    [SerializeField] private float bulletDirection;
    [SerializeField] private GameObject targetObject;
    [SerializeField] private Vector3 targetPos;

    [SerializeField] private int bulletHP = 3;

    private void Awake()
    {
        bulletPos = this.gameObject.transform.position;
        targetObject = SearchEnemyObject();
        targetPos = targetObject.transform.position;
        bulletDirection = GetAimForEnemy(targetObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        if (collisionObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
            bulletHP--;
        }

        if (collisionObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            return;
        }

        if (bulletHP <= 0)
        {
            Destroy(this.gameObject);
        }

        return;

    }

    private void FixedUpdate()
    {
        bulletPos = this.transform.position;
        targetPos = targetObject.transform.position;
        bulletSpeed += bulletSpeedIncrease;
        this.transform.position = Vector3.MoveTowards(bulletPos, targetPos, bulletSpeed * Time.fixedDeltaTime);
    }
}
