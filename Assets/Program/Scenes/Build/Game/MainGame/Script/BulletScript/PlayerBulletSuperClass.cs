using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSuperClass : MonoBehaviour
{
    protected float bulletAngle;//角度
    protected float bulletSpeed;//速度
    protected Vector3 bulletVerocity;//移動量

    protected GameObject enemyObject;//敵オブジェクト
    protected Vector3 enemyPosition;//敵Position

    MainGameManager MGMscript = new MainGameManager();

    protected GameObject SearchEnemyObject()//敵オブジェクト検索メソッド
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
