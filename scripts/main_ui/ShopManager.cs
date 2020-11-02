using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
public class ShopManager : MonoBehaviour
{
    public List<PlayerLock> playerLocks = new List<PlayerLock>();
    void Start()
    {
        LoadBin();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadBin()
    {
        XmlDocument xmlDoc = new XmlDocument();
        //  string filePath = Application.persistentDataPath + "/bin.xml";

        string filePath = Application.streamingAssetsPath + "/bin.xml";
        if (File.Exists(filePath))     
        {
           
            xmlDoc.Load(filePath);
            XmlNodeList node = xmlDoc.SelectSingleNode("Game").ChildNodes;
            int i = 0;
            foreach (XmlElement ele in node)
            {
                if (ele.Name == "player")
                {
               
                foreach (XmlElement l1 in ele.ChildNodes)   //遍历id star unlock
                    {
                        if (l1.Name == "lock")
                        {
                            if (l1.InnerText == "0")
                            {
                                playerLocks[i].playLock = false;
                            }
                        }

                    }
                }
                i++;
            }

        }
    }
}


