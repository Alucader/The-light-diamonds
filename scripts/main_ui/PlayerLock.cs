using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;
public class PlayerLock : MonoBehaviour
{
    public GameObject image;
    public GameObject play;
    public bool playLock=true;
    public GameObject panel;
    public ShopManager shop;
    public int id;
    void Start()
    {
        play.GetComponent<Toggle>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playLock == false)
        {
            play.GetComponent<Toggle>().enabled = true ;
            //Destroy(panel);
            //Destroy(this.gameObject);
            panel.SetActive(false);
            this.gameObject.SetActive(false);


        }
    }
    public void UnLock(int _gold)
    {
        int gold = PlayerPrefs.GetInt("gold");
        if (gold >= _gold)
        {
            ChageBin(id);
            shop.LoadBin();
            gold -= _gold;
            PlayerPrefs.SetInt("gold", gold);
            
            
        }
        else
            image.SetActive(true);

    }
    public void ChageBin(int n)
    {
        bool lock1=false;
        bool isfound = false;
        XmlDocument xmlDoc = new XmlDocument();
        // string filePath = Application.persistentDataPath + "/bin.xml";
        string filePath = Application.streamingAssetsPath + "/bin.xml";
        if (File.Exists(filePath))
        {
            print(Application.persistentDataPath);
           xmlDoc.Load(filePath);
           XmlNodeList node = xmlDoc.SelectSingleNode("Game").ChildNodes;
            
            foreach (XmlElement ele in node)
            {
                if (ele.Name == "player"&& isfound == false)
                {

                    foreach (XmlElement l1 in ele.ChildNodes)  
                    {
                        if (l1.Name == "id")
                        {
                            if (l1.InnerText == n.ToString())
                            {
                                lock1 = true;
                                print("找到了");
                            }
                        }
                        if (lock1 == true && l1.Name == "lock")
                        {
                            
                            l1.InnerText ="0";
                            isfound = true;
                            break;
                        }
                        
                    }
                   
                }
               
            }
           
        }
        xmlDoc.Save(filePath);
       
    }

    public void Close()
    {
        image.SetActive(false);
    }
}

