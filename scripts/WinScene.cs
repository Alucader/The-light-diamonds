using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class WinScene : MonoBehaviour
{
    public Image _left;
    public Image _mid;
    public Image _right;
    private Color _isStart=new Color(254.0f/255.0f,207.0f / 255.0f, 88.0f / 255.0f, 1);
    public Color _notStart;
    public Text lv;
    public Slider exslider;
    MainUIData data;
    public string reLoadName;
    public string nextName;
    public Load load;

    public Text addEx;
    public Text addGold;
    public int _gold;

    void Awake()
    {
        data = MainUIData.Instance;
    }
    void Start()
    {      
        
        StartNum(data.star);
        int _ex = data.ex;
        _gold = data.gold;
        print("11");
        PlayerPrefs.SetInt("ex", _ex + 50+ data.nowlevel* data.star);  //经验奖励
        PlayerPrefs.SetInt("gold", _gold + 500 + data.nowlevel * 10 * data.star);    //金币奖励
       
        reLoadName = "Lv"+data.nowlevel.ToString();
        if(data.nowlevel < 24)
        {
            nextName = "Lv" + (data.nowlevel + 1).ToString();
        }
        else
            nextName = "Lv" + data.nowlevel.ToString();
        LoadNowXml();
        LoadNextXml();
    }


    void Update()
    {
        addEx.text = "Ex  +" + (50 + data.nowlevel * data.star).ToString();
        addGold.text = "金币  +" + (500 + data.nowlevel * 10 * data.star).ToString();
        lv.text = "Lv "+data.level.ToString();
        exslider.value = (float)data.ex / 100;
    }
    public void StartNum(int n)
    {
        switch (n)
        {
            case 0:
                print("0");
                break;
            case 1:
                _left.color = _isStart;
                break;
            case 2:
                _left.color = _isStart;
                _mid.color = _isStart;                
                break;
            default:
                _left.color = _isStart;
                _mid.color = _isStart;
                _right.color = _isStart;
                break;
        }
    }
    
  public void ReloadScene() //重新
    {
        load.LoadNextScene(reLoadName);
    }
    public void LoadNextScene() //下一关
    {
        load.LoadNextScene(nextName);
    }
    public void UnLock()
    {
        if (data.star >= 2)
        {
            print("解锁下一关");

        }
    }

    public void LoadNowXml()
    {
        XmlDocument xmlDoc = new XmlDocument();
        // string filePath = Application.dataPath + "/Xml/levels.xml";
       // string filePath = Application.persistentDataPath + "/levels.xml";
        string filePath = Application.streamingAssetsPath + "/levels.xml";


        if (File.Exists(filePath))
        {
            xmlDoc.Load(filePath);
            XmlNodeList node = xmlDoc.SelectSingleNode("levels").ChildNodes;

            foreach (XmlElement ele in node)   //遍历level节点
            {
                bool isfound=false;
                if (ele.Name == "level")
                {

                    foreach (XmlElement l1 in ele.ChildNodes)  //遍历level子节点 ID star unlock
                    {

                        if (l1.Name == "id")
                        {
                            if(l1.InnerText == (data.nowlevel - 2).ToString())
                            {
                                print("找到了");
                                isfound = true;
                            }
                            

                        }
                        if (l1.Name == "star" && isfound == true)
                        {
                            if(data .star> int.Parse(l1.InnerText))
                            {
                                l1.InnerText = data.star.ToString();
                            }
                        }
                        if (l1.Name == "unlock"&& isfound == true)
                        {
                            print(l1.InnerText);
                        }
                    }
                }
            }
        }
        xmlDoc.Save(filePath);
    }
    public void LoadNextXml()
    {
        XmlDocument xmlDoc = new XmlDocument();
        // string filePath = Application.dataPath + "/Xml/levels.xml";
        string filePath = Application.streamingAssetsPath + "/levels.xml";
      //  string filePath = Application.persistentDataPath + "/levels.xml";
        if (File.Exists(filePath))
        {
            xmlDoc.Load(filePath);
            XmlNodeList node = xmlDoc.SelectSingleNode("levels").ChildNodes;
            foreach (XmlElement ele in node)   //遍历level节点
            {
                bool isfound = false;
                if (ele.Name == "level")
                {
                    foreach (XmlElement l1 in ele.ChildNodes)  //遍历level子节点 ID star unlock
                    {
                        if (l1.Name == "id")
                        {
                            if (l1.InnerText == (data.nowlevel - 1).ToString())
                            {
                                print("找到了");
                                isfound = true;
                            }
                        }
                        
                        if (l1.Name == "unlock" && isfound == true)
                        {
                            l1.InnerText = "1";
                        }
                    }
                }
            }
        }
        xmlDoc.Save(filePath);
    }
}
