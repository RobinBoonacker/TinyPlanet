using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class GravityBody : MonoBehaviour {

    public bool fixRotation = true;

    GravityAttractor planet;

	void Awake () {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
        GetComponent<Rigidbody>().useGravity = false;
        if (fixRotation)
        {
            GetComponent<Rigidbody>().constraints = GetComponent<Rigidbody>().constraints | RigidbodyConstraints.FreezeRotation;
        }
    }

    void FixedUpdate ()
    {
        planet.Attract(transform, fixRotation);
    }
}
