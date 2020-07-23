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
    public Toggle toggle;
    public Volume volume;

    private void Awake() 
    {
        worldGenerator = GameObject.FindGameObjectWithTag("WorldGenerator");
        anim = gameObject.GetComponentInChildren<Animator>();
    }
    #region Main Menu Panel
        
    public void Play()
    {
        worldGenerator.GetComponent<WorldGenerator>().gameStarted = true;
        worldGenerator.GetComponent<WorldGenerator>().targetSpeed = 15;
        Debug.Log("Fade out the canvas panel");
        StartCoroutine(trafficSpawner.GetComponent<trafficSpawner>().Delay());
        anim.SetTrigger("FadeOut");
        StartCoroutine(Fade());
    }
    public void Options()
    {
        anim.SetTrigger("Flip");
    }
    public void Quit()
    {
        Application.Quit();
    }
   
    #endregion

    #region Options Menu
    public void GoBack()
    {
        anim.SetTrigger("FlipBack");
    }
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1f);
        options.SetActive(false);
        mainMenu.SetActive(false);
        // gameUI.SetActie(True);
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
