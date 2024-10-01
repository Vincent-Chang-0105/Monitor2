using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    private RespawnScript respawn;
    private BoxCollider checkpointCollider;

    private void Awake()
    {
        checkpointCollider = GetComponent<BoxCollider>();
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            respawn.respawnPoint = this.gameObject;
            GetComponent<Collider>().enabled = false;
        }
    }
}