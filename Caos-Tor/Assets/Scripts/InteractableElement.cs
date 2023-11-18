using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    private int rightClickCount = 0;
    public int rightClicksToDisappear = 3;

    void Update()
    {
        // Detecta clic derecho
        if (Input.GetMouseButtonDown(1))
        {
            // Incrementa el contador de clics derecho
            rightClickCount++;

            // Verifica si se han alcanzado suficientes clics derecho para hacer que el elemento desaparezca
            if (rightClickCount >= rightClicksToDisappear)
            {
                // Realiza la acción deseada (en este caso, desactiva el GameObject)
                gameObject.SetActive(false);

                // También puedes destruir el objeto si prefieres
                // Destroy(gameObject);
            }
        }
    }
}
