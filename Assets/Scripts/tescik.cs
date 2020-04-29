using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tescik : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Q))
        QualitySettings.SetQualityLevel(3,true);
        else if (Input.GetKeyDown(KeyCode.E))
        QualitySettings.SetQualityLevel(1,true);
        
        
        
    }
}
