using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class MainMenuScript : MonoBehaviour
{
    GameObject worldGenerator;
    [SerializeField]GameObject mainMenu, options;
    public GameObject trafficSpawner;
    Animator anim;
    Toggle toggle;
    Volume volume;

    private void Awake() 
    {
        worldGenerator = GameObject.FindGameObjectWithTag("WorldGenerator");
        anim = gameObject.GetComponentInChildren<Animator>();
    }
    #region Main Menu Panel
        
    public void Play()
    {
        worldGenerator.GetComponent<WorldGenerator>().gameStarted = true;
        Debug.Log("Fade out the canvas panel");
        StartCoroutine(trafficSpawner.GetComponent<trafficSpawner>().Delay());
        anim.SetTrigger("FadeOut");
    }
    public void Options()
    {
        anim.SetTrigger("Flip");
        StartCoroutine(Flip());
    }
    public void Quit()
    {
        Application.Quit();
    }
   
    #endregion

    #region Options Menu
    IEnumerator Flip()
    {
        yield return new WaitForSeconds(1f);
        options.SetActive(true);
        mainMenu.SetActive(false);
    }

    public IEnumerator Back()
    {
        yield return new WaitForSeconds(1f);
        options.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void graphicsHigh()
    {
        QualitySettings.SetQualityLevel(3,true);
    }

    public void graphicsMedium()
    {
        QualitySettings.SetQualityLevel(2,true);
    }

    public void graphicsLow()
    {
        QualitySettings.SetQualityLevel(1,true);
    }

    public void postProcessingToggle()
    {
        if (toggle.isOn)
        {
            volume.enabled = true;
        }
        else
            volume.enabled = false;
    }
        
    #endregion
}
