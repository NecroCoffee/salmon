using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatermelonSpawner : MonoBehaviour
{
    //GameManagerオブジェクト保存用
    [SerializeField]
    private GameObject gameManagerObj;

    //GameManagerスクリプト
    private GameManager gameManager;

    //生成プレハブ
    [SerializeField]
    private GameObject waterMelon;

    //スポナーオブジェクト変数
    [SerializeField]
    private GameObject spawner;

    //スポナー縦方向移動範囲
    [SerializeField]
    private float spawnerMoveRangeY = 2.5f;

    //生成後プレハブ移動力
    [SerializeField]
    private float waterMelonPushFroce = 1.0f;

    //スポナー座標保存用
    private Vector2 spawnerPos;

    //時間関係

    //プレハブ生成間隔
    [SerializeField]
    private float generateInterval = 25f;

    //シーン開始時間
    private float sceneStartTime;

    //経過時間
    private float time;
    //--------------------------


    //変数初期化
    private void InitializeVariable()
    {
        //gameManager = gameManagerObj.GetComponent<GameManager>();
        time = 0.0f;
        sceneStartTime = Time.timeSinceLevelLoad;
        
    }

    //プレハブ生成andプレハブ初期設定
    private void GenerateWaterMelon(GameObject gameObject)
    {
        //魔法の呪文
        GameObject m_gameObject = Instantiate(gameObject, spawner.gameObject.transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D m_rig2d = m_gameObject.GetComponent<Rigidbody2D>();
        //左側に飛ばすためにxの引数に-1をかける
        m_rig2d.AddForce(new Vector2(waterMelonPushFroce * (-1),0));
    }

    //スポナー移動用
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
