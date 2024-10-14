using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    [SerializeField] private Transform objectToMove;
    [SerializeField] private Vector3 movementDirection = Vector3.right;
    [SerializeField] private float moveDistance = 1.0f;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private GameObject blocker;

    [SerializeField] private GameObject interactionPrefab; // Prefab for the interaction icon
    [SerializeField] private Vector3 prefabOffset = new Vector3(2.0f, 1.5f, 0);

    private GameObject spawnedIcon;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Start()
    {
        targetPosition = objectToMove.position + (movementDirection.normalized * moveDistance);
    }

    // Show the interaction icon
    public void ShowInteractionIcon()
    {
        if (spawnedIcon == null)
        {
            spawnedIcon = Instantiate(interactionPrefab, transform.position + prefabOffset, Quaternion.identity);
        }
    }

    // Hide the interaction icon
    public void HideInteractionIcon()
    {
        if (spawnedIcon != null)
        {
            Destroy(spawnedIcon);
        }
    }

    // Pull the lever and move the object
    public void PullLever()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveObject());
        }

        if (blocker != null)
        {
            blocker.SetActive(false); // Disable blocker when lever is pulled
        }

        // Destroy interaction icon after interaction
        HideInteractionIcon();
    }

    private IEnumerator MoveObject()
    {
        isMoving = true;
        while (Vector3.Distance(objectToMove.position, targetPosition) > 0.01f)
        {
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        objectToMove.position = targetPosition;
        isMoving = false;
    }
}
