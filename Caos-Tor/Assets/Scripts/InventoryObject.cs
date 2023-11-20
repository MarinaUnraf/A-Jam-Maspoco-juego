using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    private bool playerInTheArea = false;
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && playerInTheArea)
        {
            CollectRama();
        }
    }

    void CollectRama()
    {
        Destroy(gameObject);

        GameManager.instance.IncreaseRamasCount();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInTheArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInTheArea = false;
        }
    }
}
