using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// メインゲームシーン制御用スクリプト
/// </summary>
public class MainGameManager : MonoBehaviour
{
    //コンポーネント読み込み
    private MainGameData mainGameData = new MainGameData();
    
    

    //プレイヤー操作可能判定
    bool playerCanControl = false;
    
    //プレイヤー関係の変数の宣言

    //プレイヤー生成位置
    [SerializeField] private GameObject playerPrefabGeneratePositionObject;
    private Vector3 playerPrefabGeneratePosition;
    //プレイヤー初期位置
    [SerializeField] private GameObject playerSpawnPositionObject;
    private Vector3 playerSpawnPosition;

    //プレイヤー出現用メソッド

    [SerializeField] private GameObject playerPrefab;

    private struct PlayerSpawnMethodStruct
    {
        public GameObject playerObject;
    }

    private PlayerSpawnMethodStruct PlayerSpawnMethod;

    /// <summary>
    /// directionは-90を入れる
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
    /// 生成位置と初期位置の座標を取る
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
    /// プレイヤー生成後移動処理
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
        //プレイヤーの移動を許可する通知を送る
        //
        return true;
    }


    [SerializeField] private float PlayerSpawnMoveSpeed = 1f;

    /// <summary>
    /// プレイヤー移動用構造体にシリアライズ化した変数とかをブチ込む
    /// </summary>
    private void PlayerMoveMethodStructsAssignment()
    {
        PlayerSpawnMoveMethod.speed = PlayerSpawnMoveSpeed;
        PlayerSpawnMoveMethod.distance = Vector2.Distance(playerPrefabGeneratePosition, playerSpawnPosition);
    }





    //-----------------------------
    //キャッシュ対象コンポーネント


    /// <summary>
    /// コンポーネントキャッシュ: GetComponentの結果をキャッシュしておくためのクラス
    /// </summary>
    public sealed class ComponentCache<T>
    {
        private T m_cache;
        private bool m_isCached;

        public T Get(GameObject gameObject)
        {
            // UnityEngine.Object の null チェックは少し負荷がかかるため
            // bool 値で判定するようにしています
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
    /// MainGameDataの構造体の中身の初期化
    /// </summary>
    private void MainGameDataStatusInitialize()
    {
        MainGameData.PlayerData.HP = playerHP;
        
    }

    /// <summary>
    /// MainGameDataの構造体の中身の更新
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
