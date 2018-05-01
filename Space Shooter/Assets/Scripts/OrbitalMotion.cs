using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalMotion : MonoBehaviour {
    
    //public variables
    public float rotate;

    //private variables
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * rotate;
    }
}
