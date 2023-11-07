using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Missileマーカー用スクリプト　一定時間経過後自身の後方にMissileプレハブを生成する
/// </summary>
public class MissileMarker : MonoBehaviour
{
    [SerializeField] private GameObject missile;
    [SerializeField] private GameObject missileGeneratePositionObject;
    [SerializeField] private Vector3 missileGeneratePosition;
    [SerializeField] private int countdown=180;

    [SerializeField] private float maxMarkerSize = (float)(1.5 / 60);
    

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (countdown % 60 == 0)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
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
            this.transform.localScale += new Vector3(maxMarkerSize, maxMarkerSize);
            countdown--;
        }
    
    }
}
