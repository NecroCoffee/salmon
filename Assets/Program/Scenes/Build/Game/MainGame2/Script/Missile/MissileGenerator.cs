using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Missileマーカー生成用スクリプト
/// </summary>
public class MissileGenerator : MonoBehaviour
{
    [SerializeField] private float repeatTime = 7f;
    [SerializeField] private float currentTime;
    [SerializeField] private float startTimeDiff = 3f;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private float missileGenerateDistance = 4f;

    /*
     上は8f
     下は-5.25f
     が上限    
     */

    [SerializeField] private const float constLimitPosUpper = 8f;
    [SerializeField] private const float constLimitPosUnder = -5.25f;

    /*
     左端はx=-14f
     上端はy=7.5f
         */

    [SerializeField] private const float constMarkerPosX = -14f;
    [SerializeField] private const float constMarkerPosY = 7.5f;

    [SerializeField] private GameObject playerObject;
    [SerializeField] private Vector3 playerPos;


    [SerializeField] private GameObject missileMarker;//Missileマーカー
    [SerializeField] private GameObject homingMissileMarker;//横ホーミングMissileマーカー


    //Missileマーカー生成用メソッド
    private void GenerateMissileSide(float markerPosY)
    {
        Instantiate(missileMarker, new Vector3(constMarkerPosX, markerPosY, 0), Quaternion.Euler(Vector3.zero));
    }

    private void GenerateMissileVertical(float markerPosX)
    {
        Instantiate(missileMarker, new Vector3(markerPosX, constMarkerPosY, 0), Quaternion.Euler(new Vector3(0, 0, -90)));
    }

    private void GenerateHomingMissileSide(float markerPosY)
    {
        Instantiate(homingMissileMarker, new Vector3(constMarkerPosX, markerPosY, 0), Quaternion.Euler(Vector3.zero));
    }

    private void GenerateHomingMissileVertical(float markerPosX)
    {
        Instantiate(homingMissileMarker, new Vector3(markerPosX, constMarkerPosY, 0), Quaternion.Euler(new Vector3(0, 0, -90)));
    }
    //------------------------------

    //Missileマーカー生成パターンメソッド

    /// <summary>
    /// プレイヤーの真後ろに生成
    /// </summary>
     private void GenerateMissilePatternLeft01()
    {
        GenerateMissileSide(playerPos.y);
    }


    /// <summary>
    /// プレイヤーの真後ろとその上下に生成(間隔 4f)
    /// </summary>
    private void GenerateMissilePatternLeft02()
    {
        float upperPos = playerPos.y + missileGenerateDistance;
        float underPos = playerPos.y - missileGenerateDistance;
        GenerateMissileSide(playerPos.y);

        if (upperPos <= constLimitPosUnder)
        {
            GenerateMissileSide(upperPos);
        }

        if (underPos >= constLimitPosUnder)
        {
            GenerateMissileSide(underPos);
        }
    }

    /// <summary>
    /// プレイヤーを上下に挟み込む様に生成
    /// </summary>
    private void GenerateMissilePatternLeft03()
    {
        float upperPos = playerPos.y + missileGenerateDistance;
        float underPos = playerPos.y - missileGenerateDistance;

        if (upperPos <= constLimitPosUnder)
        {
            GenerateMissileSide(upperPos);
        }

        if (underPos >= constLimitPosUnder)
        {
            GenerateMissileSide(underPos);
        }
    }

    /// <summary>
    /// プレイヤーの真後ろにホーミングミサイルを生成
    /// </summary>
    private void GenerateHomingMissilePatternLeft01()
    {
        GenerateHomingMissileSide(playerPos.y);
    }

    /// <summary>
    /// プレイヤーの真後ろとその上下にホーミングMissileを生成
    /// </summary>
    private void GenerateHomingMissilePatternLeft02()
    {
        float upperPos = playerPos.y + missileGenerateDistance;
        float underPos = playerPos.y - missileGenerateDistance;

        GenerateHomingMissileSide(playerPos.y);

        if (upperPos <= constLimitPosUnder)
        {
            GenerateHomingMissileSide(upperPos);
        }

        if (underPos >= constLimitPosUnder)
        {
            GenerateHomingMissileSide(underPos);
        }
    }

    /// <summary>
    /// プレイヤーを上下に挟み込む様にホーミングMissileを生成
    /// </summary>
    private void GenerateHomingMissilePatternLeft03()
    {
        float upperPos = playerPos.y + missileGenerateDistance;
        float underPos = playerPos.y - missileGenerateDistance;

        if (upperPos <= constLimitPosUnder)
        {
            GenerateHomingMissileSide(upperPos);
        }

        if (underPos >= constLimitPosUnder)
        {
            GenerateHomingMissileSide(underPos);
        }
    }

