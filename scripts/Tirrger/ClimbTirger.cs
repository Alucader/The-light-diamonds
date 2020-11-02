using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbTirger : MonoBehaviour
{
    public PlayController controller;

    void Start()
    {
        
    }

    void Update()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player") || other.tag == ("Player1"))
        {
            //print("Enter");
            controller.isjumpup = true;

        }
    }
  /*  void OnTriggerStay(Collider other)
    {
        if (other.tag == ("Player") || other.tag == ("Player1"))
        {
            print("stay");
            controller.isjumpup = true;

        }
    }
    */
}

