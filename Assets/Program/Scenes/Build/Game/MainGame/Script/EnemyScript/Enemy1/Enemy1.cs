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

    [SerializeField]
    private Transform EnemyChildrenTransform;//Enemy�I�u�W�F�N�g�̎q�I�u�W�F�N�g��Transform�R���|�[�l���g������

    [SerializeField]
    private Rigidbody2D EnemyChildrenRig2D;//Enemy�I�u�W�F�N�g�̎q��Rig2D������

    [SerializeField]
    private GameObject[] EnemyBulletPrefabs = new GameObject[4];//�G�p�e�v���n�u�i�[�p�z��(���ŏ��4)

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

    //-----------------------------------


    //�f�t�H���g������o�������l���i�[����ϐ�
    private float enemyMoveSpeed;

    private float enemyMoveMode;


    //Enemy1��ԑJ��

    [SerializeField]
    private int defaultEnemyMoveState = 0;//Enemy�X�e�[�g�����l

    [SerializeField]
    private int enemyState;//���݂�Enemy�X�e�[�g�l


    [SerializeField]
    private bool enemyDeathFlag = false;//��������(True�Ō��j)

    [SerializeField]
    private bool enemyFrenzyFlag = false;//�����t���O

    [SerializeField]
    private bool enemyTimeOver = false;//���Ԑ؂ꔻ��

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

    private void ChengeState(EnemyState stateName)//�X�e�[�g�ύX�p���\�b�h
    {
        nextState = stateName;
    }


    //Enemy1�ړ��p���\�b�h


    [SerializeField]
    private float enemyMoveStartTime = 5f;//�o�ꉉ�o����
    private void EnemyMoveStart()//�o�ꎞ�ړ�
    {
        if(this.transform.position==defaultEnemyPosition)
        {
            nextState = EnemyState.ATTACK1;
            return;
        }
    }

    private void EnemyMoveNomal()//�ʏ펞�ړ�
    {

    }

    private void EnemyMoveFrenzy()//�������ړ�
    {

    }

    private void EnemyMoveTimeOver()//���Ԑ؂�ړ�
    {

    }

    //--------------------------------------------

    //Enemy1�U���p���\�b�h

    private void EnemyAttackNomal_1()//�ʏ�U��1
    {

    }

    private void EnemyAttackNomal_2()//�ʏ�U��2
    {

    }

    private void EnemyAttackNomal_3()//�ʏ�U��3
    {

    }

    private void EnemyAttackFrenzy_1()//�������U��1
    {

    }

    private void EnemyAttackFrenzy_2()//�������U��2
    {

    }

    private void EnemyAttackFrenzy_3()//�������U��3
    {

    }

    private void EnemyAttackFrenzy_4()//�������U��4
    {

    }

    private void EnemyAttackTimeOver()//���Ԑ؂�U��
    {

    }

    //--------------------------------------------

    //Enemy�̈ړ��ƍU�����܂Ƃ߂����\�b�h

    private void EnemyActionPatternNomal_1()
    {
        EnemyMoveNomal();
        EnemyAttackNomal_1();
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
        switch (nowState)
        {
            case EnemyState.NONE:
                //�f�o�b�O�p���\�b�h������
                break;
            case EnemyState.START:
                //�X�^�[�g�p���\�b�h������
                break;
            case EnemyState.ATTACK1:
                EnemyActionPatternNomal_1();
                break;
            case EnemyState.ATTACK2:
                break;
            case EnemyState.ATTACK3:
                break;
            case EnemyState.FRENZY1:
                break;
            case EnemyState.FRENZY2:
                break;
            case EnemyState.FRENZY3:
                break;
            case EnemyState.FRENZY4:
                break;
            case EnemyState.TIMEOVER:
                break;
        }
    }

}
