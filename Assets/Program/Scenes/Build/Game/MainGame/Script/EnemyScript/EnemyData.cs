using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    protected struct EnemyStatus
    {

    }

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

    /// <summary>
    /// 自機狙い
    /// </summary>
    /// <param name="bullet"></param>
    protected void EnemyAttackAim(GameObject bullet,GameObject enemyShooter,GameObject target,float bulletSpeed)
    {
        Vector3 enemyShooterPos = enemyShooter.gameObject.transform.position;
        GameObject bulletObject = Instantiate(bullet) as GameObject;
        bulletObject.transform.position = enemyShooterPos;
        Vector3 shootVector = (target.transform.position - enemyShooterPos).normalized;
        bulletObject.GetComponent<Rigidbody2D>().velocity = shootVector * bulletSpeed;
    }

    /// <summary>
    /// 改修予定 Nway弾
    /// </summary>
    /// <param name="bullet"></param>
    /// <param name="enemyShooter"></param>
    /// <param name="direction"></param>
    /// <param name="wayNumber"></param>
    /// <param name="width"></param>
    /// <param name="bulletSpeed"></param>
    protected void EnemyAttackNWay(GameObject bullet,GameObject enemyShooter,float direction,int wayNumber,float width,float bulletSpeed)
    {
        
    }


    protected void EnemyAttackStraight(GameObject bullet,Vector3 direction,GameObject bulletShooter)
    {
        GameObject bulletObject = Instantiate(bullet) as GameObject;
        bulletObject.transform.position = bulletShooter.transform.position;
        bulletObject.transform.Rotate(direction);
        
    }

    protected void EnemyAttack2SidePingPong(GameObject bullet,Vector3 direction,GameObject bulletShooter,float diff)
    {
        GameObject bulletObject1 = Instantiate(bullet) as GameObject;
        GameObject bulletObject2 = Instantiate(bullet) as GameObject;

        bulletObject1.transform.position = new Vector3(bulletShooter.transform.position.x, bulletShooter.transform.position.y + diff, 0);
        bulletObject2.transform.position = new Vector3(bulletShooter.transform.position.x, bulletShooter.transform.position.y - diff, 0);

        bulletObject1.transform.Rotate(direction);
        bulletObject2.transform.Rotate(direction);
    }

}
