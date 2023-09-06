using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �f�o�b�O�p���`��X�N���v�g
/// </summary>
public class DebugLineRenderer : MonoBehaviour
{
    

    //�R���|�[�l���g�擾
    private LineRenderer lineRenderer;
    //���`��p�z���錾
    private Vector3[] linePostions;


    //�I�u�W�F�N�g�擾���I�u�W�F�N�g���W�錾
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

        //���W��`����
        angleMaxPos = angleMax.transform.localPosition;
        angleMinPos = angleMin.transform.localPosition;
        axisPos = axis.transform.localPosition;

        //��`�������W��z��ɋl�߂�
        linePostions = new Vector3[]
        {
            axisPos,
            angleMaxPos,
            angleMinPos
        };

        lineRenderer.positionCount = linePostions.Length;

        // �`��
        lineRenderer.SetPositions(linePostions);

    }

    private void Update()
    {
        
    }
}
