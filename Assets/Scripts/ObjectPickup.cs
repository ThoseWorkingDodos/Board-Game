using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public float forceAmount = 10f;

    [SerializeField]Rigidbody   selectedRigidbody;
    Camera          targetCamera;
    Vector3         originalScreenTargetPosition;
    Vector3         originalRigidbodyPos;
    float           selectionDistance;
    public float    rayDist;

    [SerializeField] private LayerMask layer;


    void Start()
    {
        targetCamera = GetComponent<Camera>();
        rayDist = 50f;

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
            selectedRigidbody.transform.Rotate(new Vector3(0,5,0));
        }

        if (Input.GetKey(KeyCode.X) && selectedRigidbody)
        {
            selectedRigidbody.transform.position = new Vector3 (0,8.02f,0);
            selectedRigidbody.velocity = Vector3.zero;
            selectedRigidbody = null;
        }

        if (Input.GetKey(KeyCode.Q) && selectedRigidbody)
        {
            selectedRigidbody.transform.Rotate(new Vector3(0, -5, 0));
        }

        if (Input.GetKey(KeyCode.Z) && selectedRigidbody)
        {
            selectedRigidbody.transform.Rotate(new Vector3(-5, 0, 0));
        }

        if (Input.GetKey(KeyCode.C) && selectedRigidbody)
        {
            selectedRigidbody.transform.Rotate(new Vector3(5,0, 0));
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
                selectionDistance -= 10f * Time.deltaTime;

            if (Input.GetMouseButton(4))
                selectionDistance += 10f * Time.deltaTime;

            Vector3 mousePositionOffset = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance)) - originalScreenTargetPosition;

            Vector3 newPos = originalRigidbodyPos + mousePositionOffset;

           
            selectedRigidbody.velocity = (newPos - selectedRigidbody.transform.position) * forceAmount * Time.deltaTime;
            
            if (selectedRigidbody.gameObject.name == "Dice" && Input.GetKey(KeyCode.R))
            {
                Debug.Log("Yes");
                selectedRigidbody.angularVelocity += new Vector3(1,1,1)*5000*Time.deltaTime;
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