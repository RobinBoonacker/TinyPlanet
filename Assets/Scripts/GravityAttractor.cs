using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour {

    public float gravity = 10;

	public void Attract (Transform body, bool fixRotation)
    {
        Vector3 targetDir = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;

        if (fixRotation)
        {
            body.rotation = Quaternion.FromToRotation(body.up, targetDir) * body.rotation;
        }
        body.GetComponent<Rigidbody>().AddForce(targetDir * -gravity);
    }
}
