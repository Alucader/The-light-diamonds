using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public  GameObject[] enemys;
    List<EnemyHp> enemyHps = new List<EnemyHp>();
    public float attackRange=2.0f;
    public float damage = 20.0f;

    void Start()
    {

        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemys.Length; i++)
        {
            print("Enemy： " + enemys[i].name);
        }

    }

    void Update()
    {
      
    }
   public  void Hit()
    {
        EnemyDistance();
        foreach (EnemyHp item in enemyHps)
        {
            item.SubHp(damage);
        }
        enemyHps.Clear();
        
    }
    public void EnemyDistance()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
     
        for (int i = 0; i < enemys.Length; i++)
        {
           if( Vector3.Distance(transform.position, enemys[i].transform.position) < attackRange)
            {              
                enemyHps.Add(enemys[i].GetComponent<EnemyHp>());             
            }
        }
        enemys.Initialize();
    }

}
