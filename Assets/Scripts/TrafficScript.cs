using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficScript : MonoBehaviour
{
    GameObject worldGenerator, player;
    public float speed;
    public int random;
    bool isDisabled = false;
    public bool objectInFront = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().enabled = true;
        player = GameObject.FindGameObjectWithTag("Player");
        worldGenerator = GameObject.FindGameObjectWithTag("WorldGenerator");
        if (worldGenerator.GetComponent<WorldGenerator>().playerSpeed >= 80)
        {
            random = Random.Range(50, 55);
        }
        else if (worldGenerator.GetComponent<WorldGenerator>().playerSpeed >= 50)
        {
            random = Random.Range(25, 26);
        }
        else if (worldGenerator.GetComponent<WorldGenerator>().playerSpeed >= 25)
            random = Random.Range(15,17);
        else if (worldGenerator.GetComponent<WorldGenerator>().playerSpeed >=18)
            random = Random.Range(9,10);

        speed = worldGenerator.GetComponent<WorldGenerator>().playerSpeed - random;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (!isDisabled && !objectInFront)
        transform.position += Vector3.forward * Time.deltaTime * speed;
        RaycastHit hit;
        Vector3 pos = new Vector3 (transform.position.x, transform.position.y + 1, transform.position.z);
        Vector3 fwd = new Vector3(0,0,15);
        Debug.DrawLine(pos, pos + fwd, Color.green);
        Debug.DrawLine(pos, pos - fwd, Color.red);
        if (Physics.Raycast(pos, pos + fwd, out hit, 15, LayerMask.GetMask("Car")))
        {        
            //objectInFront = true;
            speed = hit.collider.gameObject.GetComponent<TrafficScript>().speed  - 1;
            //speed--;
        }
        // if (Physics.Raycast(pos, pos - fwd, 15, LayerMask.GetMask("Car")))    
        //     speed += Random.Range(1.5f,2);
        else
            objectInFront = false;
        
        
        
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.transform.tag == "Player")
        {
            if (player.GetComponent<PlayerController>().isShieldActivated)
            {
                Physics.IgnoreCollision(player.GetComponent<Collider>(),GetComponent<Collider>());
                player.GetComponent<PlayerController>().shieldLife--;
                Debug.Log("Explode the car");
            // do explosion
            }
            else
            {
                player.GetComponent<PlayerController>().crashed = true;
                //player.GetComponent<PlayerController>().enabled = false;
                Debug.Log("Game Over");
                isDisabled = true;
            }
        }
    }
    void Explode()
    {
        isDisabled = true;
    }

    
}
