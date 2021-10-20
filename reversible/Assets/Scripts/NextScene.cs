using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private static int lvlLimit = 5;
    private static int _lvl = 0;
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("TimeController").GetComponent<TimeCounter>().Reset();
        _lvl++;
        if(_lvl < lvlLimit)
            SceneManager.LoadScene(_lvl);
        if (_lvl == lvlLimit)
            SceneManager.LoadScene(lvlLimit);
    }
}
