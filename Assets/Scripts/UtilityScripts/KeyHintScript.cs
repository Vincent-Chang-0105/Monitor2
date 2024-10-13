using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHintScript : MonoBehaviour
{
    public CanvasGroup hintObject;  // Reference to the CanvasGroup for fading
    public float fadeDuration = 2.0f;  // Duration for the fade-out

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideHintAfterDelay()); // Start the hiding process
    }

    // Coroutine that waits 5 seconds then fades the object
    IEnumerator HideHintAfterDelay()
    {
        yield return new WaitForSeconds(5f);  // Wait for 5 seconds
        StartCoroutine(FadeOutHint());  // Start fading the object
    }

    // Coroutine to smoothly fade out the CanvasGroup alpha
    IEnumerator FadeOutHint()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            hintObject.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;  // Wait for the next frame
        }

        // Ensure the object is completely faded out
        hintObject.alpha = 0f;
    }
}
