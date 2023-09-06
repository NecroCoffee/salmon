using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アプリケーション制御用
/// </summary>
public class SystemManager : MonoBehaviour
{
    private void Awake()
    {
        //フレームレート固定化
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
}
