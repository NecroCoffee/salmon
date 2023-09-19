using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    /// <summary>
    /// プレイヤーオブジェクト検索メソッド
    /// </summary>
    /// <returns>GameObject</returns>
    protected GameObject SearchPlayerObject()//プレイヤーオブジェクト検索メソッド
    {
        GameObject salmon = GameObject.FindWithTag("Salmon");
        return salmon;
    }

    /// <summary>
    /// 敵弾と自機の角度を取得(Deg)
    /// </summary>
    /// <returns>float(Deg)</returns>
    protected float GetAimForSalmon()
    {
        GameObject gameObject = SearchPlayerObject();
        Vector3 vector3 = new Vector3();
        vector3 = gameObject.gameObject.transform.position;

        float dx = vector3.x - transform.position.x;
        float dy = vector3.y - transform.position.y;
        return Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
    }

    //----------------------------------------------

    //移動用メソッド

    /// <summary>
    /// 上下移動
    /// </summary>
    /// <param name="body"></param>
    /// <param name="currentPos"></param>
    /// <param name="moveRange"></param>
    protected void EnemyMove01(GameObject body,Vector3 currentPos,float moveRange)
    {
        body.gameObject.transform.position =new Vector3(currentPos.x, currentPos.y + Mathf.Sin(Time.time) * moveRange, currentPos.z);
    }

    //攻撃用メソッド
    protected void EnemyAttack()
    {

    }


}
