using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class tescik : MonoBehaviour
{
    public bool isLandscape;
    public GameObject Volume;
    Volume volume;
    Bloom bloom;
    [Range (0,2)] public float bloomIntensity;   
    
    // Start is called before the first frame update
    void Start()
    {
        // Disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        volume = Volume.GetComponent<Volume>();
        bloom = volume.GetComponent<Bloom>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLandscape)
            Screen.orientation = ScreenOrientation.Landscape;
        // change game graphics settings 
        if (Input.GetKeyDown(KeyCode.Q))
            QualitySettings.SetQualityLevel(3,true);
        else if (Input.GetKeyDown(KeyCode.E))
            QualitySettings.SetQualityLevel(1,true);
        
        
        
    }

    public void HighSettings()
    {
        QualitySettings.SetQualityLevel(2,true);
    }
    public void MediumSettings()
    {
        QualitySettings.SetQualityLevel(1,true);
    }
    public void LowSettings()
    {
        QualitySettings.SetQualityLevel(0,true);
    }
    public void  PostProcessingOff()
    {
        //Volume.SetActive(false);
        volume.enabled = false;
    }
    public void  PostProcessingOn()
    {
        //Volume.SetActive(true);
        volume.enabled = true;
    }
    public void BloomOn()
    {
        bloom.intensity.value = 1f;
    }
    public void BloomOff()
    {
        bloom.intensity.value = 0f;
    }
}
