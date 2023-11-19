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

    private Animator animator;
    private float lastPositionX;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

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
            animator.SetBool("Walk", true);
        }
        else if(!isMoving)
        {
            animator.SetBool("Walk", false);
            lastPositionX = transform.position.x;
        }
        
        
        
        if(transform.position.x > lastPositionX)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if(transform.position.x < lastPositionX)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    void MoveTo(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, obstacleLayer);

        if (hit.collider != null && hit.collider.tag == "Obstacle")
        {
            isMoving = false;
            return;
        }

        Debug.DrawRay(transform.position, direction * raycastDistance, Color.red);

        float currentSpeed = Mathf.Min(maxSpeed, Vector3.Distance(transform.position, target) * smoothing);
        transform.position += direction * currentSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            isMoving = false;
        }
    }
}
