using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class LevelManger : MonoBehaviour
{
    public List<Locking> lockList = new List<Locking>();
    private bool istrue=false;
    public GameObject but;
   
    void Start()
    {
        // OpenAllLevel();
        StartCoroutine(GetLevel());
    }

   
    void Update()
    {
        
    }

    /// <summary>
    /// 打开所有关卡
    /// </summary>
    public void OpenAllLevel()
    {
        // Debug.Log(gameObject.GetComponentsInChildren<Transform>(true).Length);
        Debug.Log(istrue);
        if (istrue)
        {
            foreach (Locking item in lockList)
            {
                item.isLock = false;
            }
            Destroy(but, 1.0f);
        }
       
    }

    /// <summary>
    /// 获取所有Locking代码组件
    /// </summary>
    /// <returns></returns>
    private IEnumerator GetLevel()
    {

        for (int i = 0; i < gameObject.GetComponentsInChildren<Locking>(true).Length; i++)
        {

            lockList.Add(GetComponentsInChildren<Locking>(true)[i]);
            // Debug.Log("子物体" + GetComponentsInChildren<Transform>(true)[i].name);
        }
        LoadLevels();
        istrue = true;
        yield return istrue;
    }

    public void OpenLevel(int num)
    {
        if (num>=2)
        {
            for (int i = 0; i < num - 1; i++)
            {
                lockList[i].isLock = false;
                
            }
        }     
    }

    /// <summary>
    /// 读取关卡进度Xml文档
    /// </summary>
    /// <returns></returns>
    public  List<Locking> LoadLevels()
    {
        XmlDocument xmlDoc = new XmlDocument();
        // string filePath = Application.dataPath + "/Xml/levels.xml";
       // string filePath = Application.persistentDataPath + "/levels.xml";
        string filePath = Application.streamingAssetsPath + "/levels.xml";
        if (File.Exists(filePath))
        {
            xmlDoc.Load(filePath);
            //  Debug.Log(filePath);
            XmlNodeList node = xmlDoc.SelectSingleNode("levels").ChildNodes;
            int i = 0;
            foreach (XmlElement ele in node)
            {
                
                // Debug.Log(ele.Name);
                if (ele.Name == "level")
                {
                    
                    foreach (XmlElement l1 in ele.ChildNodes)   //遍历id star unlock
                    {
                        if (l1.Name == "star")
                        {
                            lockList[i].starNum = int.Parse(l1.InnerText);
                            
                            //Debug.Log(lockList[i].starNum);
                           
                        }
                        if (l1.Name == "unlock")
                        {
                            if (l1.InnerText=="1")
                            {
                                lockList[i].isLock = false;
                            }
                                                   
                        }

                    }
                    i++;

                }
            }
        }
        return lockList;
    }
}
