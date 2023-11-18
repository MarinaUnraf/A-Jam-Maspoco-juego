using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float smoothing = 5f;

    public float raycastDistance = 0.5f;
    public LayerMask obstacleLayer; // Capa que representa los obstáculos

    public bool isMoving = false;
    private Vector3 targetPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;
            isMoving = true;
        }

        if (isMoving)
        {
            MoveTo(targetPosition);
        }
    }

    void MoveTo(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;

        // Realiza un Raycast en la dirección de movimiento
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, obstacleLayer);

        // Si el Raycast golpea un objeto, detiene el movimiento
        if (hit.collider != null && hit.collider.tag == "Obstacle")
        {
            isMoving = false;
            return;
        }

        // Visualiza el Raycast
        Debug.DrawRay(transform.position, direction * raycastDistance, Color.red);

        float currentSpeed = Mathf.Min(maxSpeed, Vector3.Distance(transform.position, target) * smoothing);
        transform.position += direction * currentSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            isMoving = false;
        }
    }
}
