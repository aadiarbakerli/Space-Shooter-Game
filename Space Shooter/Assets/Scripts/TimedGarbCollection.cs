using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedGarbCollection : MonoBehaviour {

    //public variables
    public float lifeSpan;

    private void Start()
    {
        Destroy(gameObject, lifeSpan);
    }
}
