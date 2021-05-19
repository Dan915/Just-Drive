using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public float score, highScore;
    public int   coins, coinValue;
    public TextMeshProUGUI scoreText, highScoreText, coinsText, coinsTextShop;
    public WorldGenerator worldGenerator;

    private void Awake() 
    {
        instance = this;
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
        coinsTextShop.text = coinsText.text;
    }

    public void AddCoin(int coinValue)
    {
        coins+= coinValue;

        coinsText.text = coins.ToString();
        coinsTextShop = coinsText;
    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString("0") + "m";
    }
    public void SaveScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetFloat("highScore", highScore);
        }
        PlayerPrefs.SetInt("coins", coins);
    }
}
