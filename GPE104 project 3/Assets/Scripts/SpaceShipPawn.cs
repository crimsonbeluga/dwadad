using UnityEngine;

public class SpaceShipPawn : MonoBehaviour
{
    public Rigidbody rb;
    private Camera cam;

    [Header("Movement Settings")]
    public float thrust = 1.0f;
    public float drag = 2.0f;
    public float angularDrag = 5.0f;
    public float rollSpeed = 1.0f;

    [Header("Zoom Settings")]
    [Range(10, 100)] // Restricts the range in the editor for FOV zoom
    public float zoomLevel = 60f; // Default FOV value
    public float zoomSpeed = 5f; // Speed of zooming in/out

    private float defaultDrag;
    private float defaultAngularDrag;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();  // Assuming the camera is a child of the spaceship
        defaultDrag = rb.drag;
        defaultAngularDrag = rb.angularDrag;
        cam.fieldOfView = zoomLevel;  // Set initial FOV
    }

    void Update()
    {
        HandleZoom();
    }

    public void MoveForward()
    {
        rb.AddForce(transform.forward * thrust, ForceMode.Force);
    }

    public void ApplyDrag()
    {
        rb.drag = drag;
        rb.angularDrag = angularDrag;
    }

    public void ResetDrag()
    {
        rb.drag = defaultDrag;
        rb.angularDrag = defaultAngularDrag;
    }

    public void RotateShip(Vector2 mousePosition, float sensitivity, float clampAngle)
    {
        Vector2 mouseDelta = mousePosition - new Vector2(Screen.width / 2, Screen.height / 2);
        float mouseX = mouseDelta.x * sensitivity * Time.deltaTime;
        float mouseY = -mouseDelta.y * sensitivity * Time.deltaTime;

        float xRotation = Mathf.Clamp(mouseY, -clampAngle, clampAngle);
        float yRotation = mouseX;

        transform.Rotate(Vector3.up, yRotation, Space.Self);
        transform.Rotate(Vector3.right, xRotation, Space.Self);
    }

    public void HandleRollLeft()
    {
        transform.rotation *= Quaternion.Euler(0, 0, rollSpeed * Time.deltaTime);
    }

    public void HandleRollRight()
    {
        transform.rotation *= Quaternion.Euler(0, 0, -rollSpeed * Time.deltaTime);
    }
    private void HandleZoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        zoomLevel -= scrollInput * zoomSpeed;
        zoomLevel = Mathf.Clamp(zoomLevel, 10f, 100f); // Keep FOV within limits
        cam.fieldOfView = zoomLevel; // Apply the zoom
    }
}

