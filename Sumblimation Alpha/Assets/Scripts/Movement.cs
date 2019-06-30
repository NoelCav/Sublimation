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

        Vector3 force = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        force.Normalize();
        force = camRot * force * maxForce;
        force = new Vector3(force.x, 0, force.z);

        if (IsGrounded())
        {
            force *= maxForce;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid.AddForce(new Vector3(0, jumpHeight, 0));
                Vector3 torqueV = new Vector3(Input.GetAxis("Vertical") * torque, 0, Input.GetAxis("Horizontal") * -torque);
                torqueV = camRot * torqueV;
                rigid.AddTorque(torqueV);
            }

        }


        rigid.AddForce(force, ForceMode.Force);
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}