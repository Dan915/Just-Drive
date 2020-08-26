using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PowerUpsData", menuName = "Custom/PowerUpsData", order = 0)]
public class PowerUpsData : ScriptableObject {

    public enum PowerUpName
    {
        magnet, shield
    }
    public PowerUpName PowerName;
    public string description;
    public string[] upgradeDescription;
    public Sprite artwork; 
    public GameObject prefab;
    public float duration;
    public int strenght;
    public int Range;
    public int[] upgradePrice;    

}
