using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyHp : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject enemy;
    public EnemyMove enemyMove;
    public Material deathmaterial;
    public Slider emenyHpSlider;
    float value;
    public float hp=100.0f;
    public float nowHp;
    public bool isDeath;
    public PlayController controller;
    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();
        controller = GameObject.Find("Character").GetComponent<PlayController>();
        enemyMove = enemy.GetComponent<EnemyMove>();
        nowHp = hp;
    }
    
    // Update is called once per frame
    void Update()
    {
        value= nowHp / hp;
        emenyHpSlider.value = value;
      
        if (nowHp <= 0 && isDeath==false)
        {
           // print("死亡");
            enemyMove.enabled = false;
            controller.anim.SetBool("hit", false);
            enemy.GetComponent<NavMeshAgent>().enabled = false;
            enemy.GetComponent<Animator>().SetTrigger("death");         
            isDeath = true;
            StartCoroutine(Death());
            Destroy(enemy, 3.0f);
        }
    }

    public void SubHp(float n)
    {
        nowHp -= n;
    }
    IEnumerator Death()
    {
        yield return  new WaitForSeconds(2);
        enemy.GetComponentInChildren<SkinnedMeshRenderer>().material = deathmaterial;
        particle.Play();

    }
}
