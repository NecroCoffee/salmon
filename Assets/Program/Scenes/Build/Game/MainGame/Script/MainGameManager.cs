using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���C���Q�[���V�[������p�X�N���v�g
/// </summary>
public class MainGameManager : MonoBehaviour
{

    [SerializeField] public GameObject MGMcurrentEnemy;

    [SerializeField] public GameObject MGMnextEnemy;

    [SerializeField] private List<GameObject> EnemyList = new List<GameObject>();

    
    private void Awake()
    {
        
    }

    


}
