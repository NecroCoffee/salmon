using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// �X�C�J�j�󎞂̉��o����
/// </summary>
public class BuildingScoreEffect : MonoBehaviour
{
    [SerializeField] private GameObject scoreEffectHolder;
    [SerializeField] private TextMeshPro socreText;

    [SerializeField] private GameObject moveTargetObject;

    [SerializeField] private Rigidbody2D rig2D;

    

    private string setText;

    

    /// <summary>
    /// �X�R�A���Z�b�g
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
