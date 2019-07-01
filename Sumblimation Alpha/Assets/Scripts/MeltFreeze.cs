using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltFreeze : MonoBehaviour {
    public float meltSpeed = 10f;
    public float density = 10f;
    public float minMass = 8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        shrink();
        changeMass();
    }

    //Code for shrinking the player
    void shrink ()
    {
        //Set a lower bound on the size of the player (exceeding this bound with kill him later)
        if (this.transform.localScale.magnitude > 0.2)
        {
            //Shrink the player (frame rate independent shrink rate (hopefully!))
            this.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f) * meltSpeed * Time.deltaTime;

        }
    }

    //Calculate and set the mass of the player based on its size and density
    void changeMass ()
    {
        if (GetComponent<Rigidbody>().mass > minMass)
        {
            this.GetComponent<Rigidbody>().mass = transform.localScale.x * transform.localScale.y * transform.localScale.z * density;
        }
    }
}
