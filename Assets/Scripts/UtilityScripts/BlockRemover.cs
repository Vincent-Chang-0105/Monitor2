using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRemover : MonoBehaviour
{
    public GameObject Block;
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
            Block.SetActive(false);
        }
    }
}
