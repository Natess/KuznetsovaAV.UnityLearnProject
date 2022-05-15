using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    PostProcessVolume volume;
    AutoExposure autoExposure;

    [SerializeField]
    float autoExposureValue;
    [SerializeField]
    float ev;
    float part;
    bool isStart;
    // Start is called before the first frame update
    void Start()
    {
        isStart = true;
        volume = GetComponent<PostProcessVolume>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        volume.profile.TryGetSettings(out autoExposure);
        if (!autoExposure.enabled.value)
            autoExposure.enabled.value = true;

        autoExposure.keyValue.value = autoExposureValue;
        if (autoExposure.maxLuminance.value < -0.3 || autoExposure.maxLuminance.value > 0.3)
        {
            autoExposure.maxLuminance.value += part;
            autoExposure.minLuminance.value += part;
            print(part);
            print(autoExposure.maxLuminance.value);
        }

    }

    private void OnTriggerEnter()
    {
        if (isStart)
        {
            volume.profile.TryGetSettings(out autoExposure);
            autoExposure.maxLuminance.value = ev;
            autoExposure.minLuminance.value = ev;
            part = -ev / 500;
            isStart = false;    
        }
    }

    private void OnTriggerExit()
    {
        isStart = true;
        print("exit----------------------------------------------");
    }
}
