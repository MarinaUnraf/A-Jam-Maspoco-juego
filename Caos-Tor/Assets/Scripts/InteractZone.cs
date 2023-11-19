using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractZone : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour m_EnemyBehaviour;
    [SerializeField] private GameObject canvasLose;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("jugador detectado!");
            m_EnemyBehaviour.enabled = false;
            collision.gameObject.SetActive(false);
            Invoke("ShowCanvas", .6f);
        }
    }

    private void ShowCanvas()
    {
        canvasLose.SetActive(true);
    }
}
