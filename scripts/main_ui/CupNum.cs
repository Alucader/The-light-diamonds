using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;
public class CupNum : MonoBehaviour
{
    public GameObject cupPanel;
    public Text cup1;
    public Text cup2;
    public Text cup3;
    int num1;
    int num2;
    int num3;
    // Start is called before the first frame update
    void Start()
    {
        //cupPanel.SetActive(false);
        
    }

    // Update is called once per frame
   public  void CupNums()
    {
        cupPanel.SetActive(true);
        XmlDocument xmlDoc = new XmlDocument();
        // string filePath = Application.dataPath + "/Xml/levels.xml";
        string filePath = Application.streamingAssetsPath + "/levels.xml";
        // string filePath = Application.persistentDataPath + "/levels.xml";
        if (File.Exists(filePath))
        {
            xmlDoc.Load(filePath);
            XmlNodeList node = xmlDoc.SelectSingleNode("levels").ChildNodes;
            foreach (XmlElement ele in node)   //遍历level节点
            {               
                if (ele.Name == "level")
                {
                    foreach (XmlElement l1 in ele.ChildNodes)  //遍历level子节点 ID star unlock
                    {                      
                        if (l1.Name == "star" )
                        {
                           // print(l1.InnerText);
                            if (l1.InnerText == "3")
                                num1++;
                            else if (l1.InnerText == "2")
                                num2++;
                            else if (l1.InnerText == "1")
                                num3++;
                        }
                    }
                }
            }
        }

        cup1.text = "X  " + (num1+1);
        cup2.text = "X  " + num2;
        cup3.text = "X  " + num3;
    }
    public void RePlay()
    {
        XmlDocument xmlDoc = new XmlDocument();
        // string filePath = Application.dataPath + "/Xml/levels.xml";
      //  string filePath = Application.persistentDataPath + "/levels.xml";
        string filePath = Application.streamingAssetsPath + "/levels.xml";
        if (File.Exists(filePath))
        {
            xmlDoc.Load(filePath);
            XmlNodeList node = xmlDoc.SelectSingleNode("levels").ChildNodes;
            foreach (XmlElement ele in node)   //遍历level节点
            {
                if (ele.Name == "level")
                {
                    foreach (XmlElement l1 in ele.ChildNodes)  //遍历level子节点 ID star unlock
                    {
                      

                        if (l1.Name == "star")
                        {
                            l1.InnerText="0";    
                            
                        }

                        if (l1.Name == "unlock")
                        {
                            l1.InnerText = "0";
                        }
                    }
                }
            }
            xmlDoc.Save(filePath);
        }

        cup1.text = "X  " + 1;
        cup2.text = "X  " + 0;
        cup3.text = "X  " + 0;

    }

    public void Close()
    {
        cupPanel.SetActive(false);
    }
}

