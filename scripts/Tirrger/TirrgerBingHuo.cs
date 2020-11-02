using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirrgerBingHuo : MonoBehaviour
{
    // Start is called before the first frame update
     public bool isBing=true ;
     PlayController play;
     CharactHp charactHp;
    void Start()
    {
        play = (PlayController)FindObjectOfType(typeof(PlayController)) as PlayController;
        charactHp = (CharactHp)FindObjectOfType(typeof(CharactHp)) as CharactHp;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == ("Player") || other.tag == ("Player1"))
        {
           
            
        }
    }
    void OnTriggerStay(Collider other)
    {

        if (other.tag == ("Player") || other.tag == ("Player1"))
        {
            if (isBing)
            {
                play._moveSpeed = 3.0f;
            }
            else
            {
                charactHp.nowHp -= 10 * Time.deltaTime;
            }

        }
    }
    void OnTriggerExit(Collider other)
    {

        if (other.tag == ("Player") || other.tag == ("Player1"))
        {
            if (isBing)
            {
                play._moveSpeed = 6.0f;
            }

        }
      
    }
}
