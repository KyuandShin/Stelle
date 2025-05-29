using UnityEngine;

public class RangedWeaponBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Camera  mainCamera;
    public LayerMask pickableLayers;
    public float maxRayDistance = 100f;
    public float yPlane = 0f;
    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        // Optional: Set some defaults for appearance
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3? pointer = getMousePointerOnXZ();
        if (pointer!= null)
        {
            Vector3 existingPointer = (Vector3) pointer;
            existingPointer = new Vector3(existingPointer.x, transform.position.y, existingPointer.z);
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, existingPointer);
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    Vector3? getMousePointerOnXZ()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0f, yPlane, 0f));
        float enter;
        if (groundPlane.Raycast(ray, out enter))
        {
            return ray.GetPoint(enter);
        }
        else
        {
            return null;
        }
        
    }


    Vector3? getMousePointerOnObject()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxRayDistance, pickableLayers))
        {
            return hit.point;
        }
        else
        {
            return null;
         }


    }
}
