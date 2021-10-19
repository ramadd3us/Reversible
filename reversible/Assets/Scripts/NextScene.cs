using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public static int lvl = 0;

    private void OnTriggerEnter(Collider other)
    {
        lvl++;
        SceneManager.LoadScene(lvl);
    }
}
