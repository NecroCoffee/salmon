using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tMousePoint : MonoBehaviour
{


    [SerializeField]
    private Vector3 mousePosition;//�}�E�X�|�W�V����
    [SerializeField]
    private Vector3 mouseWorldPosition;//�ϊ��ハ�[���h���W


    

    private void FixedUpdate()
    {
        mousePosition = Input.mousePosition;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y,10f));
        this.transform.position = mouseWorldPosition;
    }
}