    /// <summary>
    /// プレイヤーの真上に生成
    /// </summary>
    private void GenerateMissilePatternUp01()
    {
        GenerateMissileVertical(playerPos.x);
    }

    /// <summary>
    /// プレイヤーの真上と左右にMissileを生成
    /// </summary>
    private void GenerateMissilePatternUp02()
    {
        float rightPos = playerPos.x + missileGenerateDistance;
        float leftPos = playerPos.x - missileGenerateDistance;

        GenerateMissileSide(playerPos.x);

        if (rightPos <= constLimitPosUnder)
        {
            GenerateMissileSide(rightPos);
        }

        if (leftPos >= constLimitPosUnder)
        {
            GenerateMissileSide(leftPos);
        }
    }

    /// <summary>
    /// プレイヤーを左右に挟み込む様にMissileを生成
    /// </summary>
    private void GenerateMissilePatternUp03()
    {
        float rightPos = playerPos.x + missileGenerateDistance;
        float leftPos = playerPos.x - missileGenerateDistance;

        GenerateMissileSide(playerPos.x);

        if (rightPos <= constLimitPosUnder)
        {
            GenerateMissileSide(rightPos);
        }

        if (leftPos >= constLimitPosUnder)
        {
            GenerateMissileSide(leftPos);
        }
    }

    /// <summary>
    /// プレイヤーの真上にホーミングミサイルを生成
    /// </summary>
    private void GenerateHomingMissilePatternUp01()
    {
        GenerateHomingMissileVertical(playerPos.x);
    }

    /// <summary>
    /// プレイヤーの真上と左右にホーミングMissileを生成
    /// </summary>
    private void GenerateHomingMissilePatternUp02()
    {
        float rightPos = playerPos.x + missileGenerateDistance;
        float leftPos = playerPos.x - missileGenerateDistance;

        GenerateHomingMissileSide(playerPos.x);

        if (rightPos <= constLimitPosUnder)
        {
            GenerateHomingMissileSide(rightPos);
        }

        if (leftPos >= constLimitPosUnder)
        {
            GenerateHomingMissileSide(leftPos);
        }
    }

    /// <summary>
    /// プレイヤーの上方向左右にホーミングMissileを生成
    /// </summary>
    private void GenerateHomingMissilePatternUp03()
    {
        float rightPos = playerPos.x + missileGenerateDistance;
        float leftPos = playerPos.x - missileGenerateDistance;

        GenerateHomingMissileSide(playerPos.x);

        if (rightPos <= constLimitPosUnder)
        {
            GenerateHomingMissileSide(rightPos);
        }

        if (leftPos >= constLimitPosUnder)
        {
            GenerateHomingMissileSide(leftPos);
        }
    }

    //-----------------------------------

    //ミサイルランダム生成用メソッド
    private void MissileGenerateRandom()
    {
        int rand = Random.Range(0, 11);

        switch (rand)
        {
            case 0:
                GenerateMissilePatternLeft01();
                break;
            case 1:
                GenerateMissilePatternLeft02();
                break;
            case 2:
                GenerateMissilePatternLeft03();
                break;
            case 3:
                GenerateHomingMissilePatternLeft01();
                break;
            case 4:
                GenerateHomingMissilePatternLeft02();
                break;
            case 5:
                GenerateHomingMissilePatternLeft03();
                break;
            case 6:
                GenerateMissilePatternUp01();
                break;
            case 7:
                GenerateMissilePatternUp02();
                break;
            case 8:
                GenerateMissilePatternUp03();
                break;
            case 9:
                GenerateHomingMissilePatternUp01();
                break;
            case 10:
                GenerateHomingMissilePatternUp02();
                break;
            case 11:
                GenerateHomingMissilePatternUp03();
                break;
        }
    }

    //-----------------------------------
    private void Start()
    {
        currentTime = 0;
        currentTime = currentTime - startTimeDiff;
    }

    private void Awake()
    {
        gameManager = (GameObject.FindWithTag("GameManager")).GetComponent<GameManager>();
    
        playerObject = GameObject.FindWithTag("Salmon");
        playerPos = playerObject.gameObject.transform.position;
        /*
         * テストケース
         */

        //GenerateMissileSide(playerPos.y);
        //GenerateMissileVertical(playerPos.x);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        playerPos = playerObject.gameObject.transform.position;
        if (currentTime >= repeatTime)
        {
            MissileGenerateRandom();

            currentTime = 0;
        }
        
    }
}
