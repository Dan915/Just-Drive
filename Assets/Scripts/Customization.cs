using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customization : MonoBehaviour
{
    [Tooltip("assign all wheels of the carso that they can be changed")]
    public GameObject[] wheels;
    public GameObject car;
    
    [Header("Materials")][Tooltip("assign materials for car")]
    public Material[] carMats;

    [ColorUsage(false,false)][Tooltip("Color of the wheels")]
    public Color wheelsColor;
    [Range(0,1)]
    public float specualr, metallic;
    [Range(0, 12)]
    public int i;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        car.GetComponent<MeshRenderer>().material = carMats[i];
        foreach (var wheel in wheels)
        {
            //wheel.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", wheelsColor);
            //wheel.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", metallic);
            //wheel.GetComponent<MeshRenderer>().material.SetFloat("_Smoothness", specualr);
            wheel.GetComponent<MeshRenderer>().material = carMats[1];
        }
    }
}
