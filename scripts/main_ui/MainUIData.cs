using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 单例模式进行全局数据管理
/// </summary>
public class MainUIData : MonoBehaviour
{
    private static MainUIData _instance;

    [Header ("金币钻石")]
    public int gold;
    public int dim;  

    [Header("ID")]
    public string id;
    
    [Range(0,50)]
    [Header("等级")]
    public int level;
   
    [Header("经验")]
    public int ex;

    [Header("头像")]
    public Sprite photo;

    [Header("当前关卡")]
    public int nowlevel=2;
    [Header("当前关卡星数")]
    public int star=3;
    [Header("当前角色")]
    public int playid=8;
    private void Awake()
    {
         Debug.Log("MainData");
        _instance = this;
        DontDestroyOnLoad(gameObject);
      
    }
    public void Start()
    {
       if(!PlayerPrefs.HasKey("gold"))
        {
            PlayerPrefs.SetInt("gold", 1001);
        }
        if (!PlayerPrefs.HasKey("dim"))
        {
            PlayerPrefs.SetInt("dim", 100);
        }
        if (!PlayerPrefs.HasKey("id"))
        {
            PlayerPrefs.SetString("id", "小林");
        }
        if (!PlayerPrefs.HasKey("lv"))
        {
            PlayerPrefs.SetInt("lv", 1);
        }
        if (!PlayerPrefs.HasKey("ex"))
        {
            PlayerPrefs.SetInt("ex", 0);
        }
        PlayerPrefs.Save();
       
    }
    void Update()
    {
        gold = PlayerPrefs.GetInt("gold");
        dim = PlayerPrefs.GetInt("dim");
        id = PlayerPrefs.GetString("id");
        ex = PlayerPrefs.GetInt("ex");
        level = PlayerPrefs.GetInt("lv");
        if (ex >= 100)
        {
            ex -= 100;
            level += 1;
            PlayerPrefs.SetInt("ex", ex);
            PlayerPrefs.SetInt("lv", level);
        }     
    }
    /// <summary>
    /// 单例模式
    /// </summary>
     static public MainUIData Instance
    {
        
        get
        {
            Debug.Log("Instance");
            if (_instance == null)
            {

                GameObject go = new GameObject("_DataManager");   //创建一个物体
                DontDestroyOnLoad(go);   //防止加载被销毁
                _instance = go.AddComponent<MainUIData>();  //添加组件
            }       
            
            return _instance;
            
        }
    }

   
}


