using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �A�v���P�[�V��������p
/// </summary>
public class SystemManager : MonoBehaviour
{
    private void Awake()
    {
        //�t���[�����[�g�Œ艻
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
}
