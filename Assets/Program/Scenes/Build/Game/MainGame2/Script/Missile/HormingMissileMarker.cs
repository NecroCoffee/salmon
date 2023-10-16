using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ホーミングMissileマーカー用スクリプト　一定時間経過後自身の後方にプレイヤーの方向を向かせた状態でMissileプレハブを生成する
/// </summary>
public class HormingMissileMarker : MonoBehaviour
{
    [SerializeField] private GameObject missile;
    [SerializeField] private GameObject missileGeneratePositionObject;
    [SerializeField] private Vector3 missileGeneratePosition;
    [SerializeField] private int countdown = 180;

    //ロックオン用変数
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Vector3 toDirection;
    


    private void Awake()
    {
        playerObject = GameObject.FindWithTag("Salmon");        
    }

    private void Update()
    {
        if (countdown >= 60)
        {
            //rotation = playerObject.transform.position - this.gameObject.transform.position;
            //quaternion = Quaternion.LookRotation(rotation).normalized;
            //this.gameObject.transform.localRotation = quaternion;

            toDirection= playerObject.transform.position - this.gameObject.transform.position;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.right, toDirection);

        }

        if (countdown <= 0)
        {
            Vector3 markerPosition = this.gameObject.transform.position;
            missileGeneratePosition = missileGeneratePositionObject.transform.position;
            GameObject instantiateMissile = Instantiate(missile) as GameObject;
            instantiateMissile.transform.position = missileGeneratePosition;
            instantiateMissile.transform.rotation = this.gameObject.transform.rotation;
            //instantiateMissile.transform.position = markerPosition * -1;
            Destroy(this.gameObject);
        }
        else
        {
            countdown--;
        }

    }
}
