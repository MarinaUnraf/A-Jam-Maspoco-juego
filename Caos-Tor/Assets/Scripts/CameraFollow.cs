using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objeto que la cámara seguirá
    public float smoothSpeed = 0.125f; // Velocidad de la interpolación suave
    public Vector2 minBounds; // Límite inferior de la cámara
    public Vector2 maxBounds; // Límite superior de la cámara

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posición deseada de la cámara
            Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Limita la posición de la cámara a los límites definidos
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

            // Utiliza Lerp para mover suavemente la cámara hacia la posición deseada
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Establece la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}
