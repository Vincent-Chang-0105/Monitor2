using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPull : MonoBehaviour
{
    [SerializeField] private float interactDist = 0.6f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, transform.forward, out var hit, interactDist))
        {
            // Look for ButtonTrigger component
            if (hit.collider.gameObject.TryGetComponent(out LeverTrigger leverPull))
            {
                leverPull.PullLever();
            }
        }
    }
}
