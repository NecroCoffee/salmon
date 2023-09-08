using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enemy1用スクリプト
/// </summary>
public class Enemy1 : MonoBehaviour
{


    [SerializeField]
    private GameObject EnemyObject;//動きをさせるオブジェクトを入れる


    //各種デフォルト数値
    
    [SerializeField]
    private float defaultEnemyMoveSpeed = 1f;//移動速度

    [SerializeField]
    private GameObject defaultEnemySpawnPositionObject;//Enemy生成位置参照用オブジェクト

    [SerializeField]
    private Vector3 defaultEnemySpawnPosition;//Enemy生成座標(Vector3)

    [SerializeField]
    private GameObject defaultEnemyPositionObject;//初期位置参照用オブジェクト

    [SerializeField]
    private Vector3 defaultEnemyPosition;//初期位置(vector3)


    //デフォルトから取り出した数値を格納する変数
    private float enemyMoveSpeed;

    private float enemyMoveMode;


    //Enemy1状態遷移

    [SerializeField]
    private int defaultEnemyMoveState = 0;//Enemyステート初期値

    [SerializeField]
    private int enemyState;//現在のEnemyステート値

    [SerializeField]
    private bool enemyFrenzyFlag = false;//発狂フラグ

    [System.Serializable]
    private enum EnemyState//Enemyステート(enum)
    {
        NONE=-1,//デバッグ用

        START=0,//出現

        ATTACK1,//攻撃パターン1
        ATTACK2,//攻撃パターン2
        ATTACK3,//攻撃パターン3

        FRENZY1,//発狂パターン1
        FRENZY2,//発狂パターン2
        FRENZY3,//発狂パターン3
        FRENZY4,//発狂パターン4

        TIMEOVER,//時間切れ
    }

    private EnemyState nowState = EnemyState.START;//現在のステート
    private EnemyState nextState = EnemyState.START;//次のステート


    //Enemy1移動用メソッド


    private void EnemyMoveStart()//登場時
    {

    }

    private void EnemyMoveNomal()//通常時
    {

    }

    private void EnemyMoveFrenzy()//発狂時
    {

    }

    private void EnemyMoveTimeOver()//時間切れ
    {

    }

    //--------------------------------------------

    //初期化処理
    private void Awake()
    {
        //プレハブ有効化後初期値取得

        


        //nullチェック
        if (defaultEnemyPositionObject == null)
        {
            defaultEnemyPositionObject = GameObject.FindWithTag("EnemyDefaultPositionObject");
        }

        if (defaultEnemySpawnPositionObject == null)
        {
            defaultEnemySpawnPositionObject = GameObject.FindWithTag("EnemySpawnPositionObject");
        }

        //-----------------------------

        //変数初期化
        enemyState = defaultEnemyMoveState;//ステート初期値代入

        defaultEnemySpawnPosition = defaultEnemySpawnPositionObject.gameObject.transform.position;//プレハブ生成初期座標代入

        defaultEnemyPosition = defaultEnemyPositionObject.gameObject.transform.position;//Enemy初期座標代入

        enemyMoveSpeed = defaultEnemyMoveSpeed;
        //-----------------------------
    }

    private void Update()
    {
        
    }

}
