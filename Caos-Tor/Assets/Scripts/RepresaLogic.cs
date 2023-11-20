using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Tilemaps;

public class RepresaLogic : MonoBehaviour
{
    private bool playerInTheArea = false;

    public int numberOfTreesNedeed;

    public TextMeshProUGUI numberText;
    private SpriteRenderer spriteRenderer;

    // Valor de opacidad deseado (entre 0 y 1)
    public float targetAlpha = 1f;

    // Tiempo en segundos para la transición de opacidad
    public float transitionTime = 1.0f;

    public GameObject riverToDisable;
    public GameObject riverToEnable;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        numberText.text = numberOfTreesNedeed.ToString();
        riverToEnable.SetActive(false);
    }

    private void Update()
    {
        if (numberOfTreesNedeed == 0)
        {
            ChangeOpacitySmooth();
            numberText.enabled = false;
            riverToDisable.SetActive(false);
            riverToEnable.SetActive(true);
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && playerInTheArea && GameManager.instance.ramasCount > 0)
        {
            RamaColection();
        }
    }

    void ChangeOpacitySmooth()
    {
        // Calcula el valor de alfa actual
        float currentAlpha = spriteRenderer.color.a;

        // Calcula el nuevo valor de alfa mediante una transición suave
        float newAlpha = Mathf.Lerp(currentAlpha, targetAlpha, Time.deltaTime / transitionTime);

        // Establece el nuevo color con el alfa actualizado
        Color newColor = spriteRenderer.color;
        newColor.a = newAlpha;
        spriteRenderer.color = newColor;
    }


    void RamaColection()
    {
        GameManager.instance.ramasCount -= 1;
        numberOfTreesNedeed--;
        numberText.text = numberOfTreesNedeed.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.CompareTag("Player"))
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
