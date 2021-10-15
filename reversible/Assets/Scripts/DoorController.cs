using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private void Start()
    {
        anim.SetBool("SetDoorOpen", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("SetDoorOpen", false);
        anim.SetBool("SetDoorClose", true);
    }
}
