using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHintScript : MonoBehaviour
{
    public GameObject hintObject;  // Reference to the game object to hide
    public Vector3 targetPosition; // Position to lerp to (should be left of the current position)
    public float moveDuration = 2.0f;  // Duration for the lerp movement

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideHintAfterDelay()); // Start the hiding process
    }

    // Coroutine that waits 5 seconds then hides the object
    IEnumerator HideHintAfterDelay()
    {
        yield return new WaitForSeconds(5f);  // Wait for 5 seconds
        StartCoroutine(LerpToLeft());  // Start lerping the object to the left
    }

    // Coroutine to smoothly move the GameObject to the left using Lerp
    IEnumerator LerpToLeft()
    {
        Vector3 startPosition = hintObject.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            hintObject.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;  // Wait for the next frame
        }

        // Ensure the object reaches the target position
        hintObject.transform.position = targetPosition;
    }
}
