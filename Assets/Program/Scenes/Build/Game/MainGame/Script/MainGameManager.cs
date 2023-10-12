using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���C���Q�[���V�[������p�X�N���v�g
/// </summary>
public class MainGameManager : MonoBehaviour
{
    //�R���|�[�l���g�ǂݍ���
    private MainGameData mainGameData = new MainGameData();
    
    

    //�v���C���[����\����
    bool playerCanControl = false;
    
    //�v���C���[�֌W�̕ϐ��̐錾

    //�v���C���[�����ʒu
    [SerializeField] private GameObject playerPrefabGeneratePositionObject;
    private Vector3 playerPrefabGeneratePosition;
    //�v���C���[�����ʒu
    [SerializeField] private GameObject playerSpawnPositionObject;
    private Vector3 playerSpawnPosition;

    //�v���C���[�o���p���\�b�h

    [SerializeField] private GameObject playerPrefab;

    private struct PlayerSpawnMethodStruct
    {
        public GameObject playerObject;
    }

    private PlayerSpawnMethodStruct PlayerSpawnMethod;

    /// <summary>
    /// direction��-90������
    /// </summary>
    /// <param name="playerPrefab"></param>
    /// <param name="spawnPoint"></param>
    /// <param name="direction"></param>
    private void PlayerSpawn(GameObject playerPrefab,Vector3 spawnPoint,float direction)
    {
        PlayerSpawnMethod.playerObject = Instantiate(playerPrefab, spawnPoint, Quaternion.Euler(new Vector3(0, 0, direction))) as GameObject;
        return;
    }

    /// <summary>
    /// �����ʒu�Ə����ʒu�̍��W�����
    /// </summary>
    private void GetGenerationPoint()
    {
        playerPrefabGeneratePosition = playerPrefabGeneratePositionObject.transform.position;
        playerSpawnPosition = playerSpawnPositionObject.transform.position;
        return;
    }

    

    private struct PlayerSpawnMoveMethodStruct
    {
        public float distance;
        public float speed;
    }

    PlayerSpawnMoveMethodStruct PlayerSpawnMoveMethod;

    



    

    /// <summary>
    /// �v���C���[������ړ�����
    /// </summary>
    /// <param name="distance"></param>
    /// <param name="speed"></param>
    private void PlayerSpawnMove(float distance,float speed)
    {
        float currentPosition = (Time.fixedDeltaTime * speed) / distance;
        PlayerSpawnMethod.playerObject.transform.position = transform.position = Vector3.Lerp(playerPrefabGeneratePosition, playerSpawnPosition, currentPosition);
        return;
    }

    private bool PlayerCanMove(bool moveFlag)
    {
        //
        //�v���C���[�̈ړ���������ʒm�𑗂�
        //
        return true;
    }


    [SerializeField] private float PlayerSpawnMoveSpeed = 1f;

    /// <summary>
    /// �v���C���[�ړ��p�\���̂ɃV���A���C�Y�������ϐ��Ƃ����u�`����
    /// </summary>
    private void PlayerMoveMethodStructsAssignment()
    {
        PlayerSpawnMoveMethod.speed = PlayerSpawnMoveSpeed;
        PlayerSpawnMoveMethod.distance = Vector2.Distance(playerPrefabGeneratePosition, playerSpawnPosition);
    }





    //-----------------------------
    //�L���b�V���ΏۃR���|�[�l���g


    /// <summary>
    /// �R���|�[�l���g�L���b�V��: GetComponent�̌��ʂ��L���b�V�����Ă������߂̃N���X
    /// </summary>
    public sealed class ComponentCache<T>
    {
        private T m_cache;
        private bool m_isCached;

        public T Get(GameObject gameObject)
        {
            // UnityEngine.Object �� null �`�F�b�N�͏������ׂ������邽��
            // bool �l�Ŕ��肷��悤�ɂ��Ă��܂�
            if (m_isCached) return m_cache;
            if (m_cache != null) return m_cache;

            m_cache = gameObject.GetComponent<T>();
            m_isCached = m_cache != null;

            return m_cache;
        }
    }

    //

    //player
    

    [SerializeField] private GameObject[] playerCounterBullets = new GameObject[5];

    [SerializeField] private GameObject defaultPlayerCounterBullet;

    [SerializeField] public GameObject currentPlayerCounterBullet;

    [SerializeField] public int playerHP = 50;


    //enemy
    [SerializeField] public GameObject MGMcurrentEnemy;

    [SerializeField] public GameObject MGMnextEnemy;

    [SerializeField] private GameObject[] EnemyList = new GameObject[5];

    /// <summary>
    /// MainGameData�̍\���̂̒��g�̏�����
    /// </summary>
    private void MainGameDataStatusInitialize()
    {
        MainGameData.PlayerData.HP = playerHP;
        
    }

    /// <summary>
    /// MainGameData�̍\���̂̒��g�̍X�V
    /// </summary>
    private void MainGameDataStatusUpdate()
    {
        MainGameData.PlayerData.HP = playerHP;

        

    }

    private void Awake()
    {
        currentPlayerCounterBullet = defaultPlayerCounterBullet;
        MGMcurrentEnemy = EnemyList[0];
        MGMcurrentEnemy = EnemyList[1];

        Instantiate(EnemyList[0], new Vector3(10, 0, 0), Quaternion.identity);

        mainGameData = this.gameObject.GetComponent<MainGameData>();
        MainGameDataStatusInitialize();
        
    }

    

    private void Update()
    {
        MainGameDataStatusUpdate();
    }

    private void FixedUpdate()
    {
        
    }


}
