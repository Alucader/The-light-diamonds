using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Porperties : MonoBehaviour
{
    public List<Material> playerMaterial = new List<Material>();
    public List<Text> nums = new List<Text>();
    public PlayController play;
    public GameObject panel;
    public GameObject character;
    public GameObject player;
    MainUIData data;
    bool isjiasu;
    public int num1;
    public int num2;
    public int num3;
    void Start()
    {
        data = MainUIData.Instance;
        play = character.GetComponent<PlayController>();
        player = character.transform.GetChild(data.playid).gameObject;
        panel.SetActive(false);
        num1 = int.Parse(nums[0].text);
        num2 = int.Parse(nums[1].text);
        num3 = int.Parse(nums[2].text);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            panel.SetActive(true);
        }
        else
            panel.SetActive(false);

        nums[0].text=num1.ToString();
        nums[1].text = num2.ToString();
        nums[2].text = num3.ToString();
    }
 

    public void SelectWeqpon()  //武器
    {
        if (!play.isAtk)
            play.isAtk = true;
        else
        {
            play.isAtk = false;
        }

    }
    public void SelectHiding()   //隐身
    {
        if (num3 >= 1)
        {
            num3 -= 1;
            player.GetComponent<SkinnedMeshRenderer>().material = playerMaterial[1];
            character.tag = "Player1";
            StartCoroutine(Hiding());
        }
        
    }

    public void AddHp() // 回血
    {
        if (num1>=1)
        {
            
            float nowHp = character.GetComponent<CharactHp>().nowHp;
            float hp = character.GetComponent<CharactHp>().hp;
            if (hp == nowHp || nowHp <= 0)
                return;
            else if (hp - nowHp < 50)
            {
                character.GetComponent<CharactHp>().nowHp = hp;
            }
            else
                character.GetComponent<CharactHp>().nowHp += 50.0f;
            num1 -= 1;
        }
        
    }

    public void JiaShu() //加速
    {
        if (num2 >= 1)
        {
            
            if (!isjiasu)
            {
                num2 -= 1;
                play._moveSpeed += 4;
                StartCoroutine(ShuDu());
                isjiasu = true;
            }
        }
        
       
    }
    IEnumerator Hiding()
    {
        yield return new WaitForSeconds(15);
        player.GetComponent<SkinnedMeshRenderer>().material = playerMaterial[0];
        character.tag = "Player";
        
    }

    IEnumerator ShuDu()
    {
        yield return new WaitForSeconds(10);
        play._moveSpeed -= 4;
        isjiasu = false;
    }
}

