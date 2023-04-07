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

    public GameManager gm;

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

        if(isGrappling)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
                _lineRenderer.SetPosition(0, mousePos);
                _distanceJoint.connectedAnchor = mousePos;
                _distanceJoint.enabled = false;
                linePosition.position = mousePos;

                Vector3 Direction = linePosition.position - transform.position;

                rb.velocity = new Vector2(Direction.x * force, Direction.y * force).normalized * force * Time.deltaTime;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "coin")
        {
            gm.coin += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "door")
        {
            Debug.Log("sonraki bolume gecildi.");
            gm.durum.text = ("Sonraki bolume gecildi.");
        }

        if (collision.gameObject.tag == "acid")
        {
            Time.timeScale = 0;
            Debug.Log("oldun.");
            gm.durum.text = ("Oldunuz.");
        }
    }
}