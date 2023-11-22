using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// スイカ破壊時の演出処理
/// </summary>
public class BuildingScoreEffect : MonoBehaviour
{
    [SerializeField] private GameObject scoreEffectHolder;
    [SerializeField] private TextMeshPro socreText;

    [SerializeField] private GameObject moveTargetObject;

    [SerializeField] private Rigidbody2D rig2D;

    

    private string setText;

    

    /// <summary>
    /// スコアをセット
    /// </summary>
    /// <param name="targetScore"></param>
    private void SetScore(int targetScore)
    {
        
    }

    private void Awake()
    {
        
        rig2D.AddForce(Vector2.up, ForceMode2D.Impulse);
    }
}
