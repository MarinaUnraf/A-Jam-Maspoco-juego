using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int ramasCount = 0;

    public TextMeshProUGUI numberText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseRamasCount()
    {
        ramasCount++;
        Debug.Log("Ramas recolectadas: " + ramasCount);

        numberText.text = ramasCount.ToString();
    }
}
