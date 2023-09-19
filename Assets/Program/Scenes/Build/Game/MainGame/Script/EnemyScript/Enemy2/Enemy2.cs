using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyData
{
    [SerializeField] private GameObject salmon;

    private Vector3 salmonPosition;


    [SerializeField] private GameObject enemy2Body;//enemy2�̖{�̃I�u�W�F�N�g

    [SerializeField] List<GameObject> enemy2Bullet = new List<GameObject>();//�G�e�̃v���n�u

    [SerializeField] private GameObject enemy2Shooter;//�G�e���ˉӏ�

    private Vector3 currentPos;

    //------------------------

    //enemy2�ړ����\�b�h

    [SerializeField] private float moveRange = 3;

    //private void Enemy2Move_1()
    //{
    //    enemy2Body.gameObject.transform.position = new Vector3(currentPos.x, currentPos.y + Mathf.Sin(Time.time) * moveRange, currentPos.z);
    //}

    //enemy2�U�����\�b�h
    

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
