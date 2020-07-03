using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    GameObject worldGenerator;
    public GameObject[] mainMenu;
    [SerializeField]GameObject options;

    private void Awake() 
    {
        worldGenerator = GameObject.FindGameObjectWithTag("WorldGenerator");
    }
    public void Play()
    {
        worldGenerator.GetComponent<WorldGenerator>().gameStarted = true;
        Debug.Log("Fade out the canvas panel");
    }
    public void Options()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }
   
}
