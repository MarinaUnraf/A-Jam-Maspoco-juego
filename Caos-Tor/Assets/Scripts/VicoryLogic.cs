using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VicoryLogic : MonoBehaviour
{
    public GameObject canvasVictory;

    public GameObject ultTramoDeRio;

    private EnemyBehaviour enemyBehaviour;
    // Start is called before the first frame update
    void Start()
    {
        canvasVictory.SetActive(false);

        enemyBehaviour = FindObjectOfType<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ultTramoDeRio.activeSelf) 
        {
            StartCoroutine(ShowCanvas());
            enemyBehaviour.speed = 0;
        }
    }

    IEnumerator ShowCanvas()
    {
        yield return new WaitForSeconds(1.5f);
        canvasVictory.SetActive(true);
    }
}
