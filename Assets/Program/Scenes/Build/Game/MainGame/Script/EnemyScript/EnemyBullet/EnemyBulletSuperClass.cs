using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSuperClass : MonoBehaviour
{


    protected float bulletAngle;//�p�x
    protected float bulletSpeed;//���x
    protected Vector3 bulletVerocity;//�ړ���

    protected GameObject salmon;//�v���C���[�I�u�W�F�N�g
    protected Vector3 salmonPosition;//�v���C���[Position

    

    protected GameObject SearchPlayerObject()//�v���C���[�I�u�W�F�N�g�������\�b�h
    {
        GameObject salmon = GameObject.FindWithTag("Salmon");
        return salmon;
    }
    
    protected void DeleteBullet()
    {
        Destroy(this.gameObject);
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

    protected void ShootAimSalmon()//���@�_���e
    {        
        
    }

    /// <summary>
    /// //�������̃��[�J���p�x��left�Ɍ������đO�i
    /// </summary>
    /// <param name="speed"></param>
    protected void ShootStraight(Vector2 direction,float speed)
    {
        this.transform.Translate(direction.normalized * speed);
    }

    protected void ShootPingPong(Vector2 direction,float speed,float length)
    {
        var pingpongLength = Mathf.PingPong(Time.fixedDeltaTime, length);

        this.transform.localPosition = new Vector3(0, pingpongLength, 0);
        this.transform.Translate(direction.normalized * speed);
    }

}
