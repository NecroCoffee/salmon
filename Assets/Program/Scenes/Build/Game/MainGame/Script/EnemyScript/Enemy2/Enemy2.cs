using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private GameObject enemy2Body;//enemy2�̖{�̃I�u�W�F�N�g

    [SerializeField] private GameObject enemy2Bullet;//�G�e�̃v���n�u

    [SerializeField] private GameObject enemy2Shooter;//�G�e���ˉӏ�

    private Vector3 currentPos;

    //------------------------

    //enemy2�ړ����\�b�h

    [SerializeField] private float moveRange = 3;

    private void Enemy2Move_1()
    {
        enemy2Body.gameObject.transform.position = new Vector3(currentPos.x, currentPos.y + Mathf.Sin(Time.deltaTime) * moveRange, currentPos.z);
    }

    //enemy2�U�����\�b�h
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
