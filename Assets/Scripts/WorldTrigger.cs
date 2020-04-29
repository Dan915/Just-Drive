using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTrigger : MonoBehaviour
{
    public GameObject worldGenerator;
    // Start is called before the first frame update
    void Start()
    {
        worldGenerator =  GameObject.FindGameObjectWithTag("WorldGenerator");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            worldGenerator.GetComponent<WorldGenerator>().PickAndGeneratePiece();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(this.gameObject, 3.5f);
        }
    }
}
