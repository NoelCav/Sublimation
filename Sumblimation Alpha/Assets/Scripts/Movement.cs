using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float maxForce = 20.0f;
    public float jumpHeight = 4000.0f;
    public float torque = 500f;
    private float distToGround;
    private Rigidbody rigid;
    public GameObject playerCam;
    public bool canJump = true;


    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion camRot = playerCam.transform.GetComponent<Transform>().rotation;

        Vector3 forceV = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Normalize the force vector to prevent diagonal movement speed increase exploit
        forceV.Normalize();
        //Add a force to the player depending on where the camera is pointing (local, not global)
        forceV = camRot * forceV * (IsGrounded() ? maxForce : maxForce/3);
        forceV = new Vector3(forceV.x, 0, forceV.z);

        if (Input.GetKey(KeyCode.Space) && IsGrounded() && canJump)
        {
            canJump = false;
            //Make the player jump by applying an upward force of jumpHeight
            rigid.AddForce(new Vector3(0, jumpHeight, 0));
            //Apply torque based on the input axes so that the player rotates when jumping
            Vector3 torqueV = new Vector3(Input.GetAxis("Vertical") * torque, 0, Input.GetAxis("Horizontal") * -torque);
            //Make the rotation relative to the camera, not the world
            torqueV = camRot * torqueV;
            rigid.AddTorque(torqueV);
        }
        
        //Allows the player to jump again when the space key is released. Had problems with GetKeyDown and GetKeyUp.
        if (!Input.GetKey(KeyCode.Space))
        {
            canJump = true;
        }

        //Finally add our force vector to the player
        rigid.AddForce(forceV, ForceMode.Force);
    }

    //Returns a boolean, true for if we are grounded, false otherwise
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.001f);
    }
}