using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractZone : MonoBehaviour
{
    private InteractableElement interactableElement;

    [SerializeField] private Texture2D cursorHax;
    [SerializeField] private Texture2D cursorNormal;

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
            ChangeCursor(cursorHax);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactableElement.enabled = true;
            ChangeCursor(cursorNormal);
        }
    }

    void ChangeCursor(Texture2D cursorTexture)
    {
        // Cambia la textura del cursor
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

}
