using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSuperClass : MonoBehaviour
{
    protected float bulletAngle;//�p�x
    protected float bulletSpeed;//���x
    protected Vector3 bulletVerocity;//�ړ���

    protected GameObject enemyObject;//�G�I�u�W�F�N�g
    protected Vector3 enemyPosition;//�GPosition

    MainGameManager MGMscript = new MainGameManager();

    protected GameObject SearchEnemyObject()//�G�I�u�W�F�N�g�������\�b�h
    {
        GameObject enemy = MGMscript.MGMcurrentEnemy;
        return enemy;
    }

    protected float GetAimForEnemy()
    {
        GameObject gameObject = SearchEnemyObject();
        Vector3 vector3 = new Vector3();
        vector3 = gameObject.gameObject.transform.position;

        float dx = vector3.x - transform.position.x;
        float dy = vector3.y - transform.position.y;
        return Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
    }
}
