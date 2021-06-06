using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using Michsky.UI.ModernUIPack;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    GameObject worldGenerator;
    [SerializeField]GameObject mainMenu, shopMenu, optionsMenu, pauseMenu, gameUI, loadingBar;
    public GameObject trafficSpawner;
    Animator anim;
    [SerializeField] AnimationClip loading;
    [SerializeField] Image panelImage;
    float duration;
    public Toggle toggle;
    public Volume volume;
    [Space (20), Header ("Shop Objects")]
    public PowerUpsData[] upgrades;
    public GameObject[] shopItems;
    private void Awake() 
    {
        worldGenerator = GameObject.FindGameObjectWithTag("WorldGenerator");
        anim = gameObject.GetComponentInChildren<Animator>();
        duration = loading.length;
        mainMenu.SetActive(false);
        panelImage.enabled = true;
    }
    private void Start() 
    {
        StartCoroutine(Loading());
    }
//////////////////////////////////////////////////////////////////////
    #region Main Menu Panel
        
    public void Play()
    {
        worldGenerator.GetComponent<WorldGenerator>().gameStarted = true;
        worldGenerator.GetComponent<WorldGenerator>().targetSpeed =20;
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
    public void Shop()
    {
        //anim.SetTrigger("ShopFlip");
        SceneManager.LoadScene("Garage");
    }
    IEnumerator Loading()
    {
        yield return new WaitForSeconds(duration);
        mainMenu.SetActive(true);
        loadingBar.SetActive(false);
    }
   
    #endregion
//////////////////////////////////////////////////////////////////////
    #region Options Menu
    public void GoBack()
    {
        anim.SetTrigger("FlipBack");
    }

    IEnumerator Fade()
    {
        panelImage.enabled = false;
        yield return new WaitForSeconds(0.5f);
        gameUI.SetActive(true);
        optionsMenu.SetActive(false);
        mainMenu.SetActive(false);
        // gameUI.SetActie(True);
    }

   
    public void graphicsHigh()
    {
        QualitySettings.SetQualityLevel(2,true);
        Debug.Log(QualitySettings.GetQualityLevel());
    }

    public void graphicsMedium()
    {
        QualitySettings.SetQualityLevel(1,true);
        Debug.Log(QualitySettings.GetQualityLevel());
    }

    public void graphicsLow()
    {
        QualitySettings.SetQualityLevel(0,true);
        Debug.Log(QualitySettings.GetQualityLevel());
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
///////////////////////////////////////////////////////////////////// 
    #region Shop Menu
    
    public void GoBackShop()
    {
        anim.SetTrigger("ShopFlipReverse");
    }

    #endregion
/////////////////////////////////////////////////////////////////////    
    #region Gameplay UI
    public void PauseGame()
    {
        anim.SetTrigger("Pause");
        Time.timeScale = 0;
        StartCoroutine(EnterPauseMenu());
    }
    public void ResumeGame()
    {
        anim.SetTrigger("Resume");
        StartCoroutine(ExitPauseMenu());
    }
    IEnumerator EnterPauseMenu()
    {
        yield return new WaitForSecondsRealtime(0.25f);
        pauseMenu.SetActive(true);
    }
    IEnumerator ExitPauseMenu()
    {
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    #endregion
}
