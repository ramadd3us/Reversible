using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private float LastTime;
    private int Counter = 0;

    private void Start()
    {
        
        
        anim.SetBool("SetDoorOpen", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Counter == 0)
        {
            LastTime = TimeCounter.RewindTimer;
            CloseTheDoor();
            Counter++;
        }
        
       
    }

    private void FixedUpdate()
    {
        if (Counter > 0)
        {
            if (TimeCounter.TimerReverse > TimeCounter.RewindTimer) //Время идет вспять
                
                if (TimeCounter.RewindTimer <= LastTime + 0.5f)
                {
                    OpenTheDoor();
                }

            if (TimeCounter.TimerReverse < TimeCounter.RewindTimer) //Время идет вперед
               
                if (TimeCounter.RewindTimer >= LastTime - 0.5f)
                {
                    CloseTheDoor();
                }

        }
        
     //   Debug.Log(LastTime);
    }

    private void OpenTheDoor()
    {
        anim.SetBool("SetDoorOpen", true);
        anim.SetBool("SetDoorClose", false);
    }

    private void CloseTheDoor()
    {
        anim.SetBool("SetDoorOpen", false);
        anim.SetBool("SetDoorClose", true);
    }
}
