using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("SetDoorOpen", true);
        
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
    }
}
