using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    [Header("Rotation Settings")]
    [Range(50f,100f)]
    public float speed = 1f;
    public int points = 50;
    GameObject worldGenerator;
    
    void Start()
    {
        worldGenerator = GameObject.FindGameObjectWithTag("WorldGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0,speed * Time.deltaTime,0,Space.World);
        transform.position = new Vector3(transform.position.x,(Mathf.Sin(Time.time) * 0.25f) + 1,transform.position.z);
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("Add points to score");
            gameObject.SetActive(false);
            // gameManager.GetComponent<gameManager().score += points;
            worldGenerator.GetComponent<WorldGenerator>().score += points;
            
        }
    }
}
