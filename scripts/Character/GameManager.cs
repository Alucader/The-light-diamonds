using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    MainUIData data;
    public List<Image> starlist = new List<Image>();
    public int nowlevel;  //当前关卡
    public float lightNum;   //关卡方块总数
    public float score;
    public int starNum;  //获得的星数
    float value;


    void Start()
    {
        data = MainUIData.Instance;
        foreach (Image item in starlist)
        {
            item.fillAmount = 0;
        }
    }

    void Update()
    {
        if(lightNum !=0)
        {
            value = score / lightNum;
            if (value * 3 <= 1.0f)
            {
                starNum = 0;
                starlist[0].fillAmount = value * 3;
            }
            else if (1.0f <= value * 3 && value * 3 < 2.0f)
            {
                starNum = 1;
                starlist[0].fillAmount = 1;
                starlist[1].fillAmount = value * 3 - 1.0f;
            }
            else if(2.0f <= value * 3 && value * 3 < 3.0f)
            {
                starNum = 2;
                starlist[0].fillAmount = 1;
                starlist[1].fillAmount = 1;
                starlist[2].fillAmount = value * 3 - 2.0f;
            }
            else
            {
                starNum = 3;
                starlist[0].fillAmount = 1;
                starlist[1].fillAmount = 1;
                starlist[2].fillAmount = 1;
            }
           // data.star = starNum;
        }
    }
    public void LightCubeNum()
    {
        score++;
    }
    public void DeleCubeNum()
    {
        score--;
    }
}
