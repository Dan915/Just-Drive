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
    public string upgrade1Description, upgrade2Description, upgrade3Description;
    public Sprite artwork; 
    public GameObject prefab;
    public float duration;
    public int strenght;
    public int Range;
    public int upgrade1Price, upgrade2Price, upgrade3Price;    

}
