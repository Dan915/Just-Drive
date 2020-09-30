using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Michsky.UI.ModernUIPack;
public class CarSelector : MonoBehaviour
{
    public CarData[] carData;
    public GameObject player;
    public int price;
    public bool isUnlocked = false;
    public GameObject Image;
    Sprite thumbnail;
    public HorizontalSelector mySelector;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ChooseCar()
    {
        Debug.Log("Choose Car");
        price = carData[0].price;
        isUnlocked = carData[0].isUnlocked;

        thumbnail = carData[0].thumbnail;
        Image.GetComponent<Image>().sprite = thumbnail;
        if (isUnlocked)
        {
            player.GetComponentInChildren<PlayerController>().car = carData[0].prefab;
        }
        else
        {
            Debug.Log("Go get some money");
        }
     
    }
    
    public void BuyCar()
    {
        isUnlocked = true;
    }

}
