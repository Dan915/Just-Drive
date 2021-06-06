using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Michsky.UI.ModernUIPack;

public class Customization : MonoBehaviour
{
    [Tooltip("assign all wheels of the carso that they can be changed")]
    [SerializeField]
    //public GameObject[] wheelsFront, wheelsRear;
    public List<GameObject> wheelsFront = new List<GameObject>();
    public List<GameObject> wheelsRear = new List<GameObject>();
    public GameObject[] cars;
    
    [Header("Materials")][Tooltip("assign materials for car")]
    public Material[] carMats;

    [ColorUsage(false,false)][Tooltip("Color of the wheels")]
    public Color wheelsColor;
    [Range(0,1)]
    public float specular, metallic;
    [Range(0, 12)]
    public int _index;
    public Slider specularSlider, metallicSlider;
    public HorizontalSelector materialSelector;

    void Start()
    {
        StartCoroutine(DoChangeMatt());
    }
    IEnumerator DoChangeMatt()
    {
       // yield return new WaitForSeconds(0.1f);
        yield return new WaitForEndOfFrame();
        ChangeMaterial(materialSelector.index);
    }

    // Update is called once per frame
    public void ChangeMaterial(int i)
    {
        foreach (var car in cars)
        {
            //if (car.activeInHierarchy)
            car.GetComponentInChildren<MeshRenderer>().material = carMats[i];  
        }
    }
    public void ChangeWheelsMaterial()
    {
        foreach (var wheel in wheelsFront)
        {
            if (wheel.activeInHierarchy)
            {
                wheel.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", wheelsColor);
                wheel.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", metallic);
                wheel.GetComponent<MeshRenderer>().material.SetFloat("_Smoothness", specular);
                //wheel.GetComponent<MeshRenderer>().material = carMats[1];
            }
        }
        foreach (var wheel in wheelsRear)
        {
            if (wheel.activeInHierarchy)
            {
                wheel.GetComponent<MeshRenderer>().material.SetColor("_BaseColor", wheelsColor);
                wheel.GetComponent<MeshRenderer>().material.SetFloat("_Metallic", metallic);
                wheel.GetComponent<MeshRenderer>().material.SetFloat("_Smoothness", specular);
                //wheel.GetComponent<MeshRenderer>().material = carMats[1];
            }
        }
    }
    public void NextMaterial()
    {
        if(_index >12)
        _index = 12;
        else _index++;
    }
    public void PreviousMaterial()
    {
        if(_index <1)
        _index = 0;
        else _index--;
    }
    public void ChangeSpecular()
    {
        specular = specularSlider.value;
    }
    public void ChangeMetallic()
    {
        metallic = metallicSlider.value;
    }
}
