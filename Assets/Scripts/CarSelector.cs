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
    public ButtonManagerBasic buyButton;
    // Start is called before the first frame update
    void Start()
    {
        price = carData[0].price;
        isUnlocked = carData[0].isUnlocked;
        thumbnail = carData[0].thumbnail;
        Image.GetComponent<Image>().sprite = thumbnail;
        mySelector.defaultIndex = 0;
    }
    void Update()
    {
        
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
    public void HotHatch()
    {
        int i = 2;
        Debug.Log("Choose HotHatch");
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
        if (ScoreManager.instance.coins >= currentCarSelected.price && !isUnlocked)
        {
            ScoreManager.instance.coins -= currentCarSelected.price;
            ScoreManager.instance.UpdateCoins();
            isUnlocked = true;
            currentCarSelected.isUnlocked = true;
            Debug.Log("Bought new car");
        }
        else
        Debug.Log("not enough money to buy the car");
    }


}
