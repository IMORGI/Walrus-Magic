using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsLock : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this);
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;


    }
}
