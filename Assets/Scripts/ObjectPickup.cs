using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public float forceAmount = 10f;

    [SerializeField]Rigidbody   selectedRigidbody;
    Camera      targetCamera;
    Vector3     originalScreenTargetPosition;
    Vector3     originalRigidbodyPos;
    float       selectionDistance;
    public bool cardPicked;
    public float rayDist;
    [SerializeField] private LayerMask layer;
    // Start is called before the first frame update
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
            //Check if we are hovering over Rigidbody, if so, select it
            selectedRigidbody = GetRigidbodyFromMouseClick();
        }
        if (Input.GetMouseButtonUp(0) && selectedRigidbody)
        {
            //Release selected Rigidbody if there any
            selectedRigidbody = null;
        }

        if (Input.GetKey(KeyCode.E) && selectedRigidbody )
        {
            selectedRigidbody.transform.Rotate(new Vector3(0,5,0));
        }

        if (Input.GetKey(KeyCode.Z) && selectedRigidbody)
        {
            selectedRigidbody.transform.position = new Vector3 (0,12,0);
          
        }

        if (Input.GetKey(KeyCode.Q) && selectedRigidbody)
        {
            selectedRigidbody.transform.Rotate(new Vector3(0, -5, 0));
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
            Vector3 mousePositionOffset = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance)) - originalScreenTargetPosition;
            selectedRigidbody.velocity = (originalRigidbodyPos + mousePositionOffset - selectedRigidbody.transform.position) * forceAmount * Time.deltaTime;
            if (selectedRigidbody.gameObject.name == "Dice" && Input.GetKey(KeyCode.R))
            {
                Debug.Log("Yes");
                selectedRigidbody.AddTorque(new Vector3(1,1,1) * 1000000f* Time.deltaTime);
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