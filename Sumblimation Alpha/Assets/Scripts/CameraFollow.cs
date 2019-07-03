using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {  
    public float distance = 5f;
    public float height = 2.5f;

    private GameObject target;
    private Transform player;
    private Vector3 offset;

    // Use this for initialization
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
        player = target.GetComponent<Transform>();
        offset = new Vector3(player.position.x, player.position.y + height, player.position.z + distance);
    }
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X"), Vector3.up) * offset;
            transform.position = player.position + offset;
            transform.LookAt(player.position);
        }
    }
}
