 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCharacterController : MonoBehaviour
{

    [SerializeField] private float walkSpeed = 9.0f;

    private float verticalInput = 0.0f;
    private float horizontalInput = 0.0f;
    private float MouseInputX = 0.0f;
    private float MouseInputY = 0.0f;

    private Rigidbody playerRb;

    [SerializeField] private Transform cameraTransform;

    private Vector3 playerVelocity = new Vector3();
    
    // Start called before the first frame update
    private void Start()
    {
        playerRb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        GetInputs();
        MoveCharacter();
        GetMouseInputs();
        RotateCharacter();
        RotateCamera();
    }


    private void GetInputs()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void GetMouseInputs()
    {
        MouseInputX = Input.GetAxis("Mouse X");
        MouseInputY = Input.GetAxis("Mouse Y");
    }
       
    private void MoveCharacter()
    {
        playerVelocity = new Vector3(x: horizontalInput, y: 0.0f, z: verticalInput);

        //playerRb.velocity = forward * new Vector3 (0, 0, 1) or new Vector3 (0, 0, -1)
        playerRb.velocity = this.transform.forward * verticalInput;

        //playerRb.velocity = right * new Vector3 (-1, 0, 1) or new Vector3 (1, 0, -1)
        playerRb.velocity = playerRb.velocity + this.transform.right * horizontalInput;
    }

    private void RotateCharacter()
    {
        this.transform.Rotate(xAngle: 0.0f, yAngle: MouseInputX, zAngle:0.0f);
    }

    private void RotateCamera()
    {
        //Limit the range the camera can pitch
        //Mouse movement sensitivity
        cameraTransform.Rotate(eulers: new Vector3(x:-MouseInputY, y:0.0f, z:0.0f));
    }


}
