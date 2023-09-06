using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tMousePoint : MonoBehaviour
{


    [SerializeField]
    private Vector3 mousePosition;//マウスポジション
    [SerializeField]
    private Vector3 mouseWorldPosition;//変換後ワールド座標


    

    private void FixedUpdate()
    {
        mousePosition = Input.mousePosition;
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y,10f));
        this.transform.position = mouseWorldPosition;
    }
}
