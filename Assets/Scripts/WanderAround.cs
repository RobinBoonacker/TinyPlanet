using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAround : MonoBehaviour {

    public float speed;
    public float rotation;
    public float maxRotation;

    float rotationCurrent;
    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    void Update () {

        rotationCurrent += Random.Range(-rotation, rotation);
        rotationCurrent = Mathf.Clamp(rotationCurrent, -maxRotation, maxRotation);
        transform.Rotate(Vector3.up, rotationCurrent);

        Vector3 moveDir = new Vector3(1, 0, 0).normalized;
        Vector3 targetMoveAmount = moveDir * speed;
        moveAmount = Vector3.SmoothDamp(targetMoveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);
    }

    private void FixedUpdate()
    {
        Rigidbody rBody = GetComponent<Rigidbody>();
        rBody.MovePosition(rBody.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
