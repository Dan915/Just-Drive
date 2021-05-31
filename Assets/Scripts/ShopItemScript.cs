using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Michsky.UI.ModernUIPack;

public class ShopItemScript : MonoBehaviour
{

    public PowerUpsData powerUp;
    public Image powerUpImage;
    public TextMeshProUGUI[] upgradesDescription, upgradePrice;
    public NotificationManager noMoney;
    // Start is called before the first frame update
    void Start()
    {
        powerUpImage.sprite = powerUp.artwork;
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

        if (ScoreManager.instance.coins >= powerUp.upgradePrice[0])
        {    
            if (powerUp.durationUpgradeCount < 5)
            {
                ScoreManager.instance.coins -= powerUp.upgradePrice[0];
                ScoreManager.instance.UpdateCoins();
                powerUp.duration += 5;
                powerUp.upgradePrice[0] += 10000;
                UpdatePrices();
                powerUp.durationUpgradeCount++;
            }
        }
        else
        Debug.Log("Nope. Get More Money!!!!!");
        

    }
    public void BuyStrength()
    {
        if (ScoreManager.instance.coins >= powerUp.upgradePrice[1])
        {
            if (powerUp.strenghtUpgradeCount < 5)
            {
                if (powerUp.name == "Magnet")

                powerUp.strenght += 5;
                else
                powerUp.strenght += 1;
                ScoreManager.instance.coins -= powerUp.upgradePrice[1];
                ScoreManager.instance.UpdateCoins();
                powerUp.upgradePrice[1] += 10000;
                UpdatePrices();
                powerUp.strenghtUpgradeCount ++;
            }
        }
        else
        Debug.Log("You do not have enough money. Go Get Some");
    }
    public void BuyRange()
    {
        if (ScoreManager.instance.coins >= powerUp.upgradePrice[2])
        {
            if (powerUp.rangeUpgradeCount < 5)
            {
                ScoreManager.instance.coins -= powerUp.upgradePrice[2];
                ScoreManager.instance.UpdateCoins();
                powerUp.range += 10;
                powerUp.upgradePrice[2] += 10000;
                UpdatePrices();
                powerUp.rangeUpgradeCount++;
            }
        }
        else
        {
            Debug.Log("Nope. Get More Money!!!!!");
            ShowMessage(noMoney, "Title","You don't have enough money. Go get some more");
        }    
    }
    public void ShowMessage(NotificationManager noti, string title, string message)
    {
        noti.title = title;
        noti.description = message;
        noti.OpenNotification();
    }

    
}
