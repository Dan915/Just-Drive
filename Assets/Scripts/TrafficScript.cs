using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficScript : MonoBehaviour
{
    GameObject worldGenerator, player;
    public float speed;
    public int random;
    bool isDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        worldGenerator = GameObject.FindGameObjectWithTag("WorldGenerator");
        if (worldGenerator.GetComponent<WorldGenerator>().playerSpeed >= 80)
        {
            random = Random.Range(50, 75);
        }
        else if (worldGenerator.GetComponent<WorldGenerator>().playerSpeed >= 50)
        {
            random = Random.Range(20, 50);
        }
        else if (worldGenerator.GetComponent<WorldGenerator>().playerSpeed >= 25)
            random = Random.Range(0,20);
        else
        random = Random.Range(0,4);

        speed = worldGenerator.GetComponent<WorldGenerator>().playerSpeed - random;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDisabled)
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.transform.tag == "Player")
        {
            player.GetComponent<PlayerController>().crashed = true;
            //player.GetComponent<PlayerController>().enabled = false;
            Debug.Log("Game Over");
            isDisabled = true;
        }
    }

    
}
