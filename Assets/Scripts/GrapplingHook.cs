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

    public float speed;

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
            rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
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
            gm.durum.text = ("Sonraki bolume gecildi.");
        }

        if (collision.gameObject.tag == "acid")
        {
            Time.timeScale = 0;
            gm.durum.text = ("Oldunuz.");
        }

        if (collision.gameObject.tag == "key")
        {
            gm.key++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "keydoor")
        {
            if(gm.key>0)
            {
                gm.key--;
                gm.durum.text = ("Kapi acildi.");
            }
        }
    }
}
