using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    [SerializeField] private Transform objectToMove; 
    [SerializeField] private Vector3 movementDirection = Vector3.right;
    [SerializeField] private float moveDistance = 1.0f; 
    [SerializeField] private float moveSpeed = 2.0f; 

    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Start()
    {
        targetPosition = objectToMove.position + (movementDirection.normalized * moveDistance);
    }

    public void PullLever()
    {
        if (!isMoving)
        {
            StartCoroutine(MoveObject());
        }
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

    private void OnGUI()
    {
        GUILayout.Box("Press 'E' to move the object.");
    }
}
