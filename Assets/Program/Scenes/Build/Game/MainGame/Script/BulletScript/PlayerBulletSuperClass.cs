using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletSuperClass : MonoBehaviour
{
    
    protected Vector3 bulletVerocity;//移動量

    protected GameObject enemyObject;//敵オブジェクト
    protected Vector3 enemyPosition;//敵Position

    //MainGameManager MGMscript = new MainGameManager();

    protected GameObject SearchEnemyObject()//敵オブジェクト検索メソッド
    {
        GameObject enemy = GameObject.FindWithTag("Enemy");
        return enemy;
    }

    protected float GetAimForEnemy(GameObject targetObject)
    {
        GameObject gameObject = targetObject;
        Vector3 vector3 = new Vector3();
        vector3 = gameObject.gameObject.transform.position;

        float dx = vector3.x - transform.position.x;
        float dy = vector3.y - transform.position.y;
        return Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
    }
}
