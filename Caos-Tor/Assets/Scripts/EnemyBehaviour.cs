using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private Transform[] walkingPoints;

    private int currentWaypoint;
    private bool isWaiting;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(transform.position != walkingPoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, walkingPoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else if(!isWaiting)
        {
            StartCoroutine(Wait());
        }
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
}
