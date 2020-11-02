using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharactHp : MonoBehaviour
{
    public float hp;
    public float nowHp;
    public Slider hpSlider;
    MainUIData data;
    public GameObject player;
    PlayController controller;
    public  bool isDeath;
    public GameObject overpanel;
    void Start()
    {
        overpanel.SetActive(false);
        hpSlider = GameObject.Find("hpSlider").GetComponent<Slider>();
        controller = player.GetComponent<PlayController>();
        data = MainUIData.Instance;
        hp = 100 * (1 + data.level * 0.2f);
        nowHp = hp;      
    }

    void Update()
    {

        hpSlider.value = nowHp / hp;
        if (hpSlider.value <= 0 && isDeath == false)
        {
            controller.anim.SetTrigger("death");
            controller.enabled = false;
            player.GetComponent<PlayerAttack>().enabled=false;
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<AudioSource>().enabled = false;
            StartCoroutine(GameOver());
            isDeath = true;
        }
    }

   public  void Damage(float n)
    {
        if (nowHp <= 0)
            return;
        
         nowHp -= n;
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3.0f);
        overpanel.SetActive(true);
    }
}

