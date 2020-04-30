using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficSpawner : MonoBehaviour
{
    [SerializeField]
    ObjectPooler objectPooler;
    GameObject player;
    Vector3 playerPos;
    [SerializeField]
    Vector3[] spawnOffsets;
    public bool hasFoundUniqueNumber = false;
    int tempRandom, lastRandom;
    public int delayTime;
    // random position
    Vector3 currentPos, spawnPos;

    private void Start() 
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        FindUniqueNumber();
        RandomPosition();
    }

    private void Update()
    {
        playerPos = player.transform.position;

        if (Input.GetKeyDown(KeyCode.F))
        StartCoroutine(SpawnTraffic());

        currentPos = playerPos;
        
    }
    int FindUniqueNumber()
    {
        while (!hasFoundUniqueNumber)
        {
            tempRandom = Random.Range(0,objectPooler.pools.Count);
            if (tempRandom != lastRandom)
            {
                hasFoundUniqueNumber = true;
                lastRandom = tempRandom;
            }
        }
        return lastRandom;
    }

    Vector3 RandomPosition()
    {
        int randPos = Random.Range(0, spawnOffsets.Length);
        spawnPos = new Vector3(spawnOffsets[randPos].x, playerPos.y, playerPos.z + spawnOffsets[randPos].z); 

        return spawnPos;
    }

    public IEnumerator SpawnTraffic()
    {   
        
    
        if (hasFoundUniqueNumber)
        {
            int gap = 0;
            for (int i = 0; i < 50; i++)
            {
                gap += 20;
                Vector3 offset  = new Vector3 (0,0,gap);
                Debug.Log("works here");
                switch (lastRandom)
                {
                    case 0:
                        RandomPosition();
                        objectPooler.SpawnFromPool("car", spawnPos + offset, Quaternion.identity);
                        hasFoundUniqueNumber = false;
                    break;

                    case 1:
                        RandomPosition();
                        objectPooler.SpawnFromPool("car1", spawnPos + offset, Quaternion.identity);
                        hasFoundUniqueNumber = false;
                    break;

                    case 2:
                        RandomPosition();
                        objectPooler.SpawnFromPool("car2", spawnPos + offset, Quaternion.identity);
                        hasFoundUniqueNumber = false;
                    break;
                    case 3:
                        RandomPosition();
                        objectPooler.SpawnFromPool("car3", spawnPos + offset, Quaternion.identity);
                        hasFoundUniqueNumber = false;
                    break;
                    case 4:
                        RandomPosition();
                        objectPooler.SpawnFromPool("car4", spawnPos + offset, Quaternion.identity);
                        hasFoundUniqueNumber = false;
                    break;
                    default:
                    break;
                }  
                FindUniqueNumber();
            }
            yield return new WaitForSeconds(delayTime);
            //StartCoroutine(SpawnTraffic());
                
        }
        
    }
}
