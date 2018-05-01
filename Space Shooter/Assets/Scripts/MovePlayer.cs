using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class MovePlayer : MonoBehaviour {

    private Rigidbody rb;
    private float nextShot;

    public Boundary boundary;
    public float speed;
    public float fireRate;
    public GameObject shot;
    public Transform shotStart;

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3 (moveX, 0.0f, moveY) * speed;
        
        rb.position = new Vector3
            (
                Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextShot) {
            nextShot = Time.time + fireRate;
            Instantiate(shot, shotStart.position, shotStart.rotation);
        }
    }
}
