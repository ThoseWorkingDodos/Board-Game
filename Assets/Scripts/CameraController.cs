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
    [SerializeField] private Transform playerCamTransform;
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
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            playerCamTransform.transform.position = initPos;
            playerCamTransform.transform.rotation = initRot;
            Debug.Log("space key was pressed");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerCamTransform.transform.position -= playerCamTransform.transform.up * 5 * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            playerCamTransform.transform.position += playerCamTransform.transform.up * 5 * Time.deltaTime;
        }

        playerCamTransform.transform.position += playerCamTransform.transform.forward * Input.GetAxis("Vertical") * 5 * Time.deltaTime;
        playerCamTransform.transform.position += playerCamTransform.transform.right * Input.GetAxis("Horizontal") * 5 * Time.deltaTime;

        // Rotate the camera based on the mouse movement
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            playerCamTransform.transform.eulerAngles += new Vector3(0, mouseX * camSens, 0);
            
        }

    }

}
