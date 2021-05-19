using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateSetting : MonoBehaviour
{
    public int FrameRate;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
