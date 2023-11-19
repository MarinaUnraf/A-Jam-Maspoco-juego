using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1)) // Clic derecho
        {
            CollectRama();
        }
    }

    void CollectRama()
    {
        Destroy(gameObject);

        GameManager.instance.IncreaseRamasCount();
    }
}
