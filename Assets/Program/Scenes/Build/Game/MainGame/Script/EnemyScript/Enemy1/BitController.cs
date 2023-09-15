using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitController : MonoBehaviour
{
    private GameObject enemy1Object;
    private Enemy1 enemy1Script;

    [SerializeField]
    private int enemyState;

    [SerializeField]
    private GameObject bitBody;

    [SerializeField]
    private GameObject bitShooter;

    private GameObject target;
    private Transform targetPosition;

    Vector3 toDirection;//���������    

    private void LookAtSalmon()
    {
        toDirection = (targetPosition.transform.position - bitBody.transform.position).normalized;//�����o��
        bitBody.transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);//Quaternion�Ō���
    }

    private void Awake()
    {
        target = GameObject.FindWithTag("Salmon");
        targetPosition = target.transform;        
    }

    private void Update()
    {
        LookAtSalmon();
    }
}
