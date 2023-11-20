using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    private int rightClickCount = 0;
    public int rightClicksToDisappear;

    public GameObject player;

    public GameObject rama;
    public GameObject rioCorriendo;

    public AudioSource audioSource;
    public AudioClip audioClip;


    private void Start()
    {
        rama.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        if (rioCorriendo == null)
        {
            return;
        }
        else
        {
            rioCorriendo.SetActive(false);

        }

        audioSource.clip = audioClip;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Incrementa el contador de clics derecho
            rightClickCount++;

            player.GetComponent<Animator>().SetTrigger("Chop");
            audioSource.PlayOneShot(audioClip);

            if (rightClickCount >= rightClicksToDisappear)
            {
                gameObject.SetActive(false);
                rama.SetActive(true);
                if (rioCorriendo == null)
                {
                    return;
                }
                else
                {
                    rioCorriendo.SetActive(true);
                }
            }
        }

        
    }
}
