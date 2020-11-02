using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
   
    PlayController controller;
    public GameObject player;//玩家对象
    public float range=2.0f;
    public float damage = 5.0f;
    float distance;
    CharactHp charactHp;
    void Start()
    {
        controller = player.GetComponent<PlayController>();
        charactHp = player.GetComponent<CharactHp>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
    }

    public void Hit()
    {
       if(distance< range && charactHp.isDeath ==false)
        {
            player.GetComponent<CharactHp>().Damage(damage*1.5f);
            controller.TakeBeating();
        }
        
    }
    public void Shoot()
    {

        if (distance < range && charactHp.isDeath == false)
        {
            player.GetComponent<CharactHp>().Damage(damage);
            controller.TakeBeating();
        }
           
    }
    public void Shoot1()
    {
       
        controller.TakeBeatingEnd();
    }
    public void Hit1()
    {
       
        controller.TakeBeatingEnd();
    }
}
