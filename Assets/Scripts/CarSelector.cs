using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Michsky.UI.ModernUIPack;
public class CarSelector : MonoBehaviour
{
    public CarData[] carData;
    private CarData currentCarSelected;
    public GameObject player;
    public int price;
    public bool isUnlocked = false;
    public GameObject Image;
    Sprite thumbnail;
    public HorizontalSelector mySelector;
    // Start is called before the first frame update
    void Start()
    {
        price = carData[0].price;
        isUnlocked = carData[0].isUnlocked;
        thumbnail = carData[0].thumbnail;
        Image.GetComponent<Image>().sprite = thumbnail;
        mySelector.defaultIndex = 0;
    }

    public void Van()
    {
        int i = 1;
        Debug.Log("Choose Car");
        price = carData[i].price;
        isUnlocked = carData[i].isUnlocked;
        thumbnail = carData[i].thumbnail;
        Image.GetComponent<Image>().sprite = thumbnail;
        if (isUnlocked)
        {
            player.GetComponentInChildren<PlayerController>().car = carData[i].prefab;
        }
        else
        {
            Debug.Log("Go get some money");
        }
        currentCarSelected = carData[i];
     
    }
    public void Coupe()
    {
        int i = 0;
        Debug.Log("Choose Coupe");
        price = carData[i].price;
        isUnlocked = carData[i].isUnlocked;
        thumbnail = carData[i].thumbnail;
        Image.GetComponent<Image>().sprite = thumbnail;
        if (isUnlocked)
        player.GetComponentInChildren<PlayerController>().car = carData[i].prefab;
        else
            Debug.Log("Get more Money");
        
        currentCarSelected = carData[i];
    }
    
    public void BuyCar()
    {
        Debug.Log("if enough money buy the car");
        isUnlocked = true;
        currentCarSelected.isUnlocked = true;
    }

}
