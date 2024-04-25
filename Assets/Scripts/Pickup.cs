using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[RequireComponent (typeof(Rigidbody))]
public class playerPickup : MonoBehaviour
{
    /* Public Variables */
    public float rayRange;
    public Transform topPosition;

    /* Private Variables */
    private Vector3     mOffset;
    private float       mZCoord;
    private Rigidbody   rb;
    private Camera      boardCam;
    private float       elevation;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        boardCam = Camera.main;
        rayRange = 3.0f;
    }

    void OnMouseDown()
    {
        rb.useGravity = false;
        mZCoord = boardCam.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return boardCam.ScreenToWorldPoint(mousePoint);
    }
    
    private void OnMouseUp()
    {
        rb.useGravity = true;
    }

    void OnMouseDrag()
    {
        Ray         bottomRay    = new Ray(transform.position, Vector3.down);
        RaycastHit  bottomhit;
        Vector3     newPos = GetMouseAsWorldPoint() + mOffset;

        if (Input.GetKey(KeyCode.Q))
            transform.eulerAngles += new Vector3(0, -2, 0);

        if (Input.GetKey(KeyCode.E))
            transform.eulerAngles += new Vector3(0, 2, 0);

        if (Physics.Raycast(bottomRay, out bottomhit, rayRange))
        {

            Debug.Log(bottomhit.collider.gameObject.name);
            if (bottomhit.transform.Find("topPos"))
                elevation = (bottomhit.transform.Find("topPos")).position.y ;

            else
                elevation = (bottomhit.collider.bounds.center + Vector3.up * (bottomhit.collider.bounds.extents.y)).y;
        }

        if (newPos.y < elevation) 
        {
            newPos.y = elevation;
            newPos.x = (GetMouseAsWorldPoint() + mOffset).x;
            newPos.z = (GetMouseAsWorldPoint() + mOffset).z;
            rb.MovePosition(newPos);
        }

        else
        {
            transform.position = newPos;
        }
    }

}
