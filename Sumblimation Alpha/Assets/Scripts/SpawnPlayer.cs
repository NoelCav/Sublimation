using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerCam, null, true);
        Instantiate(player, transform.position, transform.rotation);  
    }

    // Update is called once per frame
    void Update()
    {

    }
}
