using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private Transform[] walkingPoints;

    private int currentWaypoint;
    private bool isWaiting;
    private Animator animator;

    public float detectionRadius = 5f;
    public LayerMask playerLayer;
    public LayerMask obstaclesLayer;

    [SerializeField] private GameObject canvasLose;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("Walking", !isWaiting);

        if(transform.position != walkingPoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, walkingPoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else if(!isWaiting)
        {
            StartCoroutine(Wait());
        }

        DetectPlayer();
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;

        if(currentWaypoint == walkingPoints.Length)
        {
            currentWaypoint = 0;
        }
        isWaiting = false;
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja el círculo de detección en el escenario cuando el objeto está seleccionado
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    void DetectPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            return;
        }

        Vector2 playerPosition = player.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerPosition - (Vector2)transform.position, detectionRadius, obstaclesLayer);

        Debug.DrawRay(transform.position, (playerPosition - (Vector2)transform.position).normalized * detectionRadius, Color.blue);

        if (Vector2.Distance(transform.position, playerPosition) <= detectionRadius && (hit.collider == null || hit.collider.CompareTag("Player")))
        {
            speed = 0;
            player.GetComponent<PlayerMovement>().maxSpeed = 0;
            player.GetComponent<Animator>().SetTrigger("Death");
            player.GetComponent<PlayerMovement>().enabled = false;
            Invoke("ShowCanvas", .6f);
        }
    }

    private void ShowCanvas()
    {
        canvasLose.SetActive(true);
    }
}
