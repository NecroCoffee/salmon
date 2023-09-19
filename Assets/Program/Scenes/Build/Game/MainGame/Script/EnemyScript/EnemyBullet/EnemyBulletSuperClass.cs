using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSuperClass : MonoBehaviour
{


    protected float angle;//角度
    protected float speed;//速度
    protected Vector3 verocity;//移動量

    protected GameObject salmon;//プレイヤーオブジェクト
    protected Vector3 salmonPosition;//プレイヤーPosition

    

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

    protected void ShootAimSalmon()//自機狙い弾
    {        
        
    }

    

}
