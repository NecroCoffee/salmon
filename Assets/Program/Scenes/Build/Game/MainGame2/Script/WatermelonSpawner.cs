using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatermelonSpawner : MonoBehaviour
{
    //GameManager�I�u�W�F�N�g�ۑ��p
    [SerializeField]
    private GameObject gameManagerObj;

    //GameManager�X�N���v�g
    private GameManager gameManager;

    //�����v���n�u
    [SerializeField]
    private GameObject waterMelon;

    //�X�|�i�[�I�u�W�F�N�g�ϐ�
    [SerializeField]
    private GameObject spawner;

    //�X�|�i�[�c�����ړ��͈�
    [SerializeField]
    private float spawnerMoveRangeY = 2.5f;

    //������v���n�u�ړ���
    [SerializeField]
    private float waterMelonPushFroce = 1.0f;

    //�X�|�i�[���W�ۑ��p
    private Vector2 spawnerPos;

    //���Ԋ֌W

    //�v���n�u�����Ԋu
    [SerializeField]
    private float generateInterval = 25f;

    //�V�[���J�n����
    private float sceneStartTime;

    //�o�ߎ���
    private float time;
    //--------------------------


    //�ϐ�������
    private void InitializeVariable()
    {
        //gameManager = gameManagerObj.GetComponent<GameManager>();
        time = 0.0f;
        sceneStartTime = Time.timeSinceLevelLoad;
        
    }

    //�v���n�u����and�v���n�u�����ݒ�
    private void GenerateWaterMelon(GameObject gameObject)
    {
        //���@�̎���
        GameObject m_gameObject = Instantiate(gameObject, spawner.gameObject.transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D m_rig2d = m_gameObject.GetComponent<Rigidbody2D>();
        //�����ɔ�΂����߂�x�̈�����-1��������
        m_rig2d.AddForce(new Vector2(waterMelonPushFroce * (-1),0));
    }

    //�X�|�i�[�ړ��p
    private void MoveSpawner(GameObject gameObject,float range)
    {
        gameObject.gameObject.transform.position = new Vector2(spawnerPos.x, spawnerPos.y + Mathf.PingPong(Time.time, range));
    }

    private void TimeCount()
    {
        time += Time.deltaTime;
    }


    //---------------
    private void Awake()
    {
        InitializeVariable();


        spawnerPos = spawner.transform.position;
    }

    private void Update()
    {
        TimeCount();
        MoveSpawner(spawner, spawnerMoveRangeY);
        if(time>=generateInterval)
        {
            time = 0.0f;
            GenerateWaterMelon(waterMelon);
            
        }
    }
}
