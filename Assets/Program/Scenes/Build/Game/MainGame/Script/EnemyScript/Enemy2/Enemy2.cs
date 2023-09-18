using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private GameObject enemy2Body;//enemy2の本体オブジェクト

    [SerializeField] private GameObject enemy2Bullet;//敵弾のプレハブ

    [SerializeField] private GameObject enemy2Shooter;//敵弾発射箇所

    private Vector3 currentPos;

    //------------------------

    //enemy2移動メソッド

    [SerializeField] private float moveRange = 3;

    private void Enemy2Move_1()
    {
        enemy2Body.gameObject.transform.position = new Vector3(currentPos.x, currentPos.y + Mathf.Sin(Time.deltaTime) * moveRange, currentPos.z);
    }

    //enemy2攻撃メソッド
    private void Enemy2Attack_1()
    {

    }

    private void Awake()
    {
        currentPos = enemy2Body.gameObject.transform.position;
    }


    private void Update()
    {
        Enemy2Move_1();
    }
}
