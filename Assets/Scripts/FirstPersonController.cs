using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

    public float mouseSensitivityX = 25f;
    public float mouseSensitivityY = 25f;
    public float walkSpeed = 8f;
    public float runSpeed = 14f;
    public float jumpForce = 220f;
    public LayerMask groundMask;

    Transform cameraTransform;
    float verticalLookRotation;

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    bool onGround;
    bool running;

    void Start () {
        cameraTransform = Camera.main.transform;
    }
	
	void Update () {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
        verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
        cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;

        // Calculations to perform in the FixedUpdate method.
        Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        float moveSpeed = running ? runSpeed : walkSpeed;
        Vector3 targetMoveAmount = moveDir * moveSpeed;
        moveAmount = Vector3.SmoothDamp(targetMoveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

        // Jumping
        if (Input.GetButtonDown("Jump") && onGround)
        {
            Rigidbody rBody = GetComponent<Rigidbody>();
            rBody.AddForce(transform.up * jumpForce);
        }

        // Running
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            running = true;
        } else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            running = false;
        }

        // Checking if the player is on the ground (touching the planet or something o the Surface layer)
        onGround = false;
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1.5f, groundMask))
        {
            onGround = true;
        }
    }

    private void FixedUpdate ()
    {
        Rigidbody rBody = GetComponent<Rigidbody>();
        rBody.MovePosition(rBody.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
