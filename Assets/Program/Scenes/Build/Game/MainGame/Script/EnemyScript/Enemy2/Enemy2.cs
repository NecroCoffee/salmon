using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyData
{
    [SerializeField] private GameObject salmon;

    private Vector3 salmonPosition;


    [SerializeField] private GameObject enemy2Body;//enemy2の本体オブジェクト

    [SerializeField] List<GameObject> enemy2Bullet = new List<GameObject>();//敵弾のプレハブ

    [SerializeField] private GameObject enemy2Shooter;//敵弾発射箇所

    private Vector3 currentPos;

    //------------------------

    //enemy2移動メソッド

    [SerializeField] private float moveRange = 3;

    //private void Enemy2Move_1()
    //{
    //    enemy2Body.gameObject.transform.position = new Vector3(currentPos.x, currentPos.y + Mathf.Sin(Time.time) * moveRange, currentPos.z);
    //}

    //enemy2攻撃メソッド
    

    private void Awake()
    {
        currentPos = enemy2Body.gameObject.transform.position;
    }


    private void Update()
    {
        //Enemy2Move_1();
        EnemyMove01(enemy2Body,currentPos,moveRange);
    }
}
