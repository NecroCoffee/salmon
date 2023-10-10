using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : EnemyData
{
    //�G�X�e�[�^�X���

    [SerializeField] public int enemy2HP = 500;

    //------------------------------------------



    [SerializeField] private GameObject salmon;

    private Vector3 salmonPosition;


    [SerializeField] private GameObject enemy2Body;//enemy2�̖{�̃I�u�W�F�N�g

    [SerializeField] List<GameObject> enemy2Bullet = new List<GameObject>();//�G�e�̃v���n�u

    [SerializeField] private GameObject enemy2Shooter;//�G�e���ˉӏ�

    [SerializeField] private float bulletSpeed = 5f;

    private Vector3 currentPos;

    //------------------------

    //�t���[���J�E���^�[

    [SerializeField] private float currentFrame = 0f;
    [SerializeField] private float intervalFrame = 10f;

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
        salmon = SearchPlayerObject();
        currentPos = enemy2Body.gameObject.transform.position;
    }
    


    private void FixedUpdate()
    {

        EnemyMove01(enemy2Body, currentPos, moveRange);



        if (currentFrame > intervalFrame)
        {
            currentFrame = 0f;
            EnemyAttackAim(enemy2Bullet[0], enemy2Shooter, salmon, bulletSpeed);

            EnemyAttackStraight(enemy2Bullet[1], Vector2.left, enemy2Shooter);
            //EnemyAttackNWay(enemy2Bullet[0], enemy2Shooter, 45, 5, 15, bulletSpeed);

            //EnemyAttack2SidePingPong(enemy2Bullet[2], Vector3.left, enemy2Shooter, 3f);

            
        }
        else
        {
            currentFrame++;

            
        }
    }
}
