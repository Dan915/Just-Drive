using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldShaderScript : MonoBehaviour
{
    public Material material;
    public PowerUpsData powerUp;
    float duration;
    public float t = 0;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        duration = powerUp.duration;
    }
    
    private void Update() 
    { 
        material.SetFloat("gradientValue", Mathf.Lerp(0, 1,  t / duration));
        if (t >= duration/2)
        material.SetFloat("fadeSpeed", Mathf.Lerp(0, 20, t));

        t += 1 * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > duration)
        {
            material.SetFloat("gradientValue", 0);
            material.SetFloat("fadeSpeed", 0);
            t = 0.0f;
            //this.gameObject.SetActive(false);
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isShieldActivated = false;
            //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().shieldEffect.SetActive(false);         

        }
    }


}
