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

    [SerializeField]
    private Transform EnemyChildrenTransform;//Enemyオブジェクトの子オブジェクトのTransformコンポーネントを入れる

    [SerializeField]
    private Rigidbody2D EnemyChildrenRig2D;//Enemyオブジェクトの子のRig2Dを入れる

    [SerializeField]
    private GameObject[] EnemyBulletPrefabs = new GameObject[4];//敵用弾プレハブ格納用配列(仮で上限4)

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

    //-----------------------------------


    //デフォルトから取り出した数値を格納する変数
    private float enemyMoveSpeed;

    private float enemyMoveMode;


    //Enemy1状態遷移

    [SerializeField]
    private int defaultEnemyMoveState = 0;//Enemyステート初期値

    [SerializeField]
    private int enemyState;//現在のEnemyステート値


    [SerializeField]
    private bool enemyDeathFlag = false;//生存判定(Trueで撃破)

    [SerializeField]
    private bool enemyFrenzyFlag = false;//発狂フラグ

    [SerializeField]
    private bool enemyTimeOver = false;//時間切れ判定

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

    private void ChengeState(EnemyState stateName)//ステート変更用メソッド
    {
        nextState = stateName;
    }


    //Enemy1移動用メソッド


    [SerializeField]
    private float enemyMoveStartTime = 5f;//登場演出時間
    private void EnemyMoveStart()//登場時移動
    {
        if(this.transform.position==defaultEnemyPosition)
        {
            nextState = EnemyState.ATTACK1;
            return;
        }
    }

    private void EnemyMoveNomal()//通常時移動
    {

    }

    private void EnemyMoveFrenzy()//発狂時移動
    {

    }

    private void EnemyMoveTimeOver()//時間切れ移動
    {

    }

    //--------------------------------------------

    //Enemy1攻撃用メソッド

    private void EnemyAttackNomal_1()//通常攻撃1
    {

    }

    private void EnemyAttackNomal_2()//通常攻撃2
    {

    }

    private void EnemyAttackNomal_3()//通常攻撃3
    {

    }

    private void EnemyAttackFrenzy_1()//発狂時攻撃1
    {

    }

    private void EnemyAttackFrenzy_2()//発狂時攻撃2
    {

    }

    private void EnemyAttackFrenzy_3()//発狂時攻撃3
    {

    }

    private void EnemyAttackFrenzy_4()//発狂時攻撃4
    {

    }

    private void EnemyAttackTimeOver()//時間切れ攻撃
    {

    }

    //--------------------------------------------

    //Enemyの移動と攻撃をまとめたメソッド

    private void EnemyActionPatternNomal_1()
    {
        EnemyMoveNomal();
        EnemyAttackNomal_1();
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
        switch (nowState)
        {
            case EnemyState.NONE:
                //デバッグ用メソッドを入れる
                break;
            case EnemyState.START:
                //スタート用メソッドを入れる
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
