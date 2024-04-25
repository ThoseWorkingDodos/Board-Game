using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    public float camSens = 5.0f;
    private Vector3 initPos;
    private Quaternion initRot;
    Camera playerCam;
    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponent<Camera>();
        initPos = playerCam.transform.position;
        initRot = playerCam.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerCam.transform.position = initPos;
            playerCam.transform.rotation = initRot;
            Debug.Log("space key was pressed");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerCam.transform.position -= Vector3.up * 5 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerCam.transform.position += Vector3.up * 5 * Time.deltaTime;
        }
      
        playerCam.transform.position += Vector3.forward * Input.GetAxis("Vertical") * 5 * Time.deltaTime;
        playerCam.transform.position += Vector3.right * Input.GetAxis("Horizontal") * 5 * Time.deltaTime;

        // Rotate the camera based on the mouse movement
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            playerCam.transform.eulerAngles += new Vector3(-mouseY * camSens, 0, 0);
        }

    }

}
