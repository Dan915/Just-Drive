using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score, highScore, coins, coinValue;
    public TextMeshProUGUI scoreText, highScoreText, coinsText;
    public WorldGenerator worldGenerator;

    private void Awake() 
    {
        instance = this;
    }

    public void AddCoin(int coinValue)
    {
        coins+= coinValue;

        coinsText.text = coins.ToString();
        worldGenerator.score = coins;
    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString() + "m";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
