using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
    public void CargarEscena(string name)
    {
        SceneManager.LoadScene(name);
    }
}
