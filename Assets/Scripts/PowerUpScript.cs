using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField]
    PowerUpsData PowerUp;
    public bool isMagnet, isShield;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //PowerUp = gameObject.GetComponent<PowerUpsData>();
        switch (PowerUp.PowerName)
        {
            case PowerUpsData.PowerUpName.magnet:
                isMagnet = true;
                break;
            case PowerUpsData.PowerUpName.shield:
                isShield = true;
                break;
            default:
            break;
        }

        // 7, 5, 2
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0, 80 * Time.deltaTime,0,Space.World);
        transform.position = new Vector3(transform.position.x,(Mathf.Sin(Time.time) * 0.25f) + 1,transform.position.z);
    }
    private void OnTriggerEnter(Collider player) 
    {
        if (player.tag == "Player")
        {
            if (isMagnet)
            StartCoroutine(player.GetComponent<PlayerController>().ActivateMagnet());
            else if (isShield)
            StartCoroutine(player.GetComponent<PlayerController>().ActivateShield());
            //player.GetComponent<PlayerController>().isShieldActivated = true;

            //Debug.Log("Turn on the shield");
            // else if (isAnotherPowerUp)
            // Activate another power up
        }
    }

}
