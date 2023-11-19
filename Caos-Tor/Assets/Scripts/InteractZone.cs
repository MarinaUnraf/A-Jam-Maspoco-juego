using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractZone : MonoBehaviour
{
    private InteractableElement interactableElement;

    private void Start()
    {
        interactableElement = GetComponentInParent<InteractableElement>();
        interactableElement.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            interactableElement.enabled = true;
        }
    }
}
