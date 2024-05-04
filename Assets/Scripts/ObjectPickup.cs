using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public float forceAmount = 10f;

    [SerializeField]Rigidbody   selectedRigidbody;
    Camera          targetCamera;
    Vector3         originalScreenTargetPosition;
    Vector3         originalRigidbodyPos;
    private float   rotVel;
    float           selectionDistance;
    public float    rayDist;

    [SerializeField] private LayerMask layer;


    void Start()
    {
        targetCamera = GetComponent<Camera>();
        rayDist = 50f;
        rotVel = 100f;
    }

    void Update()
    {
        if (!targetCamera)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            selectedRigidbody = GetRigidbodyFromMouseClick();

            if(selectedRigidbody && selectedRigidbody.gameObject.name != "Dice")
                selectedRigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        }

        if (Input.GetMouseButtonUp(0) && selectedRigidbody)
        {
            selectedRigidbody.constraints = RigidbodyConstraints.None;
            selectedRigidbody = null;
        }

        if (Input.GetKey(KeyCode.E) && selectedRigidbody )
        {
            selectedRigidbody.transform.Rotate(new Vector3(0,rotVel,0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Alpha2) && selectedRigidbody)
        {
            selectedRigidbody.transform.position = new Vector3 (0,8.02f,0);
            selectedRigidbody.velocity = Vector3.zero;
            selectedRigidbody = null;
        }

        if (Input.GetKey(KeyCode.X) && selectedRigidbody)
        {
            selectedRigidbody.transform.rotation = Quaternion.identity;
        }
  
        if (Input.GetKey(KeyCode.Q) && selectedRigidbody)
        {
            selectedRigidbody.transform.Rotate(new Vector3(0, -rotVel, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Z) && selectedRigidbody)
        {
            if (selectedRigidbody.gameObject.layer == 7)
            {
                selectedRigidbody.transform.Rotate(new Vector3(0, 0, -rotVel) * Time.deltaTime);
            }
            else
                selectedRigidbody.transform.Rotate(new Vector3(-rotVel, 0, 0) *Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.C) && selectedRigidbody)
        {
            if (selectedRigidbody.gameObject.layer == 7)
            {
                selectedRigidbody.transform.Rotate(new Vector3(0, 0, rotVel) * Time.deltaTime);
            }
            else
                selectedRigidbody.transform.Rotate(new Vector3(rotVel, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.F) && selectedRigidbody)
        {
            selectedRigidbody.transform.Rotate(new Vector3(180, 180, 0));
        }

    }


    void FixedUpdate()
    {
        if (selectedRigidbody)
        {
            if (Input.GetMouseButton(3))
            {
                selectionDistance -= 5.5f * Time.deltaTime;
                if(selectionDistance < 1)
                    selectionDistance = 1;
            }
                

            if (Input.GetMouseButton(4))
                selectionDistance += 5.5f * Time.deltaTime;

            Vector3 mousePositionOffset = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance)) - originalScreenTargetPosition;

            Vector3 newPos = originalRigidbodyPos + mousePositionOffset;

           
            selectedRigidbody.velocity = (newPos - selectedRigidbody.transform.position) * forceAmount * Time.deltaTime;
            
            if (selectedRigidbody.gameObject.name == "Dice" && Input.GetKey(KeyCode.R))
            {
                Debug.Log("Yes");
                selectedRigidbody.AddTorque(new Vector3(Random.Range(1,500), Random.Range(1, 500), Random.Range(1, 500)));
            }
        }
    }

    Rigidbody GetRigidbodyFromMouseClick()
    {
        Ray ray = targetCamera.ScreenPointToRay(Input.mousePosition);
        bool hit = Physics.Raycast(ray, out RaycastHit hitInfo,rayDist,layer);
        if (hit)
        {
            if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
            {
                selectionDistance = Vector3.Distance(ray.origin, hitInfo.point);
                originalScreenTargetPosition = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));
                originalRigidbodyPos = hitInfo.collider.transform.position;
                return hitInfo.collider.gameObject.GetComponent<Rigidbody>();
            }
        }

        return null;
    }
}