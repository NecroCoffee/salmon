using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy1�p�X�N���v�g
/// </summary>
public class Enemy1 : MonoBehaviour
{


    [SerializeField]
    private GameObject EnemyObject;//������������I�u�W�F�N�g������


    //�e��f�t�H���g���l
    
    [SerializeField]
    private float defaultEnemyMoveSpeed = 1f;//�ړ����x

    [SerializeField]
    private GameObject defaultEnemySpawnPositionObject;//Enemy�����ʒu�Q�Ɨp�I�u�W�F�N�g

    [SerializeField]
    private Vector3 defaultEnemySpawnPosition;//Enemy�������W(Vector3)

    [SerializeField]
    private GameObject defaultEnemyPositionObject;//�����ʒu�Q�Ɨp�I�u�W�F�N�g

    [SerializeField]
    private Vector3 defaultEnemyPosition;//�����ʒu(vector3)


    //�f�t�H���g������o�������l���i�[����ϐ�
    private float enemyMoveSpeed;

    private float enemyMoveMode;


    //Enemy1��ԑJ��

    [SerializeField]
    private int defaultEnemyMoveState = 0;//Enemy�X�e�[�g�����l

    [SerializeField]
    private int enemyState;//���݂�Enemy�X�e�[�g�l

    [SerializeField]
    private bool enemyFrenzyFlag = false;//�����t���O

    [System.Serializable]
    private enum EnemyState//Enemy�X�e�[�g(enum)
    {
        NONE=-1,//�f�o�b�O�p

        START=0,//�o��

        ATTACK1,//�U���p�^�[��1
        ATTACK2,//�U���p�^�[��2
        ATTACK3,//�U���p�^�[��3

        FRENZY1,//�����p�^�[��1
        FRENZY2,//�����p�^�[��2
        FRENZY3,//�����p�^�[��3
        FRENZY4,//�����p�^�[��4

        TIMEOVER,//���Ԑ؂�
    }

    private EnemyState nowState = EnemyState.START;//���݂̃X�e�[�g
    private EnemyState nextState = EnemyState.START;//���̃X�e�[�g


    //Enemy1�ړ��p���\�b�h


    private void EnemyMoveStart()//�o�ꎞ
    {

    }

    private void EnemyMoveNomal()//�ʏ펞
    {

    }

    private void EnemyMoveFrenzy()//������
    {

    }

    private void EnemyMoveTimeOver()//���Ԑ؂�
    {

    }

    //--------------------------------------------

    //����������
    private void Awake()
    {
        //�v���n�u�L�����㏉���l�擾

        


        //null�`�F�b�N
        if (defaultEnemyPositionObject == null)
        {
            defaultEnemyPositionObject = GameObject.FindWithTag("EnemyDefaultPositionObject");
        }

        if (defaultEnemySpawnPositionObject == null)
        {
            defaultEnemySpawnPositionObject = GameObject.FindWithTag("EnemySpawnPositionObject");
        }

        //-----------------------------

        //�ϐ�������
        enemyState = defaultEnemyMoveState;//�X�e�[�g�����l���

        defaultEnemySpawnPosition = defaultEnemySpawnPositionObject.gameObject.transform.position;//�v���n�u�����������W���

        defaultEnemyPosition = defaultEnemyPositionObject.gameObject.transform.position;//Enemy�������W���

        enemyMoveSpeed = defaultEnemyMoveSpeed;
        //-----------------------------
    }

    private void Update()
    {
        
    }

}
