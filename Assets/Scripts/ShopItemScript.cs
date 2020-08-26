using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemScript : MonoBehaviour
{

    public PowerUpsData powerUp;
    public Image powerUpImage;
    public int[] price;
    public TextMeshProUGUI[] upgradesDescription, upgradePrice;
    int durationCounter = 0, strenghtCounter = 0, RangeCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        //powerUpImage.sprite = powerUp.artwork;
      //  upgradesDescription[0].text = powerUp.upgradeDescription[0];
        //upgradesDescription[1].text = powerUp.upgrade2Description;
        //upgradesDescription[1].text = powerUp.upgrade3Description;
      //  price[0] = powerUp.upgrade1Price;
        //price[1] = powerUp.upgrade2Price;
        //price[2] = powerUp.upgrade3Price;
       // upgradePrice[0].text = "Price: " + price[0].ToString();
        //upgradePrice[1].text = "Price: " + price[2].ToString();
        //upgradePrice[2].text = "Price: " + price[3].ToString();
        UpdatePrices();
    }
    public void UpdatePrices()
    {
        for (int i = 0; i < upgradesDescription.Length; i++)
        {
            upgradesDescription[i].text = powerUp.upgradeDescription[i];
        }
        for (int i = 0; i < upgradePrice.Length; i++)
        {
            upgradePrice[i].text = "Price: " + powerUp.upgradePrice[i];
        }
    }
    public void BuyDuration()
    {

        if (durationCounter < 5)
        {
            powerUp.duration += 5;
            powerUp.upgradePrice[0] += 10000;
            UpdatePrices();
            durationCounter++;
        }
    }
    public void BuyStrength()
    {
        if (strenghtCounter < 5)
        {
            if (powerUp.name == "Magnet")

            powerUp.strenght = powerUp.strenght + 5;
            else
            powerUp.strenght += 1;

            powerUp.upgradePrice[1] += 10000;
            UpdatePrices();
            strenghtCounter ++;
        }
    }
    public void BuyRange()
    {
        if (RangeCounter < 5)
        {
            powerUp.Range = powerUp.Range + 10;
            powerUp.upgradePrice[2] += 10000;
            UpdatePrices();
            RangeCounter++;
        }
    }

    
}
