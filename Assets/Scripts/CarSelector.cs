using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CarSelector : MonoBehaviour
{
    public CarData carData;
    public GameObject player;
    public int price;
    public bool isUnlocked = false;
    public Image thumbnail;
    // Start is called before the first frame update
    void Start()
    {
        price = carData.price;
        isUnlocked = carData.isUnlocked;
    }

    public void ChooseCar()
    {
        thumbnail.sprite = carData.thumbnail;
        if (isUnlocked)
        {
            player.GetComponentInChildren<PlayerController>().car = carData.prefab;
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
