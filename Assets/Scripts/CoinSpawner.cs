using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    GameObject player;
    Vector3 playerPos;
    [SerializeField]
    Vector3[] spawnOffsets;
    bool hasFoundUniqueNumber = false;
    int tempRandom, lastRandom;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        objectPooler = ObjectPooler.Instance;
    }

    private void Update()
    {
        playerPos = player.transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        SpawnCoins();
    }

    public void SpawnCoins()
    {   
        
        while (!hasFoundUniqueNumber)
        {
            tempRandom = Random.Range(0,spawnOffsets.Length);
            if (tempRandom != lastRandom)
            {
                hasFoundUniqueNumber = true;
                lastRandom = tempRandom;
            }
        }
        
        Vector3 currentPos = playerPos;
        Vector3 spawnPos = playerPos + spawnOffsets[lastRandom];
        int plus = 0;
        
        int poolSize = objectPooler.pools[0].size;
        for (int i = 0; i < poolSize / 4; i++)
        {
            plus += 2; 
            Vector3 offset = new Vector3(0,0,plus);
            objectPooler.SpawnFromPool("Coins", spawnPos + offset, Quaternion.Euler(90,0,0));
        }
        hasFoundUniqueNumber = false;
        
    }
}
