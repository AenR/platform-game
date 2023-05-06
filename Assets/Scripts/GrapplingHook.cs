using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public Rigidbody2D rb;
    public float force;
    private Vector3 mouseDir;
    public Transform linePosition;
    public bool isGrappling;


    void Start()
    {
        isGrappling = true;
        _distanceJoint.autoConfigureDistance = true;
        _distanceJoint.enabled = false;
        _lineRenderer.enabled = false;
    }

    void Update()
    {
        mouseDir = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

      

        if (isGrappling) 
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
                _lineRenderer.SetPosition(0, mousePos);
                _distanceJoint.connectedAnchor = mousePos;
                _distanceJoint.enabled = true;
                linePosition.position = mousePos;
            }
            if (Input.GetMouseButton(0))
            {
                _lineRenderer.SetPosition(1, transform.position);
                _lineRenderer.enabled = true;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                _distanceJoint.enabled = false;
                _lineRenderer.enabled = false;
            }
            if (_distanceJoint.enabled)
            {
                _lineRenderer.SetPosition(1, transform.position);
            }

        }
    }
}
