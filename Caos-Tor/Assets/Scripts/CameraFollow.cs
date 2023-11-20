using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objeto que la c�mara seguir�
    public float smoothSpeed = 0.125f; // Velocidad de la interpolaci�n suave
    public Vector2 minBounds; // L�mite inferior de la c�mara
    public Vector2 maxBounds; // L�mite superior de la c�mara

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posici�n deseada de la c�mara
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Limita la posici�n de la c�mara a los l�mites definidos
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

            // Utiliza Lerp para mover suavemente la c�mara hacia la posici�n deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Establece la posici�n de la c�mara
            transform.position = smoothedPosition;
        }
    }
}
