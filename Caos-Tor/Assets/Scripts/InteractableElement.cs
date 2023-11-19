using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    private int rightClickCount = 0;
    public int rightClicksToDisappear;

    public GameObject player;

    public GameObject rama;

    private void Start()
    {
        rama.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Incrementa el contador de clics derecho
            rightClickCount++;

            player.GetComponent<Animator>().SetTrigger("Chop");


            if (rightClickCount >= rightClicksToDisappear)
            {

                gameObject.SetActive(false);
                rama.SetActive(true);


            }
        }
    }
}
