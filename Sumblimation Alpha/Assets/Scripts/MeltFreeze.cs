using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltFreeze : MonoBehaviour {
    public float size = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.localScale.magnitude > 0.2) {
            this.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f) / (Time.deltaTime * 100000);
        }
    }
}
