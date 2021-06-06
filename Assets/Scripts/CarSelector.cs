using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Michsky.UI.ModernUIPack;
public class CarSelector : MonoBehaviour
{
    public CarData[] carData;
    public GameObject car;
    private CarData currentCarSelected;
    public GameObject player;
    public int price;
    public bool isUnlocked = false;
    public GameObject Image, vechiclePreview;
    Sprite thumbnail;
    public HorizontalSelector mySelector;
    public ButtonManagerBasic buyButton;
    private int currentCar ;
    // Start is called before the first frame update
    void Start()
    {
        price = carData[0].price;
        isUnlocked = carData[0].isUnlocked;
        thumbnail = carData[0].thumbnail;
        Image.GetComponent<Image>().sprite = thumbnail;
        //vechiclePreview = carData[0].prefab;
        ChooseVechicle(mySelector.index);
    }
    void Update()
    {
        
    }
    public void ChooseVechicle(int i)
    {
        for (int index = 0; index < car.transform.childCount; index++)
        {
            car.transform.GetChild(index).gameObject.SetActive(index ==i);
        }
        Debug.Log(carData[i].carName + " has been choosen");
        price = carData[i].price;
        isUnlocked = carData[i].isUnlocked;
        thumbnail = carData[i].thumbnail;
        Image.GetComponent<Image>().sprite = thumbnail;
        if (isUnlocked)
        {
            //player.GetComponentInChildren<PlayerController>().car = carData[i].prefab;
            player.GetComponent<PlayerController>().ChangeCar(carData[i].prefab);
        }
        else
        {
            Debug.Log("Go get some money");
        }
        currentCarSelected = carData[i]; 
    }

    public void ChangeCar(int _change)
    {
        currentCar = _change;

        if(currentCar <0)
        currentCar = 0;
        else if(currentCar >= car.transform.childCount)
        currentCar = car.transform.childCount;

        ChooseVechicle(currentCar);
    }
    public void VechicleVan()
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
    public void VechicleCoupe()
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
    public void VechicleHotHatch()
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

    public void VechicleEstate()
    {
        int i = 3;
        Debug.Log("Choose Estate");
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
