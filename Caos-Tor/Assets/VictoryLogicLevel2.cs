using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryLogicLevel2 : MonoBehaviour
{
    public GameObject montanita1;
    public GameObject montanita2;
    public GameObject montanita3;

    public GameObject canvasVictory;

    private EnemyBehaviour enemyBehaviour;

    private PlayerMovement playerMovement;
    public GameObject musicVictory;

    public GameObject music;


    // Start is called before the first frame update
    void Start()
    {
        canvasVictory.SetActive(false);
        enemyBehaviour = FindObjectOfType<EnemyBehaviour>();

        playerMovement = FindObjectOfType<PlayerMovement>();
        playerMovement.enabled = true;
        musicVictory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(montanita1.GetComponent<RepresaLogic>().numberOfTreesNedeed <= 0
            && montanita2.GetComponent<RepresaLogic>().numberOfTreesNedeed <= 0 
            && montanita3.GetComponent<RepresaLogic>().numberOfTreesNedeed <= 0)
        {
            StartCoroutine(ShowCanvas());
            enemyBehaviour.speed = 0;
            playerMovement.enabled = false;
        }
    }

    IEnumerator ShowCanvas()
    {
        yield return new WaitForSeconds(1.5f);
        music.SetActive(false);
        canvasVictory.SetActive(true);
        musicVictory.SetActive(true);
    }
}
