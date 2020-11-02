using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiaShuProps : MonoBehaviour
{
    public Porperties propnum;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player") || other.tag == ("Player1"))
        {
            propnum.num2 += 1;
            Destroy(this.gameObject, 0.3f);
        }
    }
}
