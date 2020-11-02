using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaiHang : MonoBehaviour
{
    public Text[] LvUseTime;
    // Start is called before the first frame update
    void Start()
    {
        print("phbStart");
        Paihangb();
    }

    // Update is called once per frame
    public  void Paihangb()
    {
        for (int i = 1; i < LvUseTime.Length + 1; i++)
        {
            string DataName = "Level" + i + "Time";//数据名称

            int theTime = PlayerPrefs.GetInt(DataName);//获取时间

            if(theTime==0) LvUseTime[i-1].text = "第" + i + "关:    未通过";
            else LvUseTime[i-1].text = "第" + i + "关    ：" + theTime+"秒";
        }
    }
    public void RePlay()
    {
        for (int i = 1; i < LvUseTime.Length + 1; i++)
        {
            string DataName = "Level" + i + "Time";//数据名称
            PlayerPrefs.DeleteKey(DataName);
        }
        Paihangb();
    }
}
