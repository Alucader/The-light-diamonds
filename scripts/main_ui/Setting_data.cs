using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.IO;
using UnityEngine.SceneManagement;
public class Setting_data : MonoBehaviour
{
    public InputField goldInput;
    public InputField dimInput;
    public InputField lvInput;
    public Slider slider;
    public  AudioSource _audio;
    void Start()
    {
        _audio = (AudioSource)FindObjectOfType(typeof(AudioSource)) as AudioSource;
        slider.value = _audio.volume;
    }
    public void OnClick()
    {
        string _gold = goldInput.text.Trim();
        print(_gold);
        if (_gold != "")
        {
            int gold = int.Parse(_gold);
            if (gold > 99999)
            {
                gold = 99999;
            }
            PlayerPrefs.SetInt("gold", gold);
        }
        string _dim = dimInput.text.Trim();
        if (_dim != "")
        {
            int dim = int.Parse(_dim);
            if (dim > 9999)
            {
                dim = 9999;
            }
            PlayerPrefs.SetInt("dim", dim);
        }

        string _lv = lvInput.text.Trim();
        if (_lv != "")
        {
            int lv = int.Parse(_lv);
            if (lv >= 50)
            {
                lv = 50;
            }
            PlayerPrefs.SetInt("lv", lv);
        }
        PlayerPrefs.Save();
    }
    
    public void Quit()  //退出
    {
        Application.Quit();
    }
    public void RePlayerSelsect() //重置角色购买
    {
        MainUIData.Instance.playid = 8;
        XmlDocument xmlDoc = new XmlDocument();
       // string filePath = Application.persistentDataPath + "/bin.xml";
        string filePath = Application.streamingAssetsPath + "/bin.xml";
        if (File.Exists(filePath))
        {
            xmlDoc.Load(filePath);
            XmlNodeList node = xmlDoc.SelectSingleNode("Game").ChildNodes;

            foreach (XmlElement ele in node)
            {
                if (ele.Name == "player")
                {

                    foreach (XmlElement l1 in ele.ChildNodes)
                    {
                        
                        if (l1.Name == "lock")
                        {
                            l1.InnerText = "1";                        
                        }
                    }
                }
            }
        }
        xmlDoc.Save(filePath);
    }

    public void Sound()
    {
        _audio.volume = slider.value;
    }

}
