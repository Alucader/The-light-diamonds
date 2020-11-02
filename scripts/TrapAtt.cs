using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAtt : MonoBehaviour
{
    public CharactHp charactHp;

    private void Start()
    {
        charactHp = GameObject.Find("CharactManager/Character").GetComponent<CharactHp>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player") || other.tag == ("Player1"))
        {
            charactHp.nowHp -= 20;
        }
    }
}
