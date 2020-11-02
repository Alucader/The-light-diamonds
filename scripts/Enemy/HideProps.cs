using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideProps : MonoBehaviour
{
    public Porperties propnum;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player") || other.tag == ("Player1"))
        {
            propnum.num3 += 1;
            Destroy(this.gameObject, 0.2f);
        }
    }
}
