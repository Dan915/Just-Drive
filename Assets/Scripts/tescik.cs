using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tescik : MonoBehaviour
{
    public bool isLandscape;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLandscape)
        Screen.orientation = ScreenOrientation.Landscape;
       if (Input.GetKeyDown(KeyCode.Q))
        QualitySettings.SetQualityLevel(3,true);
        else if (Input.GetKeyDown(KeyCode.E))
        QualitySettings.SetQualityLevel(1,true);
        
        
        
    }
}
