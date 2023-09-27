using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSuperClass : MonoBehaviour
{


    protected float angle;//�p�x
    protected float speed;//���x
    protected Vector3 verocity;//�ړ���

    protected GameObject salmon;//�v���C���[�I�u�W�F�N�g
    protected Vector3 salmonPosition;//�v���C���[Position

    

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

    protected void ShootAimSalmon()//���@�_���e
    {        
        
    }

    /// <summary>
    /// //�������̃��[�J���p�x��left�Ɍ������đO�i
    /// </summary>
    /// <param name="speed"></param>
    protected void ShootStraight(float speed)
    {
        this.transform.Translate(Vector2.left * speed);
    }

}
