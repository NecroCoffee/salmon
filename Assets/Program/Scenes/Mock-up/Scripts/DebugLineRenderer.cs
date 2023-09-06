using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// デバッグ用線描画スクリプト
/// </summary>
public class DebugLineRenderer : MonoBehaviour
{
    

    //コンポーネント取得
    private LineRenderer lineRenderer;
    //線描画用配列を宣言
    private Vector3[] linePostions;


    //オブジェクト取得＆オブジェクト座標宣言
    [SerializeField]
    private GameObject angleMax;
    [SerializeField]
    private Vector3 angleMaxPos;

    [SerializeField]
    private GameObject angleMin;
    [SerializeField]
    private Vector3 angleMinPos;

    [SerializeField]
    private GameObject axis;
    [SerializeField]
    private Vector3 axisPos;
    //

    private void Start()
    {
        
    }

    private void Awake()
    {
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();

        //座標定義処理
        angleMaxPos = angleMax.transform.localPosition;
        angleMinPos = angleMin.transform.localPosition;
        axisPos = axis.transform.localPosition;

        //定義した座標を配列に詰める
        linePostions = new Vector3[]
        {
            axisPos,
            angleMaxPos,
            angleMinPos
        };

        lineRenderer.positionCount = linePostions.Length;

        // 描画
        lineRenderer.SetPositions(linePostions);

    }

    private void Update()
    {
        
    }
}
