using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GarageCameraOrbit : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    [Range(0,1)]
    float dollyPath;
    [Range(0, 0.1f)]
    public float rotationSpeed;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(dollyPath < 1)
            dollyPath += rotationSpeed * Time.deltaTime;
        else
            dollyPath = 0;

        cinemachine.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition  = dollyPath;
    }
}
