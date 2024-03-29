﻿// FloatingOrigin.cs
// Written by Peter Stirling
// 11 November 2010
// Uploaded to Unify Community Wiki on 11 November 2010
// Updated to Unity 5.x particle system by Tony Lovell 14 January, 2016
// fix to ensure ALL particles get moved by Tony Lovell 8 September, 2016
// URL: http://wiki.unity3d.com/index.php/Floating_Origin
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Camera))]
public class FloatingOrigin : MonoBehaviour
{
    public float threshold = 100.0f;
    public WorldGenerator worldGenerator;

    void LateUpdate()
    {
        Vector3 cameraPosition = gameObject.transform.position;
        cameraPosition.y = 0f;
        cameraPosition.x = 0f;

        if (cameraPosition.magnitude > threshold)
        {

            for (int z = 0; z < SceneManager.sceneCount; z++)
            {
                foreach (GameObject g in SceneManager.GetSceneAt(z).GetRootGameObjects())
                {
                    if (g.transform.tag != "Ignore" && g.transform.tag != "Water")
                    g.transform.position -= cameraPosition;
                    else if (g.transform.tag == "Water")
                    g.transform.position = new Vector3(0,g.transform.position.y, GameObject.FindGameObjectWithTag("Player").transform.position.z);
                }
            }

            Vector3 originDelta = Vector3.zero - cameraPosition;
            worldGenerator.UpdateSpawnOrigin(originDelta);
            Debug.Log("recentering, origin delta = " + originDelta);
        }

    }
}