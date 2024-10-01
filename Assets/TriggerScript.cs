using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cubea;
    // public CubePath cube;
    public int Q;

    void Start()
    {
        Q = 2;
        cubea.GetComponent<CubePath>().enabled = false;
    }

    private void Update()
    {

    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Q) == true)
            {
                cubea.GetComponent<CubePath>().enabled = true;
                Q = Q + 1;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }
}
