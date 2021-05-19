using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour
{

    public Light sun, moon;
    public float secondsInFullDay = 120f;
    [Range(0, 1)]
    public float currentTimeOfDay = 0;
    [HideInInspector]
    public float timeMultiplier = 1f;
    public Color[] lightColor;
    public Color[] skyboxTint;
    public Material[] skybox;
    Color currentSkyboxColor, skyboxColor;
    public GameObject water;
    //public Gradient fogColors;
    float sunInitialIntensity;
    Color currentColor, color; 
    float currentExposure;
    GameObject worldGenerator;

    private void Awake() 
    {
        worldGenerator = GameObject.FindGameObjectWithTag("WorldGenerator");
        currentTimeOfDay = 0.4f;
    }
    void Start()
    {
        sunInitialIntensity = sun.intensity;
    }

    void Update()
    {
        UpdateSun();
        currentColor = water.GetComponent<MeshRenderer>().material.GetColor("_SpecColor");
        water.GetComponent<MeshRenderer>().material.SetColor("_SpecColor", color);

        //currentSkyboxColor = skybox[1].GetColor("_TintColor");
        //skybox[1].SetColor("_TintColor", skyboxColor);
        currentExposure = skybox[1].GetFloat("_Exposure");

        if (worldGenerator.GetComponent<WorldGenerator>().gameStarted == true)
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        if (currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }

        //water reflections
        if (currentTimeOfDay <= 0.28f)
        {
            color =  Color.Lerp(currentColor, lightColor[0], 2 * Time.deltaTime);
            RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, lightColor[3], 0.1f* Time.deltaTime);
            
        }
        else if (currentTimeOfDay <= 0.3f)
        {
            color =  Color.Lerp(currentColor, lightColor[1], 2 * Time.deltaTime);
            RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, lightColor[1], 2* Time.deltaTime);
        }
        else if (currentTimeOfDay >= 0.6f && currentTimeOfDay < 0.7f)
        {
            color =  Color.Lerp(currentColor, lightColor[1], 2 * Time.deltaTime);
            RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, lightColor[1], 2* Time.deltaTime);
        }
        else if (currentTimeOfDay >= 0.7f)
        {
            color =  Color.Lerp(currentColor, lightColor[3], 2 * Time.deltaTime);
            RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, lightColor[3], 2* Time.deltaTime);
        }
        else
        {
            color = Color.Lerp(currentColor, lightColor[2], 2  *Time.deltaTime);
            RenderSettings.fogColor = Color.Lerp(RenderSettings.fogColor, lightColor[2], 2* Time.deltaTime);
        }

        //if (currentTimeOfDay >= 0.2f || currentTimeOfDay <= 0.8f)
            //skyboxColor =  Color.Lerp(currentSkyboxColor, skyboxTint[0], 2 * Time.deltaTime);
        if (currentTimeOfDay <= 0.18f || currentTimeOfDay >= 0.775f)
        {
            RenderSettings.skybox = skybox[1];
            RenderSettings.sun = moon;
            //RenderSettings.fog = false;
            moon.intensity = Mathf.Lerp(moon.intensity, 0.5f, 1 *Time.deltaTime);

            if (currentTimeOfDay >= 0.8f)
                skybox[1].SetFloat("_Exposure", Mathf.Lerp(currentExposure, 0.35f, 0.5f * Time.deltaTime));
            else if (currentTimeOfDay <= 0.15f)
                skybox[1].SetFloat("_Exposure", Mathf.Lerp(currentExposure, 0.25f, 1 * Time.deltaTime));
        }
        else
        {
            RenderSettings.skybox = skybox[0];
            skybox[1].SetFloat("_Exposure", Mathf.Lerp(currentExposure ,0.15f, 1 * Time.deltaTime));         
            RenderSettings.sun = sun;
            //RenderSettings.fog = true;
        }






        if (currentTimeOfDay >= 0.14f && currentTimeOfDay <= 0.7f)
            moon.intensity = Mathf.Lerp(moon.intensity, 0.15f, 5 * Time.deltaTime);
       
           // skyboxColor = Color.Lerp( currentSkyboxColor, skyboxTint[0], 2 * Time.deltaTime);
        //RenderSettings.fogColor = fogColors.Evaluate(currentTimeOfDay);
    }

    void UpdateSun()
    {

        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f)
        {
            intensityMultiplier = 0;  
                      
        }
        else if (currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }
 
            


        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }

   
}