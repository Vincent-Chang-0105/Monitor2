using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPull : MonoBehaviour
{
    [SerializeField] private float interactDist = 0.6f;

    private LeverTrigger currentLeverTrigger;

    private void Update()
    {
        // Perform a raycast to check if we are within interaction distance
        if (Physics.Raycast(transform.position, transform.forward, out var hit, interactDist))
        {
            // Look for LeverTrigger component
            if (hit.collider.gameObject.TryGetComponent(out LeverTrigger leverTrigger))
            {
                // Show interaction prefab if we're in range
                leverTrigger.ShowInteractionIcon();

                // Check for player input
                if (Input.GetKeyDown(KeyCode.E))
                {
                    leverTrigger.PullLever();
                }

                currentLeverTrigger = leverTrigger;
            }
        }
        else if (currentLeverTrigger != null)
        {
            // Hide the interaction icon if the player moves out of range
            currentLeverTrigger.HideInteractionIcon();
            currentLeverTrigger = null;
        }
    }
}
