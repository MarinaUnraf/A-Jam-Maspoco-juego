using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    void Start()
    {
        // Este objeto persistir� a trav�s de las escenas
        DontDestroyOnLoad(gameObject);
    }
}
