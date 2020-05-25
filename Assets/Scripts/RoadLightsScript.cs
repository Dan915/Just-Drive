using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLightsScript : MonoBehaviour
{
    Light spotLight;
    float timeOfDay, currentTime;
    DayNightController DayNightController;
    // Start is called before the first frame update
    void Start()
    {
        spotLight = this.GetComponentInChildren<Light>();
        DayNightController = Camera.main.GetComponent<DayNightController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DayNightController.currentTimeOfDay;
        if (currentTime <= 0.2 || currentTime >= 0.75)
        {
            spotLight.intensity = 100;
            spotLight.enabled = true;
        }
        else
        spotLight.enabled = false;
    }
}
