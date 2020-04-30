using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pooledObjectDisabler : MonoBehaviour
{
    public GameObject trafficSpawner;
    

    private void OnTriggerEnter(Collider _object) 
    {
        if (_object.tag == "Collectable")
        _object.gameObject.SetActive(false);

        if (_object.tag == "Obstacle")
        {
            _object.gameObject.SetActive(false);
            trafficSpawner.GetComponent<trafficSpawner>().SpawnTraffic();
        }
    }
}
