using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetCam : MonoBehaviour
{
    private Camera playerCam;
    private Quaternion initRot;
    private Vector3 initPos;
    void Start()
    {
        playerCam = Camera.main;
        initPos = playerCam.transform.position;
        initRot = playerCam.transform.rotation;
    }

    // Update is called once per frame
    public void ButtonPressed()
    {
       playerCam.transform.position = initPos;
       playerCam.transform.rotation = initRot;
    }
}
