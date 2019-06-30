using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject target = null;
    public float distance = 5f;
    public float height = 2.5f;
    private Transform player;
    private Vector3 offset;

    // Use this for initialization
    void Start() {
        player = target.GetComponent<Transform>();
        offset = new Vector3(player.position.x, player.position.y + height, player.position.z + distance);
    }
	
	// Update is called once per frame
	void Update () {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X"), Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);

    }
        
        //this.transform.rotation = new Quaternion(-normalizedV.x, this.transform.rotation.y, -normalizedV.z, 0);
}
