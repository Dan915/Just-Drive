using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "Custom/CarData", order = 0)]
public class CarData : ScriptableObject
{
    public bool isUnlocked;
    public int price;
    public GameObject prefab;
    public Sprite thumbnail;
}
