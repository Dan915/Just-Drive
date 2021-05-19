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
    [Tooltip("Will be displlayed as upgrade description item in the shop")]
    public string[] upgradeDescription;
    public Sprite artwork; 
    public GameObject prefab;
    public float duration;
    public int strenght;
    public int range;
    public int[] upgradePrice;    
    public int durationUpgradeCount, strenghtUpgradeCount, rangeUpgradeCount;

}
