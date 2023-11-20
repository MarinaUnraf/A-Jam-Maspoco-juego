using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    void Start()
    {
        // Este objeto persistirá a través de las escenas
        DontDestroyOnLoad(gameObject);
    }
}
