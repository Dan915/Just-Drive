using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PowerUpsData", menuName = "Custom/PowerUpsData", order = 0)]
public class PowerUpsData : ScriptableObject {


    public new string name;
    public string description;
    public string upgrade1Description, upgrade2Description;
    public Sprite artwork; 
    public GameObject prefab;
    public float duration;
    public float strenght;
    public int upgrade1Price, upgrade2Price;    

}
