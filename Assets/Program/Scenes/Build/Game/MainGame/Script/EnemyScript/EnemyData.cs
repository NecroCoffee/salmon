using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    protected struct SalmonData
    {

    }

    /// <summary>
    /// �v���C���[�I�u�W�F�N�g�������\�b�h
    /// </summary>
    /// <returns>GameObject</returns>
    protected GameObject SearchPlayerObject()//�v���C���[�I�u�W�F�N�g�������\�b�h
    {
        GameObject salmon = GameObject.FindWithTag("Salmon");
        return salmon;
    }

    /// <summary>
    /// �G�e�Ǝ��@�̊p�x���擾(Deg)
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

    //�ړ��p���\�b�h

    /// <summary>
    /// �㉺�ړ�
    /// </summary>
    /// <param name="body"></param>
    /// <param name="currentPos"></param>
    /// <param name="moveRange"></param>
    protected void EnemyMove01(GameObject body,Vector3 currentPos,float moveRange)
    {
        body.gameObject.transform.position =new Vector3(currentPos.x, currentPos.y + Mathf.Sin(Time.time) * moveRange, currentPos.z);
    }

    //�U���p���\�b�h

    /// <summary>
    /// ���@�_��
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
    /// ���C�\�� Nway�e
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
        
        

        //Vector3 enemyShooterPos = enemyShooter.gameObject.transform.position;
        //bulletObject.transform.position = enemyShooterPos;
        //Vector3 shootVector = Vector3.forward.normalized;
        //bulletObject.GetComponent<Rigidbody2D>().velocity = shootVector * bulletSpeed;
    }

}
