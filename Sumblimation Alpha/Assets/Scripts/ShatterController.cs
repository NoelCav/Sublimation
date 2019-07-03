using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterController : MonoBehaviour
{
    public float shatterForce = 10f;
    public GameObject shatterPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if (collision.relativeVelocity.magnitude > shatterForce && gameObject != null)
        {
            for (int i = 0; i < 100; i++)
            {
                Rigidbody debrisInstance = Instantiate(shatterPrefab.GetComponent<Rigidbody>(), gameObject.transform.position, gameObject.transform.rotation);
            }

            Destroy(gameObject);

        }
    }
}
