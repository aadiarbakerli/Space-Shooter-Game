using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderMove : MonoBehaviour {

    //public variables
    public Vector2 startWait;
    public float dodge;
    public Vector2 movementTime;
    public Vector2 movementWait;
    public float smoothOut;
    public Boundary boundary;

    //private variables
    private float targetMove;
    private float currentSpeed;
    private Rigidbody rb;

    IEnumerator Evade() {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true) {
            targetMove = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(movementTime.x, movementTime.y));
            targetMove = 0;
            yield return new WaitForSeconds(Random.Range(movementWait.x, movementWait.y));
        }
    }

	void Start () {
        StartCoroutine(Evade());
        rb = GetComponent<Rigidbody>();
        currentSpeed = rb.velocity.z;
	}

    private void FixedUpdate()
    {
        float newMovement = Mathf.MoveTowards(rb.velocity.x, targetMove, Time.deltaTime * smoothOut);
        rb.velocity = new Vector3(newMovement, 0.0f, currentSpeed);
        rb.position = new Vector3(
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
            );
    }

    void Update () {
		
	}
}
