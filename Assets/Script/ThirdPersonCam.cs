using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public float rotationSpeed;
    public Transform combatLook;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void FixedUpdate()
    {
        // Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        // orientation.forward = viewDir.normalized;

        // float horizontalInput = Input.GetAxis("Horizontal");
        // float verticalInput = Input.GetAxis("Vertical");
        // Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // if(inputDir != Vector3.zero)
        // {
        //     playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.fixedDeltaTime * rotationSpeed);

        // }
        Vector3 dirToCombat = combatLook.position - new Vector3(transform.position.x, combatLook.position.y, transform.position.z);
        orientation.forward = dirToCombat.normalized;
        playerObj.forward = Vector3.Slerp(playerObj.forward, dirToCombat.normalized, Time.fixedDeltaTime * rotationSpeed);
        //playerObj.forward = dirToCombat.normalized;       
    }
}
