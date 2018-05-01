using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvaderControl : MonoBehaviour {

    //public viarables
    public GameObject shot;
    public Transform shotStart;
    public float fireRate;
    public float delay;
    
    //private viarables

    private void Start()
    {
        InvokeRepeating("Shoot", delay, fireRate);
    }

    void Shoot() {
        Instantiate(shot, shotStart.position, shotStart.rotation);
    }
}
